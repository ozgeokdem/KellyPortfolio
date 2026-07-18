using Kelly.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kelly.Areas.ManagementArea.Controllers
{
    [Area("ManagementArea"), Authorize]
    public class ContactMessagesController : Controller
    {
        private readonly KellyDbContext _context;
        public ContactMessagesController(KellyDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var model = await _context
                .ContactMessages
                .AsNoTracking()
                .OrderBy(x => x.SendDate)
                .ToListAsync();

            return View(model);
        }

        public async Task<IActionResult> Detail (Guid id)
        {
            var model = await _context
                .ContactMessages
                .FindAsync(id);

            if(model is null)
                return RedirectToAction(nameof(Index));

            model.IsReaded = true;
            _context.ContactMessages.Update(model);
            await _context.SaveChangesAsync();
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id)
        {
            var model = await _context.ContactMessages.FindAsync(id);

            if (model is null)
                return Json(new { Status = false, Message = "Veri Bulunamadı!" });

            _context.ContactMessages.Remove(model);
            await _context.SaveChangesAsync();

            return Json(new { Status = true, Message = "Veri Silindi!" });
        }
    }
}

using Kelly.Models;
using Kelly.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kelly.Areas.ManagementArea.Controllers
{
    [Area("ManagementArea"), Authorize]
    public class ServicePagesController : Controller
    {
        private readonly KellyDbContext _context;

        public ServicePagesController(KellyDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var model = await _context.ServicePages.AsNoTracking().FirstOrDefaultAsync();

            if(model is null)
            {
                model = new ServicePage
                {
                    Id = Guid.NewGuid(),
                    PageTitle = string.Empty,
                    PageDescription = string.Empty
                };
                await _context.ServicePages.AddAsync(model);
                await _context.SaveChangesAsync();
            }

            return View(model);
        }

        public async Task<IActionResult> Edit()
        {
            var model = await _context.ServicePages.FirstOrDefaultAsync();
            if(model is null)
                return RedirectToAction(nameof(Index));

            return View(model);
        }

        [HttpPost,ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ServicePage model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _context.ServicePages.Update(model);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}

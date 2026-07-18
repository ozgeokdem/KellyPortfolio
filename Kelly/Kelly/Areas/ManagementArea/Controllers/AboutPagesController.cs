using Kelly.Models;
using Kelly.Models.Entities;
using Kelly.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kelly.Areas.ManagementArea.Controllers
{
    [Area("ManagementArea"), Authorize]
    public class AboutPagesController : Controller
    {
        private readonly KellyDbContext _context;
        private readonly IWebHostEnvironment _env;
        public AboutPagesController(KellyDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            var model = await _context
                .AboutPages
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if(model is null)
            {
                model = new AboutPage();
                model.Id = Guid.NewGuid();
                await _context.AboutPages.AddAsync(model);
                await _context.SaveChangesAsync();
            }    

            return View(model);
        }

        public async Task<IActionResult> Edit()
        {
            var model = await _context
                .AboutPages
                .FirstOrDefaultAsync();

            if(model is null)
                return RedirectToAction(nameof(Index));

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AboutPage model, IFormFile? img)
        {
            if(!ModelState.IsValid)
                return View(model);

            if (img != null)
            {
                if (!String.IsNullOrWhiteSpace(model.ImageUrl))
                    await FileUploader.DeleteAsync(_env, model.ImageUrl);

                model.ImageUrl = await FileUploader.UploadAsync(_env, img);
            }
            
            _context.AboutPages.Update(model);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
    }
}

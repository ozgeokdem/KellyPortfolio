using Kelly.Models;
using Kelly.Models.Entities;
using Kelly.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kelly.Areas.ManagementArea.Controllers
{
    [Area("ManagementArea"), Authorize]
    public class SiteSettingsController : Controller
    {
        private readonly KellyDbContext _context;
        private readonly IWebHostEnvironment _env;
        public SiteSettingsController(KellyDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            var model = await _context
                .SiteSettings
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if(model is null)
            {
                model = new SiteSetting();
                model.Id = Guid.NewGuid();
                await _context.SiteSettings.AddAsync(model);
                await _context.SaveChangesAsync();
            }    

            return View(model);
        }

        public async Task<IActionResult> Edit()
        {
            var model = await _context
                .SiteSettings
                .FirstOrDefaultAsync();

            if(model is null)
                return RedirectToAction(nameof(Index));

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SiteSetting model, IFormFile? img)
        {
            if(!ModelState.IsValid)
                return View(model);

            if (img != null)
            {
                if (!String.IsNullOrWhiteSpace(model.LogoUrl))
                    await FileUploader.DeleteAsync(_env, model.LogoUrl);

                model.LogoUrl = await FileUploader.UploadAsync(_env, img);
            }
            
            _context.SiteSettings.Update(model);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}

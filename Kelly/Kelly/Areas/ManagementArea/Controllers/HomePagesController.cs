using Kelly.Models;
using Kelly.Models.Entities;
using Kelly.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kelly.Areas.ManagementArea.Controllers
{
    [Area("ManagementArea"), Authorize]
    public class HomePagesController : Controller
    {
        private readonly KellyDbContext _context;
        private readonly IWebHostEnvironment _env;

        public HomePagesController(KellyDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            var model = await _context.HomePages.AsNoTracking().FirstOrDefaultAsync();

            if(model is null)
            {
                model = new HomePage
                {
                    Id = Guid.NewGuid(),
                    PageTitle = string.Empty,
                    PageDescription = string.Empty,
                    PageButtonTitle = string.Empty,
                    PageButtonUrl = string.Empty,
                    ImageUrl = string.Empty
                };
                await _context.HomePages.AddAsync(model);
                await _context.SaveChangesAsync();
            }

            return View(model);
        }

        public async Task<IActionResult> Edit()
        {
            var model = await _context.HomePages.FirstOrDefaultAsync();
            if(model is null)
                return RedirectToAction(nameof(Index));

            return View(model);
        }

        [HttpPost,ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(HomePage model, IFormFile? img)
        {
            if (!ModelState.IsValid)
                return View(model);

            if(img != null)
            {
                if (!String.IsNullOrWhiteSpace(model.ImageUrl))
                    await FileUploader.DeleteAsync(_env, model.ImageUrl);

                model.ImageUrl = await FileUploader.UploadAsync(_env, img);
            }

            _context.HomePages.Update(model);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}

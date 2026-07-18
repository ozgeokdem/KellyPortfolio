using Kelly.Models;
using Kelly.Models.Entities;
using Kelly.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kelly.Areas.ManagementArea.Controllers
{
    [Area("ManagementArea"), Authorize]
    public class PortfolioItemImagesController : Controller
    {
        private readonly KellyDbContext _context;
        private readonly IWebHostEnvironment _env;
        public PortfolioItemImagesController(KellyDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index(Guid id)
        {
            var model = await _context
                .PortfolioItemImages
                .AsNoTracking()
                .Where(x => x.PortfolioItemId == id)
                .ToListAsync();

            ViewData["Id"] = id;

            return View(model);
        }

        public async Task<IActionResult> Create(Guid id)
        {
            return View(new PortfolioItemImage
            {
                Id = Guid.NewGuid(),
                PortfolioItemId = id
            });
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Guid portfolioItem, PortfolioItemImage model, IFormFile img)
        {
            if(!ModelState.IsValid)
                return View(model);

            model.Id = Guid.NewGuid();
            model.PortfolioItemId = portfolioItem;
            model.Item = null;
            model.ImageUrl = await FileUploader.UploadAsync(_env, img);
            await _context.PortfolioItemImages.AddAsync(model);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { id = portfolioItem });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var model = await _context
                .PortfolioItemImages
                .FindAsync(id);

            if (model is null)
                return Json(new { Success = false, Message = "Veri Bulunamadı!" });

            return Json(new { Success = true, Message = "Veri Silindi." });
        }
    }
}

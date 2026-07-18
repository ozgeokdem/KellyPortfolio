using Kelly.Models;
using Kelly.Models.Entities;
using Kelly.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kelly.Areas.ManagementArea.Controllers
{
    [Area("ManagementArea"), Authorize]
    public class PortfolioPagePortfolioController : Controller
    {
        private readonly KellyDbContext _context;
        private readonly IWebHostEnvironment _env;
        public PortfolioPagePortfolioController(KellyDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            Guid? id = _context.PortfolioPages.FirstOrDefault()?.Id;
            var model = await _context
                .PortfolioItems
                .AsNoTracking()
                .Where(x => x.PortfolioPageId == id)
                .ToListAsync();

            //var model = _context
            //    .PortfolioPages
            //    .AsNoTracking()
            //    .FirstOrDefault()
            //    ?.Items
            //    ?.ToList();

            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PortfolioItem model, IFormFile img)
        {
            if (!ModelState.IsValid)
                return View(model);

            model.Id = Guid.NewGuid();
            model.ImageUrl = await FileUploader.UploadAsync(_env, img);
            model.PortfolioPageId = _context.PortfolioPages.FirstOrDefault()?.Id;

            model.PortfolioPage = null;

            await _context.PortfolioItems.AddAsync(model);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var model = await _context
                .PortfolioItems
                .FindAsync(id);

            if (model is null)
                return RedirectToAction(nameof(Index));

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, PortfolioItem model, IFormFile? img)
        {
            if (!ModelState.IsValid)
                return View(model);

            if(img is not null)
            {
                if(!String.IsNullOrWhiteSpace(model.ImageUrl))
                    await FileUploader.DeleteAsync(_env, model.ImageUrl);

                model.ImageUrl = await FileUploader.UploadAsync(_env, img);
            }

            _context.PortfolioItems.Update(model);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var model = await _context.PortfolioItems.FindAsync(id);

            if (model is null)
                return Json(new { Status = false, Message = "Veri bulunamadı!" });

            if (!String.IsNullOrWhiteSpace(model.ImageUrl))
                await FileUploader.DeleteAsync(_env, model.ImageUrl);

            var images = await _context
                .PortfolioItemImages
                .Where(x => x.PortfolioItemId == model.Id)
                .ToListAsync();

            _context.PortfolioItemImages.RemoveRange(images);
            _context.PortfolioItems.Remove(model);

            await _context.SaveChangesAsync();

            return Json(new { Status = true, Message = "Veri Silindi." });
        }
    }
}

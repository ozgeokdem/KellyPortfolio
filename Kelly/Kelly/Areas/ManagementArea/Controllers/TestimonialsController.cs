using Kelly.Models;
using Kelly.Models.Entities;
using Kelly.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kelly.Areas.ManagementArea.Controllers
{
    [Area("ManagementArea"), Authorize]
    public class TestimonialsController : Controller
    {
        private readonly KellyDbContext _context;
        private readonly IWebHostEnvironment _env;
        public TestimonialsController(KellyDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context
                .Testimonials
                .AsNoTracking()
                .ToListAsync());
        }

        public IActionResult Create() => View();

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Testimonial model, IFormFile img)
        {
            if(!ModelState.IsValid)
                return View(model);

            model.Id = Guid.NewGuid();
            model.ProfilePictureUrl = await FileUploader.UploadAsync(_env, img);
            await _context.Testimonials.AddAsync(model);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var model = await _context
                .Testimonials
                .FindAsync(id);

            if (model is null)
                return RedirectToAction(nameof(Index));

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Testimonial model, IFormFile? img)
        {
            if (!ModelState.IsValid)
                return View(model);

            if(img is not null)
            {
                if (!String.IsNullOrWhiteSpace(model.ProfilePictureUrl))
                    await FileUploader.DeleteAsync(_env, model.ProfilePictureUrl);

                model.ProfilePictureUrl = await FileUploader.UploadAsync(_env, img);
            }

            _context.Testimonials.Update(model);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var model = await _context.Testimonials.FindAsync(id);

            if (model is null)
                return Json(new { Status = false, Message = "Veri bulunamadı!" });

            if (!String.IsNullOrWhiteSpace(model.ProfilePictureUrl))
                await FileUploader.DeleteAsync(_env, model.ProfilePictureUrl);

            
            _context.Testimonials.Remove(model);

            await _context.SaveChangesAsync();

            return Json(new { Status = true, Message = "Veri Silindi." });
        }
    }
}

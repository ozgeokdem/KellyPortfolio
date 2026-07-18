using Kelly.Models;
using Kelly.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kelly.Areas.ManagementArea.Controllers
{
    [Area("ManagementArea"), Authorize]
    public class AboutSkillsController : Controller
    {
        private readonly KellyDbContext _context;
        public AboutSkillsController(KellyDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context
                .AboutSkills
                .ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AboutSkill model)
        {
            if(!ModelState.IsValid)
                return View(model);

            model.Id = Guid.NewGuid();
            await _context.AboutSkills.AddAsync(model);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(Guid id) 
        {
            var model = await _context.AboutSkills.FindAsync(id);
            if (model is null)
                return RedirectToAction(nameof(Index));

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, AboutSkill model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _context.AboutSkills.Update(model);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var model = await _context.AboutSkills.FindAsync(id);

            if (model is null)
                return Json(new { Status = false, Message = "Veri Bulunamadı!" });

            _context.AboutSkills.Remove(model);
            await _context.SaveChangesAsync();

            return Json(new { Status = true, Message = "Veri Silindi!" });
        }
    }
}

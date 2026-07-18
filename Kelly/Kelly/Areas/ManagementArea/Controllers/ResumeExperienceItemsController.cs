using Kelly.Models;
using Kelly.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace Kelly.Areas.ManagementArea.Controllers
{
    [Area("ManagementArea"), Authorize]
    public class ResumeExperienceItemsController : Controller
    {
        private readonly KellyDbContext _context;
        public ResumeExperienceItemsController(KellyDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context
                .ResumeExperienceItems
                .Include(x => x.ResumeExperience)
                .ToListAsync());
        }

        public IActionResult Create()
        {
            ViewBag.Experiences = new SelectList(_context
                .ResumeExperiences
                .ToList(),
                 "Id",
                 "Position");
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ResumeExperienceItem model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Experiences = _context.ResumeExperiences.ToList();
                return View(model);
            }

            await _context.ResumeExperienceItems.AddAsync(model);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var model = await _context.ResumeExperienceItems.FindAsync(id);

            if (model is null)
                return NotFound();

            ViewBag.Experiences = _context.ResumeExperiences.ToListAsync();

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ResumeExperienceItem model)
        {
            if (id != model.Id)
                return NotFound();

            if (!ModelState.IsValid)
            {
                ViewBag.Experiences = await _context.ResumeExperiences.ToListAsync();
                return View(model);
            }
                

            _context.ResumeExperienceItems.Update(model);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var model = await _context.ResumeExperienceItems.FindAsync(id);

            if (model is null)
                return Json(new { Status = false, Message = "Veri Bulunamadı!" });

            _context.ResumeExperienceItems.Remove(model);
            await _context.SaveChangesAsync();

            return Json(new { Status = true, Message = "Veri Silindi!" });
        }
    }
}

using Kelly.Models;
using Kelly.Models.Entities;
using Kelly.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Kelly.Controllers
{
    public class HomeController : Controller
    {
        private readonly KellyDbContext _context;
        public HomeController(KellyDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context
                .HomePages
                .AsNoTracking()
                .FirstOrDefaultAsync());
        }
        public async Task<IActionResult> About()
        {
            var model = await _context
                .AboutPages
                .AsNoTracking()
                .FirstOrDefaultAsync();

            model.AboutSkills = await _context.AboutSkills.ToListAsync();
            model.AboutFacts = await _context.AboutFacts.ToListAsync();
            model.Testimonials = await _context.Testimonials.ToListAsync();

            return View(model);
        }
        public async Task<IActionResult> Resume()
        {
           var model = await _context
                .ResumePages
                .AsNoTracking()
                .Include(x => x.Sumary)
                .Include(x => x.Educations)
                .Include(x => x.Experiences)
                    .ThenInclude(x => x.Items)
                .FirstOrDefaultAsync();

            return View(model);
        }
        public async Task<IActionResult> Services()
        {
            return View(await _context
                .ServicePages
                .AsNoTracking()
                .Include(x => x.ServiceCards)
                .FirstOrDefaultAsync());
        }
        public async Task<IActionResult> Portfolio()
        {
            return View(await _context
                .PortfolioPages
                .AsNoTracking()
                .Include(x => x.Items)
                .FirstOrDefaultAsync());
        }
        public async Task<IActionResult> Contact()
        {
            return View(await _context
                .ContactPages
                .FirstOrDefaultAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Contact(string name, string email, string subject, string message)
        {
            var model = new ContactMessage
            {
                Email = email,
                YourName = name,
                Message = message,
                Subject = subject,
                SendDate = DateTimeOffset.Now,
                IsReaded = false,
                Id = Guid.NewGuid()
            };
            await _context.ContactMessages.AddAsync(model);
            await _context.SaveChangesAsync();

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("ozgeokdem@icloud.com");
            mailMessage.To.Add(new MailAddress("ozgeokdem@icloud.com"));
            mailMessage.Subject = "Kelly İletişim Formu - Yeni Mesaj";
            mailMessage.Body = $"Ad Soyad: {name}\r\nEposta: {email}\r\nKonu: {subject}\r\nMesaj: {message}";
            mailMessage.IsBodyHtml = false;
            mailMessage.Sender = new MailAddress("ozgeokdem@icloud.com");

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.mail.me.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential("ozgeokdem@icloud.com", "xjhd-dsjfl-uıgfd"); //xjhd-dsjfl-uıgfd alanı Appledan alınan özel şifre olmalı.
            smtp.Send(mailMessage);

            return RedirectToAction(nameof(Contact));
        }
        public async Task<IActionResult> PortfolioDetail(Guid id)
        {
            var model = await _context
                .PortfolioItems
                .AsNoTracking()
                .Where(x => x.Id == id)
                .Include(x => x.Images)
                .FirstOrDefaultAsync();

            var page = await _context
                .PortfolioPages
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if (model is null || page is null)
                return NotFound();

            var VM = new PortfolioDetailVM
            {
                Page = page,
                Item = model
            };
            return View(VM);
        }
    }
}

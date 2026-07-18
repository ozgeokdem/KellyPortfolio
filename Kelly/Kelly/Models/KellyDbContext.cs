using Kelly.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Kelly.Models
{
    public class KellyDbContext : DbContext
    {
        public KellyDbContext() { }
        public KellyDbContext(DbContextOptions<KellyDbContext> options) : base(options) { }

        public DbSet<AboutFact> AboutFacts { get; set; }
        public DbSet<AboutPage> AboutPages { get; set; }
        public DbSet<AboutSkill> AboutSkills { get; set; }
        public DbSet<ContactMessage> ContactMessages { get; set; }
        public DbSet<ContactPage> ContactPages { get; set; }
        public DbSet<HomePage> HomePages { get; set; }
        public DbSet<PortfolioItem> PortfolioItems { get; set; }
        public DbSet<PortfolioItemImage> PortfolioItemImages { get; set; }
        public DbSet<PortfolioPage> PortfolioPages { get; set; }
        public DbSet<ResumePage> ResumePages { get; set; }
        public DbSet<ResumeSumary> ResumeSumaries { get; set; }
        public DbSet<ResumeEducation> ResumeEducations { get; set; }
        public DbSet<ResumeExperience> ResumeExperiences { get; set; }
        public DbSet<ServiceCard> ServiceCards { get; set; }
        public DbSet<ServicePage> ServicePages { get; set; }
        public DbSet<SiteSetting> SiteSettings { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ResumeExperienceItem> ResumeExperienceItems { get; set; }
    }
}

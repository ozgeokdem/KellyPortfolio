using Kelly.Models.Entities.Base;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kelly.Models.Entities
{
    [Table("AboutPages")]
    public class AboutPage : BaseEntitiy
    {

        public string? PageTitle { get; set; }
        public string? PageDescription { get; set; }

        public string? AboutTitle { get; set; }
        public string? AboutDescription { get; set; }
        public string? AboutContent { get; set; }
        [ValidateNever]
        public string? ImageUrl { get; set; }
        public DateOnly? AboutBirthday { get; set; }
        public string? AboutWebsite { get; set; }
        public string? AboutPhoneNumber { get; set; }
        public string? AboutCity { get; set; }
        public byte? AboutAge { get; set; }
        public string? AboutDegree { get; set; }
        public string? AboutEmail { get; set; }
        public bool AboutFreelance { get; set; }

        public string? SkillsUpperTitle { get; set; }
        public string? SkillsTitle { get; set; }
        [NotMapped]
        public List<AboutSkill>? AboutSkills { get; set; } = new List<AboutSkill>();

        public string? FactsUpperTitle { get; set; }
        public string? FactsTitle { get; set; }
        [NotMapped]
        public List<AboutFact>? AboutFacts { get; set; } = new List<AboutFact>();

        public string? TestimonialsUpperTitle { get; set; }
        public string? TestimonialsTitle { get; set; }
        [NotMapped]
        public List<Testimonial>? Testimonials { get; set; } = new List<Testimonial>();
    }
}

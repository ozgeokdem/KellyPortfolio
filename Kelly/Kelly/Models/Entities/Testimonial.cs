using Kelly.Models.Entities.Base;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kelly.Models.Entities
{
    [Table("Testimonials")]
    public class Testimonial : BaseEntitiy
    {
        public string? FullName { get; set; }
        public string? Title { get; set; }
        [ValidateNever]
        public string? ProfilePictureUrl { get; set; }
        public string? Comment { get; set; }
    }
}

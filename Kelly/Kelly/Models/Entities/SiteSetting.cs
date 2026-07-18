using Kelly.Models.Entities.Base;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kelly.Models.Entities
{
    [Table("SiteSettings")]
    public class SiteSetting : BaseEntitiy
    {
        [ValidateNever]
        public string? LogoUrl { get; set; }
        public string? CopyTitle { get; set; }
        public string? DesignTitle { get; set; }
        public string? InstagramUrl { get; set; }
        public string? FacebookUrl { get; set; }
        public string? TwitterUrl { get; set; }
        public string? LinkedinUrl { get; set; }


    }
}

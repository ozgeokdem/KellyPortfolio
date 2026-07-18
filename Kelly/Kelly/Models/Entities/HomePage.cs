using Kelly.Models.Entities.Base;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kelly.Models.Entities
{
    [Table("HomePages")]
    public class HomePage : BaseEntitiy
    {

        public string? PageTitle { get; set; }
        public string? PageDescription { get; set; }
        public string? PageButtonTitle { get; set; }
        public string? PageButtonUrl { get; set; }
        [ValidateNever]
        public string? ImageUrl { get; set; }

    }
}

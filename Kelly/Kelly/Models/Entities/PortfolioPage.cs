using Kelly.Models.Entities.Base;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kelly.Models.Entities
{
    [Table("PortfolioPages")]
    public class PortfolioPage : BaseEntitiy
    {
        public string? PageTitle { get; set; }
        public string? PageDescription { get; set; }

        public virtual ICollection<PortfolioItem>? Items { get; set; } = new List<PortfolioItem>();
    }
}

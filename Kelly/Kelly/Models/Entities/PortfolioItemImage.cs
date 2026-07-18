using Kelly.Models.Entities.Base;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kelly.Models.Entities
{
    [Table("PortfolioItemImages")]
    public class PortfolioItemImage : BaseEntitiy
    {
        [ValidateNever]
        public string? ImageUrl { get; set; }
        public string? ImageAlt { get; set; }

        public Guid? PortfolioItemId { get; set; }
        [ForeignKey(nameof(PortfolioItemId))]
        public virtual PortfolioItem? Item { get; set; } = new PortfolioItem();
    }
}

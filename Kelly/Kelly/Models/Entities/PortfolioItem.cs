using Kelly.Models.Entities.Base;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kelly.Models.Entities
{
    [Table("PortfolioItems")]
    public class PortfolioItem : BaseEntitiy
    {

        [ValidateNever]
        public string? ImageUrl { get; set; }
        public string? Title { get; set; }

        public string? ProjectCategory { get; set; }
        public string? ProjectClient { get; set; }
        public DateOnly? ProjectDate { get; set; }
        public string? ProjectUrl { get; set; }
        public string? Description { get; set; }
        public string? EditorContent { get; set; }

        public virtual ICollection<PortfolioItemImage>? Images { get; set; } = new List<PortfolioItemImage>();
        
        public Guid? PortfolioPageId { get; set; }
        [ForeignKey(nameof(PortfolioPageId))]
        public virtual PortfolioPage? PortfolioPage { get; set; } = new PortfolioPage();
    }
}

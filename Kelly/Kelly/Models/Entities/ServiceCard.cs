using Kelly.Models.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kelly.Models.Entities
{
    [Table("ServiceCards")]
    public class ServiceCard : BaseEntitiy
    {
        public string? IconClass { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }

        public Guid? ServicePageId { get; set; }
        [ForeignKey(nameof(ServicePageId))]
        public virtual ServicePage? ServicePage { get; set; } = new ServicePage();
    }
}

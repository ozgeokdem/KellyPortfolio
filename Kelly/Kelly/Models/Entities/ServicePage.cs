using Kelly.Models.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kelly.Models.Entities
{
    [Table("ServicePages")]
    public class ServicePage : BaseEntitiy
    {
        public string? PageTitle { get; set; }
        public string? PageDescription { get; set; }

        public virtual ICollection<ServiceCard>? ServiceCards { get; set; } = new List<ServiceCard>();
    }
}

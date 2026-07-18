using Kelly.Models.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kelly.Models.Entities
{
    [Table("ResumeSumaries")]
    public class ResumeSumary :BaseEntitiy
    {
        public string? Title { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }

        public Guid? ResumePageId { get; set; }
        [ForeignKey(nameof(ResumePageId))]
        public virtual ResumePage? ResumePage { get; set; } = new ResumePage();
    }
}

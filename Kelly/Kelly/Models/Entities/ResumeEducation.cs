using Kelly.Models.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kelly.Models.Entities
{
    [Table("ResumeEducations")]
    public class ResumeEducation : BaseEntitiy
    {
        public string? Title { get; set; }
        public string? Degree { get; set; }
        public DateOnly StartYear { get; set; }
        public DateOnly EndYear { get; set; }
        public string? Institution { get; set; }
        public string? Description { get; set; }

        public Guid? ResumePageId { get; set; }
        [ForeignKey(nameof(ResumePageId))]
        public virtual ResumePage? ResumePage { get; set; } = new ResumePage();
    }
}

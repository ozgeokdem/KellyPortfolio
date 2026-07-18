using Kelly.Models.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kelly.Models.Entities
{
    [Table("ResumeExperiences")]
    public class ResumeExperience : BaseEntitiy
    {
        public string? Title { get; set; }
        public string? Position { get; set; }
        public DateOnly StartYear { get; set; }
        public DateOnly EndYear { get; set; }
        public string? Company { get; set; }
        public Guid? ResumePageId { get; set; }
        [ForeignKey(nameof(ResumePageId))]
        public virtual ResumePage? ResumePage { get; set; } = new ResumePage();

        public virtual ICollection<ResumeExperienceItem>? Items { get; set; } = new List<ResumeExperienceItem>();
    }
}

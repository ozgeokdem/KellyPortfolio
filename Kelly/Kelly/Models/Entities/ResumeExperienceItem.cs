using Kelly.Models.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kelly.Models.Entities
{
    [Table("ResumeExperienceItems")]
    public class ResumeExperienceItem : BaseEntitiy
    {
        public string? Responsibility { get; set; }

        public Guid? ResumeExperienceId { get; set; }
        [ForeignKey(nameof(ResumeExperienceId))]
        public virtual ResumeExperience? ResumeExperience { get; set; }
    }
}

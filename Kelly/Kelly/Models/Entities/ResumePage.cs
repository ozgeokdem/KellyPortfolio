using Kelly.Models.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kelly.Models.Entities
{
    [Table("ResumePages")]
    public class ResumePage : BaseEntitiy
    {
        public string? PageTitle { get; set; }
        public string? PageDescription { get; set; }
        
        public virtual ResumeSumary? Sumary { get; set; } 

        public virtual ICollection<ResumeEducation>? Educations { get; set; } = new List<ResumeEducation>();

        public virtual ICollection<ResumeExperience>? Experiences { get; set; } = new List<ResumeExperience>();

    }
}

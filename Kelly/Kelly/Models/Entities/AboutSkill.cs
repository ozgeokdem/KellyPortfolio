using Kelly.Models.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kelly.Models.Entities
{
    [Table("AboutSkills")]
    public class AboutSkill : BaseEntitiy
    {
        public string? Name { get; set; }
        public int? Percentage { get; set; }
    }
}

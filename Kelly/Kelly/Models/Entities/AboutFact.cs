using Kelly.Models.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kelly.Models.Entities
{
    [Table("AboutFacts")]
    public class AboutFact : BaseEntitiy
    {
        public string? Name { get; set; }
        public int? Number { get; set; } 
    }
}

using System.ComponentModel.DataAnnotations;

namespace Kelly.Models.Entities.Base
{
    public class BaseEntitiy
    {
        [Key]
        public Guid Id { get; set; }
    }
}

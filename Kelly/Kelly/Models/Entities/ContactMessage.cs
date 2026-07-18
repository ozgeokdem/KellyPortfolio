using Kelly.Models.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kelly.Models.Entities
{
    [Table("ContactMessages")]
    public class ContactMessage : BaseEntitiy
    {
        public string? YourName { get; set; }
        public string? Email { get; set; }
        public string? Subject { get; set; }
        public string? Message { get; set; }
        public DateTimeOffset? SendDate { get; set; }
        public bool IsReaded { get; set; }
    }
}

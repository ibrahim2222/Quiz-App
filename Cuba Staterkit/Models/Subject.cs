using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cuba_Staterkit.Models
{
    [Table("SubjectTable")]
    public class Subject
    {
        [Key]
        public Guid ID { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual IEnumerable<Session>? sessions { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Cuba_Staterkit.Models
{
    public class HomeWork
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [ForeignKey(nameof(Session))]
        public Guid? SessionID { get; set; }
        public virtual Session? Session { get; set; }
        public virtual IEnumerable<Question>? Questions { get; set; }
    }
}

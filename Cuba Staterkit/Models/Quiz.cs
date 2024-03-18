using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cuba_Staterkit.Models
{
    public class Quiz
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }

        public string GradeLvl { get; set; }

        [ForeignKey(nameof(Session))]
        public Guid? SessionID { get; set; }
        public virtual Session? Session { get; set; }
        public virtual IEnumerable<Question>? Questions { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cuba_Staterkit.Models
{
    [Table("SessionTable")]
    public class Session
    {
        [Key]
        public Guid ID { get; set; }
        [Required]
        public string Name { get; set; }
        public int SessionNumber { get; set; }
        //public DateTime CreatedAt { get; set; }
        public string GradeLvl { get; set; }

        [ForeignKey(nameof(Subject))]
        public Guid? SubjectID { get; set; }
        public virtual Subject? Subject { get; set; }
        public virtual Quiz? quiz { get; set; }
        public virtual HomeWork? homework { get; set; }


    }
}

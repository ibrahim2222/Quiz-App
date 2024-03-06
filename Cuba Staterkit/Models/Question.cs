using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cuba_Staterkit.Models
{
    public enum Questiontype
    {
        String , Img
    }
    public class Question
    {
        [Key]
        public Guid ID { get; set; }
        public string? Body { get; set; }
        public string? ImgUrl { get; set; }
        public string? Answers { get; set; }
        public string? AnswersURL { get; set; }
        public string? CorrectAnswerUrl { get; set; }
        [Required]
        public string CorrectAnswer { get; set; }
        public double Mark { get; set; } = 1.0;
        public string VersionID { get; set; } 
        [Required]
        public Questiontype QuestionType { get; set; }
        [Required]
        public Questiontype AnswerType { get; set; }
        [ForeignKey(nameof(Quiz))]
        public Guid? QuizID { get; set; }
        public virtual Quiz? Quiz{ get; set; }
        [ForeignKey(nameof(HomeWork))]
        public Guid? HomeWorkID { get; set; }
        public virtual HomeWork? HomeWork { get; set; }
    }
}

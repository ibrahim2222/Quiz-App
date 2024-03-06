namespace Cuba_Staterkit.Models
{
    public class QuestionHomeworkViewModel
    {
        public string Body { get; set; }
        public string ImgUrl { get; set; }
        public List<string> Answers { get; set; }
        public string CorrectAnswer { get; set; }
        public string HomeworkId { get; set; }
        public string VersionID { get; set; }
    }
}

using Cuba_Staterkit.Models;

namespace Cuba_Staterkit.RepoServices
{
    public interface IQuiz
    {
        public List<Quiz> GetAll();
        public Quiz GetQuiznById(int id);
        public void InsertQuiz(Quiz quiz);
        public void UpdateQuiz(int id, Quiz quiz);
        public void DeleteQuiz(int id);
        public bool QuizQuestionsExist(Guid id);
        public void ChangeQuizName(string quizName, string quizId);
    }
}

using Cuba_Staterkit.Data;
using Cuba_Staterkit.Models;
using Microsoft.EntityFrameworkCore;

namespace Cuba_Staterkit.RepoServices
{
    public class QuizRepoService : IQuiz
    {
        public Context Context { get; }
        public QuizRepoService(Context context)
        {
            Context = context;
        }
        public List<Quiz> GetAll()
        {
            return Context.Quizes.Include(q => q.Session).Include(q => q.Questions).ToList();
        }


        public Quiz GetQuiznById(int id)
        {
            throw new NotImplementedException();
        }

        public bool QuizQuestionsExist(Guid id)
        {
            bool quizExists = Context.Questions.Any(q => q.QuizID == id);
            return quizExists;
        }
        public Session GetSessionByNumber(int Id)
        {
            Session? session = Context.Sessions.FirstOrDefault(s => s.SessionNumber == Id);
            return session;
        }
        public void InsertQuiz(Quiz quiz)
        {
            Context.Quizes.Add(quiz);
            Context.SaveChanges();
        }

        public void UpdateQuiz(int id, Quiz quiz)
        {
            
        }

        public void DeleteQuiz(int id)
        {
            
        }

        public void ChangeQuizName(string quizName, string quizId)
        {
            Quiz? quiz = Context.Quizes.FirstOrDefault(q => q.Id == new Guid(quizId));
            if (quiz != null)
            {
                quiz.Name = quizName;
                Context.SaveChanges();
            }
        }
    }
}

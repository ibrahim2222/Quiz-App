using Cuba_Staterkit.Data;
using Cuba_Staterkit.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Cuba_Staterkit.RepoServices
{
    public class QuestionRepoService : IQuestion
    {
        public Context Context { get; }
        public QuestionRepoService(Context context)
        {
            Context = context;
        }
        public List<Question> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Question> GetQuestionById(string id)
        {
            List<Question> questions = Context.Questions
                .Where(q => q.QuizID.ToString() == id)
                .ToList();

            return questions;
        }



        public void InsertQuestion(Question question)
        {
            Context.Questions.Add(question);
            Context.SaveChanges();
        }
        public void InsertQuestions(List<Question> questions)
        {
            foreach (Question question in questions)
            {
                Context.Questions.Add(question);
                Context.SaveChanges();
            }
        }

        public void UpdateQuestion(int id, Question question)
        {
            throw new NotImplementedException();
        }

        public void DeleteQuestion(Guid id)
        {
            Question question = Context.Questions.FirstOrDefault(q => q.ID == id);
            Context.Questions.Remove(question);
            Context.SaveChanges();
        }
    }
}

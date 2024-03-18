using Cuba_Staterkit.Data;
using Cuba_Staterkit.Models;
using Microsoft.EntityFrameworkCore;

namespace Cuba_Staterkit.RepoServices
{
    public class SessionRepoService : IClassSession
    {
        public Context Context { get; }
        public SessionRepoService(Context context)
        {
            Context = context;
        }

        public List<Session> GetAll()
        {
            return Context.Sessions.Include(q => q.quiz).ToList();
        }
        public Session GetSessionById(int id)
        {
            throw new NotImplementedException();
        }
        public bool SessionExists(int Id, string GradeLvl)
        {
            Session? session = GetSessionByNumber(Id,GradeLvl);
            return session != null ? true : false;
        }
        public Session GetSessionByNumber(int Id,string GradeLvl)
        {
            Session? session = Context.Sessions.FirstOrDefault(s => s.SessionNumber == Id && s.GradeLvl == GradeLvl);
            return session;
        }
        public Session? GetSessionByName(string name)
        {
            Session? session = Context.Sessions.FirstOrDefault(s => s.Name == name);
            return session;
        }
        public void InsertSession(Session session)
        {
            Context.Sessions.Add(session);
            Context.SaveChanges();
        }
        public void UpdateSession(int id, Session session)
        {

        }
        /* public void DeleteSession(Guid Id)
         {
             Session sessionToDelete = Context.Sessions.Find(Id);
             if (sessionToDelete != null)
             {
                 Context.Sessions.Remove(sessionToDelete);
                 Context.SaveChanges();
             }

         }*/

        public void DeleteSession(Guid Id)
        {
            Session session = Context.Sessions.Find(Id);

            if (session != null)
            {
                var quizzes = Context.Quizes.Where(Q => Q.Session.ID == Id).ToList();

                foreach (var quiz in quizzes)
                {
                    var questions = Context.Questions.Where(Q => Q.QuizID == quiz.Id).ToList();

                    foreach (var question in questions)
                    {
                        Context.Questions.Remove(question);
                    }

                    Context.Quizes.Remove(quiz);
                }

                Context.Sessions.Remove(session);

                Context.SaveChanges();
            }

        }

        public int GetLastSessionNumber(string GradeNum)
        {
            var lastSession = Context.Sessions.Where(G=>G.GradeLvl == GradeNum).OrderByDescending(s => s.SessionNumber).FirstOrDefault();

            if (lastSession != null)
            {
                return lastSession.SessionNumber;
            }
            else
            {
               
                return 0;
            }
        }


        public void ChangeSessionName(int SessionName, string SessionId)
        {
            Session? session = Context.Sessions.FirstOrDefault(q => q.ID == new Guid(SessionId));
            if (session != null)
            {
                session.SessionNumber = SessionName;
                Context.SaveChanges();
            }
        }


    }
}

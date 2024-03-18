using Cuba_Staterkit.Models;

namespace Cuba_Staterkit.RepoServices
{
    public interface ISession
    {
        public List<Session> GetAll();
        public Session GetSessionById(int id);
        public void InsertSession(Session session);
        public void UpdateSession(int id, Session session);
        public void DeleteSession(int id);


    }
}

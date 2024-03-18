using Cuba_Staterkit.Models;

namespace Cuba_Staterkit.RepoServices
{
    public interface IClassSession
    {
        public List<Session> GetAll();
        public Session GetSessionById(int id);
        public Session GetSessionByName(string name);
        public Session GetSessionByNumber(int Id, string GradeLvl);
        public int GetLastSessionNumber(string GradeNum);
        public bool SessionExists(int Id, string GradeLvl);
        public void InsertSession(Session session);
        public void UpdateSession(int id, Session session);
        public void DeleteSession(Guid id);

        public void ChangeSessionName(int SessionName, string SessionId);

    }
}

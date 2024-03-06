using Cuba_Staterkit.Models;

namespace Cuba_Staterkit.RepoServices
{
    public interface ISubject
    {
        public List<Subject> GetAll();
        public Subject GetSubjectById(int id);
        public void InsertSubject(Subject subject);
        public void UpdateSubject(int id, Subject subject);
        public void DeleteSubject(int id);
    }
}

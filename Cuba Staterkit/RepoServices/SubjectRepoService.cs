using Cuba_Staterkit.Data;
using Cuba_Staterkit.Models;

namespace Cuba_Staterkit.RepoServices
{
    public class SubjectRepoService : ISubject
    {

        public Context Context { get; }
        public SubjectRepoService(Context context)
        {
            Context = context;
        }
        public List<Subject> GetAll()
        {
            throw new NotImplementedException();
        }

        public Subject GetSubjectById(int id)
        {
            throw new NotImplementedException();
        }

        public void InsertSubject(Subject subject)
        {
            
        }

        public void UpdateSubject(int id, Subject subject)
        {
            
        }

        public void DeleteSubject(int id)
        {
            
        }
    }
}

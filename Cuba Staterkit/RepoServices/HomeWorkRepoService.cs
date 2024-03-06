using Cuba_Staterkit.Data;
using Cuba_Staterkit.Models;
using Microsoft.EntityFrameworkCore;

namespace Cuba_Staterkit.RepoServices
{
    public class HomeWorkRepoService : IHomeWork
    {
        public Context Context { get; }
        public HomeWorkRepoService(Context context)
        {
            Context = context;
        }
        public List<HomeWork> GetAll()
        {
            return Context.HomeWorks.Include(h => h.Session).ToList();
        }

        public HomeWork GetHomeWorkById(int id)
        {
            throw new NotImplementedException();
        }

        public void InsertHomeWork(HomeWork homework)
        {
            Context.HomeWorks.Add(homework);
            Context.SaveChanges();
        }

        public void UpdateHomeWork(int id, HomeWork homework)
        {
            
        }

        public void DeleteHomeWork(int id)
        {
            
        }
    }
}

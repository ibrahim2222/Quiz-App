using Cuba_Staterkit.Models;

namespace Cuba_Staterkit.RepoServices
{
    public interface IHomeWork
    {
        public List<HomeWork> GetAll();
        public HomeWork GetHomeWorkById(int id);
        public void InsertHomeWork(HomeWork homework);
        public void UpdateHomeWork(int id, HomeWork homework);
        public void DeleteHomeWork(int id);
    }
}

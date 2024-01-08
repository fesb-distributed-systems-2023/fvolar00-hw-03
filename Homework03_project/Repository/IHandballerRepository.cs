using Homework03_project.Domain;

namespace Homework03_project.Repository
{
    public interface IHandballerRepository
    {
        public void CreatePlayer(Handballer player);
        public bool UpdatePlayer(int id, string name);
        public IEnumerable<Handballer> GetAllPlayers();
        public Handballer GetPlayer(int id);
        public bool DeletePlayer(int id);
    }
}

using Homework03_project.Domain;

namespace Homework03_project.Logic
{
    public interface IHandballerLogic
    {
        public void CreatePlayer(Handballer player);
        public void UpdatePlayer(int id, string name);
        public List<Handballer> GetAllPlayers();
        public Handballer GetPlayer(int id);
        public void DeletePlayer(int id);
    }
}

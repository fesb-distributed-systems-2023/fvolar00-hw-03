using Homework03_project.Domain;
using Homework03_project.Repository;

namespace Homework03_project.Repository
{
    public class HandballerRepository : IHandballerRepository
    {

        private static List<Handballer> _players = new List<Handballer>();

        public HandballerRepository()
        {
            
        }
        public void CreatePlayer(Handballer player)
        {
            _players.Add(player);
        }

        public bool DeletePlayer(int id)
        {
            var playerToDelete = _players.FirstOrDefault(a => a.Id == id);
            if (playerToDelete == null)
            {
                return false;
            }
            else
            {
                _players.Remove(playerToDelete);
                return true;
            }
        }

        public IEnumerable<Handballer> GetAllPlayers()
        {
            return _players;
        }

        public Handballer GetPlayer(int id)
        {
            var player = _players.FirstOrDefault(a => a.Id == id);
            if(player == null)
            {
                return null;
            }
            return player;
        }

        public bool UpdatePlayer(int id, string name)
        {
            var playerToUpdate = _players.FirstOrDefault(a => a.Id == id);
            if(playerToUpdate != null)
            {
                playerToUpdate.Name = name;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

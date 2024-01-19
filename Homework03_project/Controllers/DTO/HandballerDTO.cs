using Homework03_project.Domain;
using System.Xml.Linq;

namespace Homework03_project.Controllers.DTO
{
    public class HandballerDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Dob { get; set; }
        public string? Position { get; set; }
        public string? Club { get; set; }
        public string? Nationality { get; set; }

        public static HandballerDTO FromModel(Handballer handballer)
        {
            var hand = new HandballerDTO
            {
                Id = handballer.Id,
                Name = handballer.Name,
                Dob = handballer.Dob,
                Position = handballer.Position,
                Club = handballer.Club,
                Nationality = handballer.Nationality
            };
            return hand;           
        }

        public Handballer ToModel()
        {
            var player = new Handballer
            {
                Id = Id,
                Name = Name,
                Dob = Dob,
                Position = Position,
                Club = Club,
                Nationality = Nationality
            };
            return player;
        }
    }
}

using Homework03_project.Domain;
using Homework03_project.Exceptions;
using Homework03_project.Repository;
using System.Text.RegularExpressions;

namespace Homework03_project.Logic
{
    public class HandballerLogic : IHandballerLogic
    {
        private readonly IHandballerRepository _handballerRepository;
        public const int _NameMaxChar = 50;
        public int[] _AgeLimit = { 16, 100 };
        private static readonly Regex _DateRegex = new Regex(@"^(0[1-9]|[12][0-9]|3[01])\.(0[1-9]|1[0-2])\.\d{4}$");

        public HandballerLogic(IHandballerRepository handballerRepository)
        {
            _handballerRepository = handballerRepository;
        }

        private void ValidateNameField(string? name)
        {
            if (name == null)
            {
                throw new LogicException("Name of university cannot be empty");
            }

            if (name.Length > _NameMaxChar)
            {
                throw new LogicException($"Name of university is too long. Exceeded {_NameMaxChar} characters");
            }
        }

        private void ValidateDobField(string? dob)
        {           
            if (dob == null)
            {
                throw new LogicException("Date of birth cannot be empty");
            }

            if (!_DateRegex.IsMatch(dob))
            {
                throw new LogicException("Invalid format of birth date");
            }

            int yearOfBirth = Int32.Parse(dob.Split('.')[2]);
            int currentYear = DateTime.Now.Year;
            int age = currentYear - yearOfBirth;

            if (age < _AgeLimit[0])
            {
                throw new LogicException("Player is too young.");
            }

            if (age > _AgeLimit[1])
            {
                throw new LogicException("Player is too old.");
            }
        }

        public void ValidatePositionField(string? position)
        {
            if (position != "LW" && position != "LB" && position != "CB" && position != "RB" && position != "RW" && position != "CF")
            {
                throw new LogicException("Position doesn't exist.");
            }
        }

        public void CreatePlayer(Handballer player)
        {
            if (player == null)
            {
                throw new LogicException("Player not specified");
            }

            ValidateNameField(player.Name);
            ValidateDobField(player.Dob);
            ValidatePositionField(player.Position);

            _handballerRepository.CreatePlayer(player);
        }

        public void DeletePlayer(int id)
        {
            _handballerRepository?.DeletePlayer(id);
        }

        public List<Handballer> GetAllPlayers()
        {
            return _handballerRepository.GetAllPlayers();
        }

        public Handballer GetPlayer(int id)
        {
            return _handballerRepository.GetPlayer(id);
        }

        public void UpdatePlayer(int id, string name)
        {
            if(id == null)
            {
                throw new LogicException("ID cannot be null");
            }

            ValidateNameField(name);

            _handballerRepository.UpdatePlayer(id, name);
        }
    }
}

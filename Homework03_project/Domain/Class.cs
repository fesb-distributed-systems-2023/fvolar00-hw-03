namespace Homework03_project.Domain
{
    public class Handballer
    {
        private int Id { get; }
        private string Name { get; }
        private string Dob { get; }
        private string Position { get; }
        private string Club { get; }
        private string Nationality { get; }

        public Handballer(
        int id,
        string name,
        string dob,
        string position,
        string club,
        string nationality)
        {
            Id = id;
            Name = name;
            Dob = dob;
            Position = position;
            Club = club;
            Nationality = nationality;
        }
    }
}

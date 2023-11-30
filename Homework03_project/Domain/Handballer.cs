namespace Homework03_project.Domain
{
    public class Handballer
    {
        public int Id { get; }
        public string Name { get; set; }
        public string Dob { get; }
        public string Position { get; }
        public string Club { get; }
        public string Nationality { get; }

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

using Homework03_project.Domain;
using Microsoft.Data.Sqlite;
using System.Xml.Linq;

namespace Homework03_project.Repository
{
    public class HandballerRepository_SQL : IHandballerRepository
    {

        private readonly string _connectionString = "Data Source = C:\\Users\\Filip\\OneDrive - Fakultet elektrotehnike, strojarstva i brodogradnje\\Desktop\\Materijali\\DIS\\fvolar00-hw-03\\Homework03_project\\SQL\\database.db";

        public void CreatePlayer(Handballer player)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText =
            @$"
                INSERT INTO Players (Name, Dob, Nationality, Position, Club)
                VALUES ($name, $dob, $nationality, $position, $club)";

            command.Parameters.AddWithValue("$name", player.Name);
            command.Parameters.AddWithValue("$dob", player.Dob);
            command.Parameters.AddWithValue("$nationality", player.Nationality);
            command.Parameters.AddWithValue("$position", player.Position);
            command.Parameters.AddWithValue("$club", player.Club);

            int rowsAffected = command.ExecuteNonQuery();

            if (rowsAffected < 1)
            {
                throw new ArgumentException("Could not insert player into database.");
            }
        }

        public void DeletePlayer(int id)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText =
            @"
                DELETE FROM Players
                WHERE ID == $id";

            command.Parameters.AddWithValue("$id", id);

            int rowsAffected = command.ExecuteNonQuery();

            if (rowsAffected < 1)
            {
                throw new ArgumentException($"Player with that ID doesn't exist");
            }
        }

        public List<Handballer> GetAllPlayers()
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText =
            @"SELECT ID, Name, Dob, Nationality, Position, Club FROM Players";

            using var reader = command.ExecuteReader();

            var results = new List<Handballer>();
            while (reader.Read())
            {

                var row = new Handballer
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Dob = reader.GetString(2),
                    Nationality = reader.GetString(4),
                    Position = reader.GetString(5),
                    Club = reader.GetString(3)
                };

                results.Add(row);
            }

            return results;
        }

        public Handballer GetPlayer(int id)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText =
            @"SELECT ID, Name, Dob, Nationality, Position, Club FROM Players WHERE ID == $id";

            command.Parameters.AddWithValue("$id", id);

            using var reader = command.ExecuteReader();

            Handballer result = null;

            if (reader.Read())
            {
                result = new Handballer
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Dob = reader.GetString(2),
                    Nationality = reader.GetString(4),
                    Position = reader.GetString(5),
                    Club = reader.GetString(3)
                };
            }

            return result;
        }

        public void UpdatePlayer(int id, string name)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText =
            @"
                UPDATE Players
                SET
                    Name = $name               
                WHERE
                    ID == $id";

            command.Parameters.AddWithValue("$name", name);
            command.Parameters.AddWithValue("$id", id);

            int rowsAffected = command.ExecuteNonQuery();

            if (rowsAffected < 1)
            {
                throw new ArgumentException($"Player failed to update");
            }
        }
    }
}


using BakkerijLimited.Models;
using BakkerijLimited.DAO;
using Microsoft.Data.SqlClient;

namespace BakkerijLimited.DAO
{
    public class KlantenDAO : IKlantenDAO
    {
        public Klant Create(Klant klant)
        {
            using var conn = new SqlConnection(DatabaseConfig.ConnectionString);
            conn.Open();

            var cmd = new SqlCommand(
                "INSERT INTO Klanten (Naam) OUTPUT INSERTED.KlantId VALUES (@Naam)",
                conn);

            cmd.Parameters.AddWithValue("@Naam", klant.Naam);
            klant.KlantId = (int)cmd.ExecuteScalar();
            return klant;
        }
    
        public Klant? GetById(int id)
        {
            using var conn = new SqlConnection(DatabaseConfig.ConnectionString);
            conn.Open();

            var cmd = new SqlCommand(
                "SELECT KlantId, Naam FROM Klanten WHERE KlantId = @Id",
                conn);

            cmd.Parameters.AddWithValue("@Id", id);
            using var reader = cmd.ExecuteReader();

            if (!reader.Read()) return null;

            return new Klant(reader.GetString(1)) { KlantId = reader.GetInt32(0) };
        }

        public Klant? GetByNaam(string naam)
        {
            using var conn = new SqlConnection(DatabaseConfig.ConnectionString);
            conn.Open();

            var cmd = new SqlCommand(
                "SELECT KlantId, Naam FROM Klanten WHERE Naam = @Naam",
                conn);

            cmd.Parameters.AddWithValue("@Naam", naam);
            using var reader = cmd.ExecuteReader();

            if (!reader.Read()) return null;

            return new Klant(reader.GetString(1)) { KlantId = reader.GetInt32(0) };
        }

    }
}

using BakkerijLimited.DAO;
using BakkerijLimited.Models;
using Microsoft.Data.SqlClient;

namespace BakkerijLimited.DAO
{
    // Houdt de gegevens van een klantenkaart bij in de database
    // REQ0006 – Bakkerij kan een nieuwe klantenkaart aanmaken
    // REQ0004 – Bakkerij kan nagaan of klantenkaart met bepaald nummer bestaat en opzoeken
    public class KlantenkaartenDAO : IKlantenkaartenDAO
    {
        // REQ0006 – Bakkerij kan een nieuwe klantenkaart aanmaken
        // Input:
        //      - klant: het klant object waarvoor een klantenkaart wordt aangemaakt
        // Output:
        //      - het aangemaakte klantenkaart object met uniek nummer
        public Klantenkaart Create(Klant klant)
        {
            using var conn = new SqlConnection(DatabaseConfig.ConnectionString);
            conn.Open();

            var cmd = new SqlCommand(
                "INSERT INTO Klantenkaarten (KlantId, AantalBroden) " +
                "OUTPUT INSERTED.KlantenkaartNummer " +
                "VALUES (@KlantId, 0)", conn);

            cmd.Parameters.AddWithValue("@KlantId", klant.KlantId);

            int nummer = (int)cmd.ExecuteScalar();
            return new Klantenkaart(nummer, klant);
        }

        // REQ0004 – Bakkerij kan nagaan of klantenkaart met bepaald nummer bestaat en opzoeken
        // Input:
        //      - nummer: het unieke nummer van de klantenkaart
        // Output:
        //      - het klantenkaart object indien gevonden, anders null
        public Klantenkaart? GetByNummer(int nummer)
        {
            using var conn = new SqlConnection(DatabaseConfig.ConnectionString);
            conn.Open();

            var cmd = new SqlCommand(
                "SELECT kk.KlantenkaartNummer, kk.AantalBroden, " +
                "       k.KlantId, k.Naam " +
                "FROM Klantenkaarten kk " +
                "JOIN Klanten k ON kk.KlantId = k.KlantId " +
                "WHERE kk.KlantenkaartNummer = @Nr",
                conn);

            cmd.Parameters.AddWithValue("@Nr", nummer);
            using var reader = cmd.ExecuteReader();

            if (!reader.Read()) return null;

            // Klant object obv de opgehaalde gegevens maken
            Klant klant = new Klant(reader.GetString(3));
            klant.KlantId = reader.GetInt32(2);

            // Klantenkaart object obv de opgehaalde gegevens maken
            Klantenkaart kaart = new Klantenkaart(reader.GetInt32(0), klant);
            kaart.AantalBroden = reader.GetInt32(1);

            return kaart;
        }

        // REQ0009 – De bakkerij kan het bestelde aantal broden aan de voorgelegde klantenkaart toevoegen
        // REQ0012 – De bakkerij kan de korting berekenen (11de brood gratis na aankoop van 10 broden) 
        //           en de klantenkaart bijwerken door de aangekochte broden correct te verminderen
        // Input:
        //      - kaart: de kaart met gewijzigd aantal broden
        // Output:
        //      -
        public void Update(Klantenkaart kaart)
        {
            using var conn = new SqlConnection(DatabaseConfig.ConnectionString);
            conn.Open();

            var cmd = new SqlCommand(
                "UPDATE Klantenkaarten SET AantalBroden = @Aantal " +
                "WHERE KlantenkaartNummer = @Nummer", conn);

            cmd.Parameters.AddWithValue("@Aantal", kaart.AantalBroden);
            cmd.Parameters.AddWithValue("@Nummer", kaart.KlantenkaartNummer);
            cmd.ExecuteNonQuery();
        }
    }
}

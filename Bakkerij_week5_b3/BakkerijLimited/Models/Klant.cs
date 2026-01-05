namespace BakkerijLimited.Models
{
    // Houdt de gegevens van een klant bij
    // REQ0019 De bakkerij kan een nieuwe klant registreren
    // REQ0020 De bakkerij kan een klant zoeken en selecteren aan de hand van de KlantId
    public class Klant
    {
        public int KlantId { get; set; }
        public String Naam { get; set; }

        public Klant(string naam)
        {
            Naam = naam;
        }
    }
}

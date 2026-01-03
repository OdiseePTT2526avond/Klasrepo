namespace BakkerijLimited.Models
{
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

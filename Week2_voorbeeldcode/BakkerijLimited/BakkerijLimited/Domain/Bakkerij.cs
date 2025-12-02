using BakkerijLimited.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakkerijLimited.Domain
{
    // REQ0001 Klant kan een bestelling voor een aantal broden aanmaken   
    public class Bakkerij
    {
        // REQ0008 – De Bakkerij houdt de bestelling in uitvoering bij.
        public Bestelling? BestellingInUitvoering { get; private set; }

        private KlantenkaartenRepo _klantenkaartenRepo;

        // REQ0008 – De Bakkerij houdt de geselecteerde klantenkaart bij.
        public Klantenkaart? GeselecteerdeKlantenkaart { get; private set; }

        // Instance variable voor de huidige klant (setter beschikbaar)
        public Klant? Klant { get; set; }

        public static Brood WitBrood = new Brood("Wit brood", 3.50m);
        public static Brood BruinBrood = new Brood("Bruin brood", 3.50m);

        public Bakkerij()
        {
            // REQ0001
            BestellingInUitvoering = null;
            // REQ0002
            _klantenkaartenRepo = new KlantenkaartenRepo();
            GeselecteerdeKlantenkaart = null;
        }

        // REQ0001 Klant kan een bestelling voor een aantal broden aanmaken
        public void MaakBestelling(Klant klant, Brood broodType, int aantal)
        {
            BestellingInUitvoering = new Bestelling(klant, broodType, aantal);
        }

        // REQ0006 – De Bakkerij kan een nieuwe klantenkaart aanmaken via de repo.
        // Vereist: property `Klant` is ingesteld vóór aanroepen.
        public Klantenkaart MaakKlantenkaart()
        {
            if (Klant is null)
            {
                throw new InvalidOperationException("Er is geen Klant ingesteld op de bakkerij.");
            }

            GeselecteerdeKlantenkaart = _klantenkaartenRepo.AddKlantenkaart(Klant);
            return GeselecteerdeKlantenkaart;
        }

        /// REQ0004 – Zoekt een klantenkaart op nummer via de repo.
        public Klantenkaart? ZoekEnSelecteerKlantenkaart(int klantenkaartNummer)
        {
            var gevonden = _klantenkaartenRepo.ZoekOpNummer(klantenkaartNummer);
            GeselecteerdeKlantenkaart = gevonden;
            return gevonden;
        }
    }
}

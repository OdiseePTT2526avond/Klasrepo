using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakkerijLimited.Models
{
    public class Klantenkaart
    {
        public int KlantenkaartNummer { get; private set; }
        public Klant Klant { get; private set; }
        public int AantalBroden { get; private set; }

        public Klantenkaart(int klantenkaartNummer, Klant klant)
        {
            KlantenkaartNummer = klantenkaartNummer;
            Klant = klant;
            AantalBroden = 0;
        }
        public void voegBrodenToe(int aantal) 
        {
            //TODO
        }



    }
}

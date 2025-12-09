namespace Verschilrijen
{
    /// <summary>
    /// SIMPELE RIJ
    /// Stelt een verschilrij voor voor req 1->5 en heeft dus enkel 3 of 4 elementen.
    /// Voor req06 met meer elementen zie het andere Oplossing2 project.
    /// </summary>
    public class Rij
    {
        /// Req01
        private readonly int element0;
        private readonly int element1;
        private readonly int element2;
        private readonly int element3; // REq03

        private readonly int aantalElementen; // req03
        // Of, veel beter, je maakt een array of een list van ints welke de elementen opslaagd

        public Rij(params int[] args)
        {
            aantalElementen = args.Length; // req03
            element0 = args[0];
            element1 = args[1];
            element2 = args[2];
            if (aantalElementen > 3) element3 = args[3];// req03
            else element3 = 0;
        }

        /// <summary>
        /// Test of alle elementen 0 zijn
        /// </summary>
        /// <returns>true als alle elementen 0 zijn</returns>
        public bool IsNul()
        {
            //return element0 == 0; //implementatie na test GivenNulRij_nulRij_ReturnsTrue
            //return element0 == 0 && element1 == 0 && element2 == 0;  //implementatie na test GivenRij001_nulRij_ReturnsFalse
            return element0 == 0 && element1 == 0 && element2 == 0 && element3 == 0;  //implementatie na test GivenNulRij4_isNul_ReturnsTrue
        }

        /// <summary>
        /// Stelt de getallen voor als een string
        /// </summary>
        /// <returns>de getallen op volgorde omgeven door {} gescheiden door een komma</returns>
        public override string ToString()
        {
            string str = "{" +
                    element0 + ","
                    + element1 + ","
                    + element2;
            if (aantalElementen > 3) str += "," + element3;
            return str + '}';
        }

        /// <summary>
        /// Test dat 2 Rijen identiek zijn => elk overeenkomstig element is identiek.
        /// implementation bij req04 
        /// Nota: het is zelden een goed idee om code te maken om testen gemakkelijker te maken. In dit geval kan je toString gebruiken om gelijkheid te testen. 
        /// Voor requirements 14 en 15 te implementeren willen we wellicht toch een Equals hulpmethode maken. Software engineering is een kunst, geen exacte wetenschap...
        /// </summary>
        /*public override bool Equals(object o)
        {
            if (this == o) return true;
            if (o == null || GetType() != o.GetType()) return false;

            Rij rij = (Rij)o;
            return aantalElementen == rij.aantalElementen && element0 == rij.element0 && element1 == rij.element1 && element2 == rij.element2 && element3 == rij.element3;
        }*/


        /// <summary>
        /// Berekent het kind van de verschilrij.
        /// </summary>
        /// <returns>Rij de kindrij</returns>
        public Rij BerekenKindRij()
        {
            if (aantalElementen == 3) return new Rij(Math.Abs(element0 - element2), Math.Abs(element1 - element0), Math.Abs(element2 - element1));
            else return new Rij(Math.Abs(element0 - element3), Math.Abs(element1 - element0), Math.Abs(element2 - element1), Math.Abs(element3 - element2));
        }
    }
}

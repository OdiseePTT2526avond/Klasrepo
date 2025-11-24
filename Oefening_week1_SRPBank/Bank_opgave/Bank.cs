namespace Bank_opgave
{
    public class Bank
    {
        /// De index in de arrays met de data.  RekeningIndex = De rekening waar we nu in werken.
        public static int RekeningIndex = 0;
        public static int[] RekeningNummers = { 1, 2, 666 };  //maybe I should use a list?
        public static string[] RekeningNamen = { "me", "myself", "Geeraard" };
        public static double[] RekeningBalansen = { 100.0, 0.0, 666.0 };

        /// Verzet de active rekening door de RekeningIndex aan te passen
        /// @param index  de index van de active rekening
        public void SetRekeningIndex(int index)
        {
            if (index >= RekeningNummers.Length) Console.WriteLine("Rekening bestaat niet");
            else RekeningIndex = index;
        }

        /// wijzig de actieve rekening: we kunnen afhalen of storten
        /// @param type  "afhalen" of "storten"
        /// @param bedrag het bedrag om af te halen of te storten
        public void RekeningVerrichting(string type, double bedrag)
        {
            if (RekeningIndex >= RekeningNummers.Length) Console.WriteLine("Rekening bestaat niet"); //Hebben we een rekening geselecteerd?
            if (type.Equals("afhalen"))
            {
                if (RekeningBalansen[RekeningIndex] < bedrag)
                {
                    Console.WriteLine("Te weinig op rekening");
                }
                else
                {
                    RekeningBalansen[RekeningIndex] -= bedrag;
                }
            }
            else if (type.Equals("storten"))
            {
                RekeningBalansen[RekeningIndex] += bedrag;
            }
        }

        /// Vind alle rekeningen met eenzelfde naam
        public static int[] VindDubbeleRekeningenBijNaam()
        {
            // TODO : implement. What data do we need for that?
            return [];
        }
    }
}
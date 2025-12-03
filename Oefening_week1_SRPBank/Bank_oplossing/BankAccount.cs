
namespace Bank_oplossing
{
 
    public class BankAccount
    {
        public string Naam { get; }
        public double Balans { get; private set; }
        public int Nummer { get;  }

        public BankAccount(string naam, double balans, int nummer)
        {
            Naam = naam;
            Balans = balans;
            Nummer = nummer;
        }

        public BankAccount(string naam, int nummer)
        {
            Naam = naam;
            Nummer = nummer;
            Balans = 0;
        }

        ///
         /// @param bedrag bij te voegen bedrag
        public void Storten(double bedrag)
        {
            Balans += bedrag;
        }

         /// @param bedrag af te trekken bedrag
         /// @return was de transacttie succesvol geregistreerd?
        public bool Afhalen(double bedrag)
        {
            if (Balans < bedrag)
            {
                return false;
            }
            else
            {
                Balans -= bedrag;
                return true;
            }
        }

        public override string ToString()
        {
            return $"BankAccount{{naam='{Naam}', bedrag={Balans}, nummer={Nummer}}}";
        }
    }
}
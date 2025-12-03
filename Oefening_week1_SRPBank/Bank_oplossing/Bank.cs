
namespace Bank_oplossing
{
    public class Bank
    {

         /// The bank accounts.
        private readonly List<BankAccount> bankAccounts = new();


        /// Adds a bank account.
        public void VoegAccountToe(string naam, double balans, int nummer)
        {
            bankAccounts.Add(new BankAccount(naam, balans, nummer));
        }

        public void VoegAccountToe(string naam, int nummer)
        {
            bankAccounts.Add(new BankAccount(naam, nummer));
        }

         /// Zoek het bankaccount
         /// @param nummer bank account number
         /// @return bank account
         /// @throws IllegalArgumentException Bij Onbekend nummer
        private BankAccount ZoekBankAccount(int nummer)
        {
            foreach (BankAccount ba in bankAccounts)
            {
                if (ba.Nummer == nummer)
                {
                    return ba;
                }
            }
            throw new ArgumentException($"Onbekend bankaccount met nummer {nummer}");
        }

        public void PrintRekeningen()
        {
            Console.WriteLine($"Aantal rekeningen: {bankAccounts.Count}");
            foreach (var ba in bankAccounts)
            {
                Console.WriteLine(ba.ToString());
            }
        }
        /// Berkent een geformateerde string van alle bankaccounts
        /// @returns geformateerde string 
        public override string ToString()
        {
            return $"Aantal rekeningen: {bankAccounts.Count}\n" + string.Join(",\n", bankAccounts);
        }


        public void Stort(int rekeningNummer, double bedrag)
        {
            var ba = ZoekBankAccount(rekeningNummer);
            ba.Storten(bedrag);
        }

        public bool Afhalen(int rekeningNummer, double bedrag)
        {
            var ba = ZoekBankAccount(rekeningNummer);
            return ba.Afhalen(bedrag);
        }
    }
}
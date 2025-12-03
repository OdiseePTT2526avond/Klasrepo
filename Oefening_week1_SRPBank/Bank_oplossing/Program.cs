using System.ComponentModel.DataAnnotations;

namespace Bank_oplossing
{

    /// Application class executing the scenarios
    public class Program
    {
        private readonly Bank MyBank = new();

        /**
         * start scenario:
         * add the bank accounts
         */
        private void StartScenarios()
        {
            MyBank.VoegAccountToe("me", 100.0, 1);
            MyBank.VoegAccountToe("myself", 0.0, 2);
            MyBank.VoegAccountToe("Geeraard", 666.0, 666);
        }

        /**
         * increase the first account balance by 100
         * decrease the third account balance by 200
         * decrease the second account balance by 100 (should fail)
         */
        private void Scenario1()
        {
            MyBank.Stort(1, 100);
            if (!MyBank.Afhalen(666, 100)) Console.WriteLine("scenario1 faalt - te weinig op rekening");
            if (!MyBank.Afhalen(2, 200)) Console.WriteLine("scenario1 faalt - te weinig op rekening");
        }

        /**
         * add a fourth account
         * increase the fourth account balance by 10
         */
        private void Scenario2()
        {
            MyBank.VoegAccountToe("Jane Doe", 4);
            MyBank.Stort(4, 10);
        }

        /// <summary>
        /// print the bank accounts.    
        /// </summary>
        private void PrintRekeningen()
        {
            Console.WriteLine(MyBank);
        }

        static void Main(string[] args)
        {
            /* Weg met de index. We gebruiken het rekeningnr als unique identifier
             * Er is geen goede reken om met static te werken.
             * Input output is de taak van het programma ipv de Bank
             */
            Program program = new Program();

            program.StartScenarios();
            Console.WriteLine("Rekeningen op het begin:");
            program.PrintRekeningen();
            program.Scenario1();
            Console.WriteLine("Rekeningen na transacties:");
            program.PrintRekeningen();
            program.Scenario2();
            Console.WriteLine("Rekeningen op het einde:");
            program.PrintRekeningen();
        }
    }
}
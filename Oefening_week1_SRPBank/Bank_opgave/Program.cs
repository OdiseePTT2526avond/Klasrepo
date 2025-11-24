using System;
using System.Collections.Generic;
using System.Linq;
namespace Bank_opgave
{
    /// <summary>
    /// Application class executing the scenario.
    /// </summary>    
    internal class Program
    {
       
        /// <summary>
        /// Executes the scenario.
        /// increase the first account balance by 100
        /// decrease the third account balance by 200
        /// decrease the second account balance by 100 (should fail)
        /// add a fourth account
        /// increase the fourth account balance by 10
        /// </summary>
        static void Main(string[] args)
        {
            Bank mijnbank = new();

            Console.WriteLine("Rekeningen aan de start:");
            Console.WriteLine(string.Join(", ", Bank.RekeningNummers));
            Console.WriteLine(string.Join(", ", Bank.RekeningNamen));
            Console.WriteLine(string.Join(", ", Bank.RekeningBalansen));

            int RekeningIndex = 0;
            mijnbank.SetRekeningIndex(RekeningIndex);
            mijnbank.RekeningVerrichting("storten", 100.0);
            RekeningIndex = 1;
            mijnbank.SetRekeningIndex(RekeningIndex);
            mijnbank.RekeningVerrichting("afhalen", 100.0);
            RekeningIndex++;
            mijnbank.SetRekeningIndex(RekeningIndex);
            mijnbank.RekeningVerrichting("afhalen", 100.0);

            Console.WriteLine("Rekeningen na transacties:");
            Console.WriteLine(string.Join(", ", Bank.RekeningNummers));
            Console.WriteLine(string.Join(", ", Bank.RekeningNamen));
            Console.WriteLine(string.Join(", ", Bank.RekeningBalansen));
            
            // add a fourth account and initialize it to 0.0
            List<int> tempRekeningNummers = new List<int>(Bank.RekeningNummers); //maak een tijdelijke arrayList welke de nieuwe rekening kan toevoegen
            tempRekeningNummers.Add(42);
            Bank.RekeningNummers = tempRekeningNummers.ToArray(); // vul de oude array met de nieuwe waarden
            List<double> tempRekeningBedragen = new List<double>(Bank.RekeningBalansen); // maak een tijdelijke arrayList welke de nieuwe rekening kan toevoegen
            tempRekeningBedragen.Add(0.0);
            Bank.RekeningBalansen = tempRekeningBedragen.ToArray(); // vul de oude array met de nieuwe waarden

            //increase the fourth account balance by 10
            mijnbank.SetRekeningIndex(3);
            mijnbank.RekeningVerrichting("storten", 10.0);
            
            Console.WriteLine("Rekeningen op het einde:");
            Console.WriteLine(string.Join(", ", Bank.RekeningNummers));
            Console.WriteLine(string.Join(", ", Bank.RekeningNamen));
            Console.WriteLine(string.Join(", ", Bank.RekeningBalansen));
        }
    }
}

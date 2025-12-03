using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator
{
    public class Calculator
    {
        /// Berekent de som van een reeks
        /// Req 1 -> 7
        /// @param input de reeks getallen
        /// @returns de som van de getallen in de input
        public static int Calculate(string input)
        {
            // Requirement 1: lege string => 0
            if (string.IsNullOrWhiteSpace(input))
                return 0;

            // Requirement 3 en 4 Splits op komma of newline
            char[] delimiters = new char[] { ',', '\n' };
            string[] inputLijst = input.Split(delimiters);

            IEnumerable<int> getallen = inputLijst.Select(getal => int.Parse(getal));

            // Requirement 6: negatieve getallen?
            // if (getallen.Where(n => n < 0).Any())
            if (getallen.Where(n => n < 0).Count() > 0)
            {
                throw new ArgumentOutOfRangeException(nameof(input),"Input mag niet negatief zijn");
            }

            // Requirement 2+3+5
            // Requirement 7: negeer >1000
            int sum = getallen.Where(n => n <= 1000).Sum();

            return sum;
        }
    }
}

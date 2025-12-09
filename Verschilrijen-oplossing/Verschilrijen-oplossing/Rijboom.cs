using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verschilrijen;

namespace Verschilrijen
{
    /// <summary>
    /// Stelt een verschilrijboom voor die de opeenvolging van de verschilrijen bewaard. Elke rij is de kindverschilrij van de vorige rij.
    /// </summary>
    public class Rijboom(Rij startrij)
    {
        private readonly List<Rij> boom = [startrij];

        /// <summary>
        /// Req11
        /// Berekent de diepte van de verschilboom, dat is het aantal gekende verschilrijen
        /// </summary>
        /// <returns>de diepte van de rijboom</returns>
        public int Diepte()
        {
            return boom.Count;
        }

        /// <summary>
        /// req 12
        /// </summary>
        /// <param name="index">volgnr van de op te vragen rij. startij = 0, kind van startrij = 1 ,...</param>
        /// <returns>verschilrij</returns>
        public Rij GetRij(int index)
        {
            return boom[index];
        }

        /// <summary>
        /// Berekent i kinderen vanaf de laatste rij in de boom
        /// </summary>
        /// <param name="i">aantal te berekenen kinderen</param>
        public void BerekenKinderen(int i)
        {
            for (int j = 0; j < i; j++)
            {
                
                if (boom.Last().IsNul()) return;  // implementatie na givenBoom4444_bereken2Kinderen_ResultsInBoomDiepte2
                boom.Add(boom.Last().BerekenKindRij()); //implementatie na givenBoom4042_bereken2Kinderen_ResultsIn2442And0202
            }
        }
    }
}

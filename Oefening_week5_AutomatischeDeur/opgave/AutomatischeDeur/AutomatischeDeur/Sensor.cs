using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatischeDeur
{
    // REQ: aanwezigheid van een persoon kan waargenomen worden
    public class Sensor
    {
        // constructor
        public Sensor()
        {

        }

        // REQ: aanwezigheid van een persoon kan waargenomen worden
        // Input: -
        // Output: bool: true als er iemand is, en anders false
        public bool IsErIemand()
        {
            Random r = new Random();
            if (r.Next(100) > 80)
            {
                return true;
            }
            return false;
        }
    }
}

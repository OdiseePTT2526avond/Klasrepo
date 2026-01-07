using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatischeDeur
{
    // REQ: logs toevoegen
    // REQ: alle logs verwijderen
    public class Logger
    {
        public List<string> logs = new List<string>();

        // Constructor voor Logger
        public Logger()
        {

        }

        // REQ: logs toevoegen
        // Input: log: de string die toegevoegd moet worden
        // Output: void, side-effect: logs bevat nu log
        public void VoegLogToe(string log)
        {
            logs.Add(log);
        }

        // REQ: alle logs verwijderen
        // Input: -
        // Output: void, side-effect: alle logs zijn gewist
        public void VerwijderLogs()
        {
            logs = new List<string>();
        }
    }
}

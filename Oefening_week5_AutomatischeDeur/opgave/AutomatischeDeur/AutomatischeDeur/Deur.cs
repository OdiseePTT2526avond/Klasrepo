using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatischeDeur
{
    // Deur: single responsability - automatische deur
    // REQ: deur gaat automatisch open/dicht
    // REQ: deur logt elke keer dat het open/dicht gaat
    public class Deur
    {
        public bool isOpen = false;
        private Sensor sensor;
        private Logger logger;

        public Deur()
        {
            sensor = new Sensor();
            logger = new Logger();
        }

        // REQ: deur gaat open als er iemand is
        // Input: -
        // Output: bool: true als deur open is gegaan. Anders false.
        public bool GaOpenAlsErIemandIs()
        {
            if (!isOpen)
            {
                if (sensor.IsErIemand())
                {
                    isOpen = true;
                    logger.VoegLogToe("deur ging open");
                    return true;
                }
                return false;
            } else
            {
                throw new Exception("deur is al open");
            }
        }

        // REQ: deur gaat dicht als er niemand is
        // Input: -
        // Output: bool: true als de deur dicht is gegaan. Anders false
        public bool GaDichtAlsErNiemandIs()
        {
            if (isOpen)
            {
                if (!sensor.IsErIemand()) 
                {
                    isOpen = false;
                    logger.VoegLogToe("deur ging dicht");
                    return true;
                }
                return false;
            } else
            {
                throw new Exception("deur is al dicht");
            }
        }
    }
}

using System.Configuration;
using System.Data;
using System.Windows;


/** OPGELET: deze oplossing beslaagd enkel het herscjikken van de code. 
 * Geen nieuwe functionaliteit is toegevoegd t.o.v. de originele code in Inventory 
 */

namespace Inventory
{
    /// <summary>
    /// Responsible for application lifecycle management and initial window creation.
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Provides the initial stock inventory for application startup.
        /// </summary>
        private readonly List<StockItem> InitialStock = [
            new StockItem("Chewtoy mouse", 10.5,10),
            new StockItem("Chewtoy bone", 12,3),
            new StockItem("Collar Green", 15.5,2),
            new StockItem("Collar Red", 16.5,1),
            new StockItem("Dewormer extra strong", 33,0)
        ];


        private StockManager teVerkopenStock;
        private Order huidigeBestelling = new Order();
        // Voor req3 Zullen we hier ipv 1 order  een object moeten maken die ALLE orders bijhoudt.



        /// <summary>
        /// Handles the application startup event to create and display the main window.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The startup event arguments.</param>
        void App_Startup(object sender, StartupEventArgs e)
        {
            teVerkopenStock = new(InitialStock);

            InventoryWindow window = new InventoryWindow(teVerkopenStock, huidigeBestelling);
            window.Show();
        }

        /// <summary>
        /// Overrides the base OnStartup method to initialize the application.
        /// </summary>
        /// <param name="e">The startup event arguments.</param>
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            App_Startup(this, e);
        }
    

    }

}

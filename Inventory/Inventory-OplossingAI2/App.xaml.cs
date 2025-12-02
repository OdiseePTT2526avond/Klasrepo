using System.Configuration;
using System.Data;
using System.Windows;

namespace Inventory
{
    /// <summary>
    /// Responsible for application lifecycle management and initial window creation.
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Handles the application startup event to create and display the main window.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The startup event arguments.</param>
        void App_Startup(object sender, StartupEventArgs e)
        {
            InventoryWindow window = new InventoryWindow(StockItem.InitialStock);
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

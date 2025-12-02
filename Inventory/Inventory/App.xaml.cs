using System.Configuration;
using System.Data;
using System.Windows;

namespace Inventory
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        void App_Startup(object sender, StartupEventArgs e)
        {
            // Application is running
            // Create main application window
            InventoryWindow window = new InventoryWindow(StockItem.InitialStock);
            window.Show();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            App_Startup(this, e);
        }
    }

}

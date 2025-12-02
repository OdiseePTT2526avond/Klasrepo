using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Inventory
{
    /// <summary>
    /// Partial class containing data loading presentation logic for InventoryWindow.
    /// </summary>
    public partial class InventoryWindow : Window
    {
        /// <summary>
        /// Loads the initial stock data into the display.
        /// </summary>
        /// <param name="startInventory">The initial stock items to display.</param>
        private void LoadData(List<StockItem> startInventory)
        {
            stockListBox.ItemsSource = startInventory;
        }
    }
}

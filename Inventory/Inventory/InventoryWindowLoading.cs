using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Inventory
{
    public partial class InventoryWindow : Window
    {
        /// <summary>
        /// Loads the test data, only for testing purposes. Later on there might be a database connection and files to load from.
        /// </summary>
        private void LoadData(List<StockItem> startInventory)
        {
            stockListBox.ItemsSource = startInventory;
        }
    }
}

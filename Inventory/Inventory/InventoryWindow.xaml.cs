using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Inventory
{
    /// <summary>
    /// Interaction logic for InventoryWindow.xaml
    /// </summary>
    public partial class InventoryWindow : Window
    {
        public InventoryWindow() { }
        public InventoryWindow(List<StockItem> startInventory)
        {
            InitializeComponent();
            LoadData(startInventory);
        }


        private void StockListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        { }

        private void StockListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e) { 
            if (stockListBox.SelectedItem != null)
            {
                StockItem item = (StockItem)stockListBox.SelectedItem;
                if (item.Quantity > 0)
                {
                    orderListBox.Items.Add(new StockItem(item.Name, item.Price, 1));
                    item.Quantity--;
                    stockListBox.Items.Refresh();
                }
                SetTotalAmount();
            }
        }

        private void ProcessOrderButton_Click(object sender, RoutedEventArgs e) { }

    }
}
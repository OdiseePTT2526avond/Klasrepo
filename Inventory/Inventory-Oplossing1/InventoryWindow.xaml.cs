using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Inventory
{
    /// <summary>
    /// Responsible for presenting the inventory user interface and coordinating user interactions.
    /// </summary>
    public partial class InventoryWindow : Window
    {
        private readonly StockManager _stockManager;
        private readonly Order _currentOrder;

        /// <summary>
        /// Initializes a new instance of the InventoryWindow.
        /// </summary>
       // public InventoryWindow() { }

        /// <summary>
        /// Initializes a new instance of the InventoryWindow.
        /// </summary>
        /// <param name="startInventory">The initial stock items to display.</param>
        public InventoryWindow(in StockManager huidigeVooraad, in Order huidigeBestelling)
        {
            InitializeComponent();
            _stockManager = huidigeVooraad;
            _currentOrder = huidigeBestelling;
            stockListBox.ItemsSource = huidigeVooraad.GetStockItems();
        }

        /// <summary>
        /// Handles the selection changed event for the stock list box.
        /// </summary>
        private void StockListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        { }

        /// <summary>
        /// Handles double-click on stock items to add them to the order.
        /// </summary>
        private void StockListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e) { 
            if (stockListBox.SelectedItem != null)
            {
                StockItem item = (StockItem)stockListBox.SelectedItem;
                if (_stockManager.HasQuantityAvailable(item,1)) //TODO move to OrderRepository class?
                {
                    _currentOrder.AddItem(item,1);
                    _stockManager.DecreaseQuantity(item, 1);
                    orderListBox.ItemsSource = _currentOrder.GetOrderItems();
                    stockListBox.Items.Refresh();
                }
                SetTotalAmount();
            }
        }

        /// <summary>
        /// Handles the process order button click event.
        /// </summary>
        private void ProcessOrderButton_Click(object sender, RoutedEventArgs e) { }

        /// <summary>
        /// Updates the displayed total amount based on the current order items.
        /// </summary>
        private void SetTotalAmount()
        {
            double totalAmount = _currentOrder.CalculatePrice();
            totalAmountLabel.Content = totalAmount;
        }

    }
}
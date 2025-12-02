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
        private StockManager _stockManager;
        private OrderManager _orderManager;
        private OrderCalculator _orderCalculator;

        /// <summary>
        /// Initializes a new instance of the InventoryWindow.
        /// </summary>
        public InventoryWindow() { }

        /// <summary>
        /// Initializes a new instance of the InventoryWindow with initial stock.
        /// </summary>
        /// <param name="startInventory">The initial stock items to display.</param>
        public InventoryWindow(List<StockItem> startInventory)
        {
            InitializeComponent();
            _stockManager = new StockManager(startInventory);
            _orderManager = new OrderManager();
            _orderCalculator = new OrderCalculator();
            LoadData(startInventory);
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
                if (_stockManager.HasQuantityAvailable(item))
                {
                    StockItem orderItem = _orderManager.CreateOrderItem(item);
                    _orderManager.AddItemToOrder(orderItem);
                    orderListBox.Items.Add(orderItem);
                    _stockManager.DecreaseQuantity(item);
                    stockListBox.Items.Refresh();
                }
                SetTotalAmount();
            }
        }

        /// <summary>
        /// Handles the process order button click event.
        /// </summary>
        private void ProcessOrderButton_Click(object sender, RoutedEventArgs e) { }

    }
}
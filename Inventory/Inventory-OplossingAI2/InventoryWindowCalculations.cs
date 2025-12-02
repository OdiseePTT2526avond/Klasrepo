using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Inventory
{
    /// <summary>
    /// Partial class containing calculation-related presentation logic for InventoryWindow.
    /// </summary>
    public partial class InventoryWindow : Window
    {
        /// <summary>
        /// Updates the displayed total amount based on the current order items.
        /// </summary>
        private void SetTotalAmount()
        {
            double totalAmount = _orderCalculator.CalculateTotalAmount(orderListBox.Items.Cast<StockItem>());
            totalAmountLabel.Content = totalAmount;
        }
    }
}

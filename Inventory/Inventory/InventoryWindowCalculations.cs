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
        private void SetTotalAmount()
        {
            double totalAmount = 0;
            foreach (StockItem item in orderListBox.Items)
            {
                totalAmount += item.Price;
            }
            totalAmountLabel.Content = totalAmount;
        }
    }
}

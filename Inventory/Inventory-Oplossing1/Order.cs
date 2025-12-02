using System.Collections.Generic;

namespace Inventory
{
    /// <summary>
    /// Represents an order containing multiple stock items.
    /// </summary>
    public class Order
    {
        private readonly List<StockItem> _orderItems;

        /// <summary>
        /// Initializes a new order manager with an empty order.
        /// </summary>
        public Order()
        {
            _orderItems = [];
        }

        /// <summary>
        /// Gets the current order items.
        /// </summary>
        /// <returns>The list of items in the current order.</returns>
        public List<StockItem> GetOrderItems()
        {
            return new List<StockItem>(_orderItems);
        }

        /// <summary>
        /// Creates a new order item based on a stock item.
        /// </summary>
        /// <param name="stockItem">The stock item to create an order item from.</param>
        /// <returns>A new stock item for the order with quantity.</returns>
        public void AddItem(in StockItem stockItem,int quantity)
        {
            _orderItems.Add(new StockItem(stockItem.Name, stockItem.Price, quantity));
        }

        /// <summary>
        /// Calculates the total price for a our order.
        /// </summary>
        /// <returns>The total price.</returns>
        public double CalculatePrice()
        {
            double totalAmount = 0;
            foreach (StockItem item in _orderItems)
            {
                totalAmount += item.Price*item.Quantity;
            }
            return totalAmount;
        }

    }
}

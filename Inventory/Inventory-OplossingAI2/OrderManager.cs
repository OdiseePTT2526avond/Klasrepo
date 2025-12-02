using System.Collections.Generic;

namespace Inventory
{
    /// <summary>
    /// Responsible for managing customer orders and order items.
    /// </summary>
    public class OrderManager
    {
        private List<StockItem> _orderItems;

        /// <summary>
        /// Initializes a new order manager with an empty order.
        /// </summary>
        public OrderManager()
        {
            _orderItems = new List<StockItem>();
        }

        /// <summary>
        /// Gets the current order items.
        /// </summary>
        /// <returns>The list of items in the current order.</returns>
        public List<StockItem> GetOrderItems()
        {
            return _orderItems;
        }

        /// <summary>
        /// Adds an item to the current order.
        /// </summary>
        /// <param name="item">The stock item to add to the order.</param>
        public void AddItemToOrder(StockItem item)
        {
            _orderItems.Add(item);
        }

        /// <summary>
        /// Creates a new order item based on a stock item.
        /// </summary>
        /// <param name="stockItem">The stock item to create an order item from.</param>
        /// <returns>A new stock item for the order with quantity 1.</returns>
        public StockItem CreateOrderItem(StockItem stockItem)
        {
            return new StockItem(stockItem.Name, stockItem.Price, 1);
        }

        /// <summary>
        /// Clears all items from the current order.
        /// </summary>
        public void ClearOrder()
        {
            _orderItems.Clear();
        }
    }
}

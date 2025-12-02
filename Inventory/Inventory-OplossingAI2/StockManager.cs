using System.Collections.Generic;

namespace Inventory
{
    /// <summary>
    /// Responsible for managing stock inventory data and operations.
    /// </summary>
    public class StockManager
    {
        private List<StockItem> _stockItems;

        /// <summary>
        /// Initializes the stock manager with initial inventory.
        /// </summary>
        /// <param name="initialStock">The initial stock items.</param>
        public StockManager(List<StockItem> initialStock)
        {
            _stockItems = initialStock;
        }

        /// <summary>
        /// Gets the current stock items.
        /// </summary>
        /// <returns>The list of stock items.</returns>
        public List<StockItem> GetStockItems()
        {
            return _stockItems;
        }

        /// <summary>
        /// Decreases the quantity of a stock item by one.
        /// </summary>
        /// <param name="item">The stock item to decrease.</param>
        /// <returns>True if the quantity was decreased, false if the item is out of stock.</returns>
        public bool DecreaseQuantity(StockItem item)
        {
            if (item.Quantity > 0)
            {
                item.Quantity--;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Checks if a stock item has available quantity.
        /// </summary>
        /// <param name="item">The stock item to check.</param>
        /// <returns>True if the item has quantity available, false otherwise.</returns>
        public bool HasQuantityAvailable(StockItem item)
        {
            return item != null && item.Quantity > 0;
        }
    }
}

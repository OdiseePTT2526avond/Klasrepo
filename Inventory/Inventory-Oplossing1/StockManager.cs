using System.Collections.Generic;

namespace Inventory
{
    // TODO order en stockmanager zijn gelijkaardig van opbouw. Misschien samen 1 klasse maken? Of een basis klasse maken?

    /// <summary>
    /// Responsible for managing stock inventory data and operations.
    /// </summary>
    public class StockManager
    {
        private readonly List<StockItem> _stockItems;

        /// <summary>
        /// Initializes the stock manager with initial inventory.
        /// </summary>
        /// <param name="initialStock">The initial stock items.</param>
        public StockManager(in List<StockItem> initialStock) => _stockItems = new( initialStock);

        /// <summary>
        /// Gets the current stock items.
        /// </summary>
        /// <returns>Copy of the list of stock items.</returns>
        public List<StockItem> GetStockItems()
        {
            return new List<StockItem>(_stockItems); //copy of stockitems
        }

        /// <summary>
        /// Decreases the quantity of a stock item by one.
        /// </summary>
        /// <param name="item">The stock item to decrease.</param>
        /// <returns>True if the quantity was decreased, false if the item is out of stock.</returns>
        public bool DecreaseQuantity(in StockItem item, int quantity)
        {
            string itemName = item.Name;
            StockItem inStock = _stockItems.Where(i => i.Name == itemName).First();
            if (inStock.Quantity >= quantity)
            {
                inStock.Quantity -= quantity;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Checks if a stock item has sufficient quantity.
        /// </summary>
        /// <param name="item">The stock item to check.</param>
        /// <param name="quantity">the amount to check for</param>
        /// <returns>True if the item has that quantity available, false otherwise.</returns>
        public bool HasQuantityAvailable(in StockItem item,int quantity)
        {
            string itemName = item.Name;
            StockItem inStock= _stockItems.Where(i => i.Name == itemName).First();
            return item != null && inStock.Quantity >= quantity;
        }
    }
}

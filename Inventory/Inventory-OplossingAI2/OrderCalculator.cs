using System.Collections.Generic;

namespace Inventory
{
    /// <summary>
    /// Responsible for calculating order totals and amounts.
    /// </summary>
    public class OrderCalculator
    {
        /// <summary>
        /// Calculates the total amount for a collection of stock items.
        /// </summary>
        /// <param name="items">The items to calculate the total for.</param>
        /// <returns>The total amount.</returns>
        public double CalculateTotalAmount(IEnumerable<StockItem> items)
        {
            double totalAmount = 0;
            foreach (StockItem item in items)
            {
                totalAmount += item.Price;
            }
            return totalAmount;
        }
    }
}

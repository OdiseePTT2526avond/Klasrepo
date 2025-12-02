using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory
{
    /// <summary>
    /// Responsible for representing a single stock item with its properties and providing initial test data.
    /// </summary>
    public class StockItem(string name, double price, int quantity)
    {
        /// <summary>
        /// Gets or sets the name of the stock item.
        /// </summary>
        public string Name { get => name; set => name = value; }

        /// <summary>
        /// Gets or sets the price of the stock item.
        /// </summary>
        public double Price { get => price; set => price = value; }

        /// <summary>
        /// Gets or sets the quantity available in stock.
        /// </summary>
        public int Quantity { get => quantity; set => quantity = value; }

        /// TODO add methods for increasing and decreasing quantity

        /// <summary>
        /// Returns a string representation of the stock item.
        /// </summary>
        /// <returns>A formatted string with name, price, and quantity.</returns>
        public override string ToString()
        {
            return $"{name} - €{price} Quantity:{quantity}";
        }
        
    }
}

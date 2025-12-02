using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory
{
    public class StockItem(string name, double price, int quantity)
    {
        public string Name { get => name; set => name = value; }
        public double Price { get => price; set => price = value; }
        public int Quantity { get => quantity; set => quantity = value; }

        public override string ToString()
        {
            return $"{name} - €{price} Quantity:{quantity}";
        }

        /// Starting inventory
        public static List<StockItem> InitialStock = [
            new StockItem("Chewtoy mouse", 10.5,10),
            new StockItem("Chewtoy bone", 12,3),
            new StockItem("Collar Green", 15.5,2),
            new StockItem("Collar Red", 16.5,1),
            new StockItem("Dewormer extra strong", 33,0)
        ];
        
    }
}

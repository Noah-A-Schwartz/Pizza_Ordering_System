using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2
{
    /// <summary>
    /// This class represents the relevant variables and methods for Drink.
    /// </summary>
    public class Drink
    {
        public string name { get; set; }
        public string size { get; set; }
        public int quantity { get; set; }
        public float drinkPrice { get; set; }

        /// <summary>
        /// The overloaded constructor for the Drink class
        /// </summary>
        /// <param name="name">The name of the drink</param>
        /// <param name="size">The size of the drink</param>
        /// <param name="quantity">The quantity of the drink</param>
        public Drink(string name, string size, int quantity)
        {
            this.name = name;
            this.size = size;
            this.quantity = quantity;
            drinkPrice = 1 * quantity;
        }
    }
}
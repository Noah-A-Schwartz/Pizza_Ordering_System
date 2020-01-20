using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2
{
    /// <summary>
    /// This class contains relevant methods and variables for Pizza.
    /// </summary>
    public class Pizza
    {
        public string size { get; set; }
        public float pizzaPrice { get; set; }
        public string crust { get; set; }
        public string cheese { get; set; }
        public List<Topping> toppings { get; }

        /// <summary>
        /// Default constructor for the Pizza class
        /// </summary>
        public Pizza()
        {
            toppings = new List<Topping>();
        }

        /// <summary>
        /// Overloaded constructor for the Pizza class
        /// </summary>
        /// <param name="size">The size of the pizza</param>
        /// <param name="crust">The type of crust of the pizza</param>
        /// <param name="cheese">The type of cheese of the pizza</param>
        public Pizza(string size, string crust, string cheese)
        {
            this.size = size;
            this.crust = crust;
            this.cheese = cheese;
            toppings = new List<Topping>();
        }

        /// <summary>
        /// This method adds a topping to the order.
        /// </summary>
        /// <param name="t">Topping instance called t</param>
        public void AddTopping(Topping t)
        {
            toppings.Add(t);
        }

        /// <summary>
        /// This method removes a topping from the order.
        /// </summary>
        /// <param name="t">Topping instance called t</param>
        public void RemoveTopping(Topping t)
        {
            toppings.Remove(t);
        }
    }
}
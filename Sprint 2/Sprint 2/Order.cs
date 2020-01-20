using System;
using System.Collections.Generic;

namespace Sprint_2
{
    /// <summary>
    /// This class contains relevant methods and variables for Order.
    /// </summary>
    public class Order
    {
        public string type { get; set; }
        public List<Pizza> pizzas { get; }
        public List<Side> sides { get; }
        public List<Drink> drinks { get; }

        /// <summary>
        /// An overloaded constructor for the Order class.
        /// </summary>
        /// <param name="type">The type of order</param>
        public Order(string type)
        {
            this.type = type;
            this.pizzas = new List<Pizza>();
            this.sides = new List<Side>();
            this.drinks = new List<Drink>();
        }

        /// <summary>
        /// This method adds a pizza to the order.
        /// </summary>
        /// <param name="p">Pizza instance called p</param>
        public void AddPizza(Pizza p)
        {
            pizzas.Add(p);
        }

        /// <summary>
        /// This method removes a pizza from the order.
        /// </summary>
        /// <param name="p">Pizza instance called p</param>
        public void removePizza(Pizza p)
        {
            pizzas.Remove(p);
        }

        /// <summary>
        /// This method adds a side to the order.
        /// </summary>
        /// <param name="s">Side instance called s</param>
        public void addSide(Side s)
        {
            sides.Add(s);
        }

        /// <summary>
        /// The method removes the side from the order.
        /// </summary>
        /// <param name="s">Side instance called s</param>
        public void removeSide(Side s)
        {
            sides.Remove(s);
        }

        /// <summary>
        /// This method adds a drink to the order.
        /// </summary>
        /// <param name="d">Drink instance called d</param>
        public void addDrink(Drink d)
        {
            drinks.Add(d);
        }

        /// <summary>
        /// This method returns the total price of the order.
        /// </summary>
        /// <returns>Returns a float instance that represents the total price</returns>
        public float orderTotal()
        {
            float total = 0;
            if (pizzas.Count != 0)
            {
                for (int i = 0; i < pizzas.Count; i++)
                {
                    total += pizzas[i].pizzaPrice;
                    for (int j = 0; j < pizzas[i].toppings.Count; j++)
                    {
                        total += pizzas[i].toppings[j].toppingPrice;
                    }
                }
            }
            if (sides.Count != 0)
            { 
                for (int i = 0; i < sides.Count; i++)
                {
                    total += sides[i].sidePrice;
                }
            }
            if (drinks.Count != 0)
            {
                for (int i = 0; i < drinks.Count; i++)
                {
                    total += drinks[i].drinkPrice;
                }
            }
            return total;
        }
    }
}	
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2
{
    /// <summary>
    /// This class contains relevant methods and variables for Topping.
    /// </summary>
    public class Topping
    {
        public string name { get; set; }
        public string location { get; set; }
        public float toppingPrice { get; set; }
        public Pizza p { get; set; }

        /// <summary>
        /// The overloaded constructor of the Topping class
        /// </summary>
        /// <param name="p">Pizza instance called p</param>
        /// <param name="name">The name of the topping</param>
        /// <param name="location">The location of the topping</param>
        public Topping(Pizza p, string name, string location)
        {
            this.name = name;
            this.location = location;
            this.toppingPrice = 0f;
            this.p = p;
        }

        /// <summary>
        /// This method sets the price of a Topping.
        /// </summary>
        public void setToppPrice()
        {

            if (p.size == "Small")
            {
                if (location != "Whole")
                {
                    toppingPrice = .25f;
                }
                else
                {
                    toppingPrice = .5f;
                }
            }
            else if (p.size == "Medium")
            {
                if (location != "Whole")
                {
                    toppingPrice = .38f;
                }
                else
                {
                    toppingPrice = .75f;
                }
            }
            else if (p.size == "Large")
            {
                if (location != "Whole")
                {
                    toppingPrice = .5f;
                }
                else
                {
                    toppingPrice = 1f;
                }
            }
            else
            {
                if (location != "Whole")
                {
                    toppingPrice = .63f;
                }
                else
                {
                    toppingPrice = 1.25f;
                }
            }
        }
    }
}
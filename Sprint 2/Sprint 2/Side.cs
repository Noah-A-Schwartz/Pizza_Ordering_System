using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2
{
    /// <summary>
    /// This class contains relevant methods and variables for Side.
    /// </summary>
    public class Side
    {
        public string name { get; set; }
        public string customization { get; set; }
        public int quantity { get; set; }
        public float sidePrice { get; set; }

        /// <summary>
        /// The first overloaded constructor of the Side class
        /// </summary>
        /// <param name="name">The name of the side</param>
        /// <param name="quantity">The quantity of the side</param>
        public Side(string name, int quantity)
        {
            this.name = name;
            this.quantity = quantity;
        }

        /// <summary>
        /// The second overloaded constructor of the Side class.
        /// </summary>
        /// <param name="name">The name of the side</param>
        /// <param name="customization">The customization of the side</param>
        /// <param name="quantity">The quantity of the side</param>
        public Side(string name, string customization, int quantity)
        {
            this.name = name;
            this.quantity = quantity;
            this.customization = customization;
        }
    }
}
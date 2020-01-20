using System;
namespace Sprint_2
{
    /// <summary>
    /// The class represents the Customer.
    /// </summary>
	public class Customer
    {
		public string firstName { get; set; }
		public string lastName { get; set; }
		public long phoneNumber { get; set; }
        public string address { get; set; }
        public int zip { get; set; }
        public bool loggedIn { get; set; }
        public Order currentOrder { get; set; }

        /// <summary>
        /// An overloaded constructor for the Customer class
        /// </summary>
        /// <param name="firstName">The first name of the customer</param>
        /// <param name="lastName">The last name of the customer</param>
        /// <param name="phoneNumber">The phone number of the customer</param>
		public Customer(string firstName, string lastName, long phoneNumber)
        {
			this.firstName = firstName;
			this.lastName = lastName;
			this.phoneNumber = phoneNumber;
		}

        /// <summary>
        /// The second overloaded constructor for the Customer class
        /// </summary>
        /// <param name="first">The first name of the customer</param>
        /// <param name="last">The last name of the customer</param>
        /// <param name="phoneNumber">The phone number of the customer</param>
        /// <param name="address">The address of the customer</param>
        /// <param name="zip">The zip code of the customer</param>
        public Customer(string first, string last, long phoneNumber, string address, int zip)
        {
            firstName = first;
            lastName = last;
            this.phoneNumber = phoneNumber;
            this.address = address;
            this.zip = zip;
        }

        /// <summary>
        /// The third overloaded constructor of the Customer class
        /// </summary>
        /// <param name="first">The first name of the customer</param>
        /// <param name="last">The last name of the customer</param>
        /// <param name="phoneNumber">The phone number of the customer</param>
        /// <param name="address">The address of the customer</param>
        /// <param name="zip">The zip code of the customer</param>
        /// <param name="currentOrder">The current order of the customer</param>
        public Customer(string first, string last, long phoneNumber, string address, int zip, Order currentOrder)
        {
            firstName = first;
            lastName = last;
            this.phoneNumber = phoneNumber;
            this.address = address;
            this.zip = zip;
            this.currentOrder = currentOrder;
        }


        /// <summary>
        /// The final overloaded constructor of the Customer class
        /// </summary>
        /// <param name="first">The first name of the customer</param>
        /// <param name="last">The last name of the customer</param>
        /// <param name="phoneNumber">The phone number of the customer</param>
        /// <param name="currentOrder">The current order of the customer</param>
        public Customer(string first, string last, long phoneNumber, Order currentOrder)
        {
            firstName = first;
            lastName = last;
            this.phoneNumber = phoneNumber;
            this.currentOrder = currentOrder;
        }
    }
}

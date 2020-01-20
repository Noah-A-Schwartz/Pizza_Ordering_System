using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2
{
    /// <summary>
    /// This class contains relevant methods and variables for the User and extends the Customer class.
    /// </summary>
    public class User : Customer
    {
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }

        /// <summary>
        /// The overloaded constructor of the User class
        /// </summary>
        /// <param name="first">The first name of the user</param>
        /// <param name="last">The last name of the user</param>
        /// <param name="phone">The phone number of the user</param>
        /// <param name="username">The username of the user</param>
        /// <param name="password">The password of the user</param>
        /// <param name="email">The email address of the user</param>
        /// <param name="address">The address of the user</param>
        /// <param name="zip">The zip code of the user</param>
        public User(string first, string last, long phone, string username, string password, string email, string address, int zip) : base(first, last, phone, address, zip)
        {
            this.username = username;
            this.password = password;
            this.email = email;
        }
    }
}
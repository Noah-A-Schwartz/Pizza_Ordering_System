using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sprint_2
{
    /// <summary>
    /// This class represents the relevant methods and variables for the DeliveryInfo form.
    /// </summary>
    public partial class DeliveryInfo : Form
    {
        private Customer newCustomer;
        string next;
        Form previous;

        /// <summary>
        /// The overloaded constructor of the DeliveryInfo class
        /// </summary>
        /// <param name="next">The string representing the next form</param>
        /// <param name="previous">The string representing the previous form</param>
        public DeliveryInfo(string next, Form previous)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            this.next = next;
            this.previous = previous;
        }

        /// <summary>
        /// This method returns the user to the home page.
        /// </summary>
        /// <param name="sender">Instance that represents the click of button</param>
        /// <param name="e">Instance that represents the event</param>
        private void pictureBox12_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1(newCustomer);
            Hide();
            f.ShowDialog();
        }

        /// <summary>
        /// The method returns the user to the previous page.
        /// </summary>
        /// <param name="sender">Instance that represents the click of button</param>
        /// <param name="e">Instance that represents the event</param>
        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            previous.Show();
        }

        /// <summary>
        /// The method signs the user in or logs the user out.
        /// </summary>
        /// <param name="sender">Instance that represents the click of button</param>
        /// <param name="e">Instance that represents the event</param>
        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            new Form1().ShowDialog();
        }

        /// <summary>
        /// This button error checks the First Name, Last Name, Phone Number, Street Address, and Zip Code of the customer.
        /// </summary>
        /// <param name="sender">Instance that represents the click of button</param>
        /// <param name="e">Instance that represents the event</param>
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(firstText.Text) ||
               string.IsNullOrWhiteSpace(lastText.Text) ||
               string.IsNullOrWhiteSpace(phoneText.Text) ||
               string.IsNullOrWhiteSpace(addressText.Text) ||
               string.IsNullOrWhiteSpace(zipText.Text))
            {
                errorLabel.Visible = true;
                return;
            }
            else
            {
                errorLabel.Visible = false;

            }
            //removing parentheses/dashes/spaces from phone number
            string fixedPhone = phoneText.Text;
            if (phoneText.Text.Contains('-') || phoneText.Text.Contains('(') || phoneText.Text.Contains(')') || phoneText.Text.Contains(' '))
            {
                for (int i = 0; i < fixedPhone.Length; i++)
                {
                    if (fixedPhone[i] == '-' || fixedPhone[i] == '(' || fixedPhone[i] == ')' || fixedPhone[i] == ' ')
                    {
                        fixedPhone = fixedPhone.Replace("-", "");
                        fixedPhone = fixedPhone.Replace("(", "");
                        fixedPhone = fixedPhone.Replace(")", "");
                        fixedPhone = fixedPhone.Replace(" ", "");
                    }
                }
            }
            //checking that phone number is 10 digits long
            if (fixedPhone.Length != 10)
            {
                errorLabel.Text = "Phone must be 10 digits";
                errorLabel.Visible = true;
                return;
            }
            else
            {
                errorLabel.Visible = false;

            }
            //checking that zip is 5 digits
            if (zipText.Text.Length != 5)
            {
                errorLabel.Text = "ZIP must be 5 digits";
                errorLabel.Visible = true;
                return;
            }
            else
            {
                errorLabel.Visible = false;
            }
            try
            {
                newCustomer = new Customer(firstText.Text, lastText.Text, long.Parse(fixedPhone), addressText.Text, int.Parse(zipText.Text), new Order("Delivery"));
            }
            catch
            {
                errorLabel.Text = "A required field is invalid";
                errorLabel.Visible = true;
                return;
            }
            if (next == "Pizza")
            {

                PizzaForm f = new PizzaForm(newCustomer, new DeliveryInfo("Pizza", previous));
                Hide();
                f.ShowDialog();

            }
            else if (next == "Sides")
            {
                Sides f = new Sides(newCustomer, new DeliveryInfo("Sides", previous));
                Hide();
                f.ShowDialog();
            }
            else
            {
                OrderDrinks f = new OrderDrinks(newCustomer, new DeliveryInfo("Drinks", previous));
                Hide();
                f.ShowDialog();
            }
        }
    }
}
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
    /// Class CarryoutInfo creates relevant variables and methods pertaining to the CarryoutInfo Form.
    /// </summary>
    public partial class CarryoutInfo : Form
    {
        private Customer newCustomer;
        string next;
        Form previous;
        
        /// <summary>
        /// This method is an overloaded constructor for CarryoutInfo.
        /// </summary>
        /// <param name="next">String parameter that represents the next screen title.</param>
        /// <param name="previous">String parameter that represents the next screen title.</param>
        public CarryoutInfo(string next, Form previous)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            this.next = next;
            this.previous = previous;
        }

        /// <summary>
        /// This method utilizes error checking for First Name, Last Name, and Phone Number fields.
        /// The submit button takes the customer to the next screen.
        /// </summary>
        /// <param name="sender">Instance that represents the click of button</param>
        /// <param name="e">Instance that represents the event</param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(firstText.Text) ||
              string.IsNullOrWhiteSpace(lastText.Text) ||
              string.IsNullOrWhiteSpace(phoneText.Text))
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
            try
            {
                newCustomer = new Customer(firstText.Text, lastText.Text, Int64.Parse(fixedPhone), new Order("Carryout"));

            }
            catch
            {
                errorLabel.Text = "A required field is invalid";
                errorLabel.Visible = true;
                return;
            }
            if (next == "Pizza")
            {

                PizzaForm f = new PizzaForm(newCustomer, new CarryoutInfo("Pizza", previous));
                Hide();
                f.ShowDialog();

            }
            else if (next == "Sides")
            {
                Sides f = new Sides(newCustomer, new CarryoutInfo("Sides", previous));
                Hide();
                f.ShowDialog();
            }
            else
            {
                OrderDrinks f = new OrderDrinks(newCustomer, new CarryoutInfo("Drinks", previous));
                Hide();
                f.ShowDialog();
            }
        }

        /// <summary>
        /// This method sends the customer back to the previous page.
        /// </summary>
        /// <param name="sender">Instance that represents the click of button</param>
        /// <param name="e">Instance that represents the event</param>
        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            previous.Show();
        }

        /// <summary>
        /// This method sends the user or guest to the home page.
        /// </summary>
        /// <param name="sender">Instance that represents the click of button</param>
        /// <param name="e">Instance that represents the event</param>
        private void pictureBox12_Click(object sender, EventArgs e)
        {
            if (newCustomer != null && newCustomer.loggedIn)
            {
                Form1 f = new Form1(newCustomer);
                Hide();
                f.ShowDialog();
            }
            else
            {
                Form1 f = new Form1();
                Hide();
                f.ShowDialog();
            }
        }

        /// <summary>
        /// This method signs the user in or logs the user out.
        /// </summary>
        /// <param name="sender">Instance that represents the click of button</param>
        /// <param name="e">Instance that represents the event</param>
        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            new Form1().ShowDialog();
        }
    }
}
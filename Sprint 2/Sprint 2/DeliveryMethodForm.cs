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
    /// This class contains relevant methods and variables for the DeliveryMethodForm.
    /// </summary>
    public partial class DeliveryMethodForm : Form
    {
        private string choice;
        private Customer u;
        public string nextScreen { get; }

        /// <summary>
        /// The first overloaded constructor for the DeliveryMethodForm
        /// </summary>
        /// <param name="next">String representing the next form</param>
        public DeliveryMethodForm(string next)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            nextScreen = next;
        }

        /// <summary>
        /// The second overloaded constructor for the DeliveryMethodForm
        /// </summary>
        /// <param name="next">String representing the next form</param>
        /// <param name="u">User instance for user</param>
        public DeliveryMethodForm(string next, User u)
        {
            InitializeComponent();
            this.u = u;
            StartPosition = FormStartPosition.CenterScreen;
            nextScreen = next;
            if (u != null && u.loggedIn)
            {
                buttonChange("Log Out");
            }
        }

        /// <summary>
        /// This method selects either home delivery or carryout.
        /// </summary>
        /// <param name="sender">Instance that represents the click of button</param>
        /// <param name="e">Instance that represents the event</param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (u != null)
            {
                if (radioButton1.Checked)
                {
                    Form p = new Form();
                    choice = "Delivery";
                    if(nextScreen == "Pizza")
                    {
                        u.currentOrder = new Order(choice);
                        p = new PizzaForm(u, this);
                    }
                    else if(nextScreen == "Sides")
                    {
                        u.currentOrder = new Order(choice);
                        p = new Sides(u, this);
                    }
                    else if(nextScreen == "Drinks")
                    {
                        u.currentOrder = new Order(choice);
                        p = new OrderDrinks(u, this);
                    }
                    Hide();
                    p.ShowDialog();
                }
                else if (radioButton2.Checked)
                {
                    Form p = new Form();
                    choice = "Carryout";
                    if (nextScreen == "Pizza")
                    {
                        u.currentOrder = new Order(choice);
                        p = new PizzaForm(u, this);
                    }
                    else if (nextScreen == "Sides")
                    {
                        u.currentOrder = new Order(choice);
                        p = new Sides(u, this);
                    }
                    else if (nextScreen == "Drinks")
                    {
                        u.currentOrder = new Order(choice);
                        p = new OrderDrinks(u, this);
                    }
                    Hide();
                    p.ShowDialog();
                }
            }
            else
            {
                if (radioButton1.Checked)
                {
                    choice = "Delivery";
                    DeliveryInfo p = new DeliveryInfo(nextScreen, this);
                    Hide();
                    p.ShowDialog();
                }
                else if (radioButton2.Checked)
                {
                    choice = "Carryout";
                    CarryoutInfo p = new CarryoutInfo(nextScreen, this);
                    Hide();
                    p.ShowDialog();
                }
            }

        }

        /// <summary>
        /// This method changes the choice to the Delivery form.
        /// </summary>
        /// <param name="sender">Instance that represents the click of button</param>
        /// <param name="e">Instance that represents the event</param>
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            choice = "Delivery";
        }

        /// <summary>
        /// This method changes the choice to the Pickup form.
        /// </summary>
        /// <param name="sender">Instance that represents the click of button</param>
        /// <param name="e">Instance that represents the event</param>
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            choice = "Pickup";
        }

        /// <summary>
        /// This method signs the user in or logs the user out.
        /// </summary>
        /// <param name="sender">Instance that represents the click of button</param>
        /// <param name="e">Instance that represents the event</param>
        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.Text == "Sign In")
            {
                Form2 loginScreen = new Form2();
                Hide();
                loginScreen.ShowDialog();
            }
            if (button3.Text == "Log Out")
            {
                buttonChange("Sign In");
                u.loggedIn = false;
                Hide();
                new Form1().ShowDialog();
            }
        }

        /// <summary>
        /// This method changes the text of button3.
        /// </summary>
        /// <param name="newText">String instance representing the new text</param>
        public void buttonChange(string newText)
        {
            button3.Text = newText;
        }

        /// <summary>
        /// This method returns the user to the home page.
        /// </summary>
        /// <param name="sender">Instance that represents the click of button</param>
        /// <param name="e">Instance that represents the event</param>
        private void pictureBox12_Click(object sender, EventArgs e)
        {
            if (u != null && u.loggedIn)
            {
                Form1 f = new Form1(u);
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
    }
}
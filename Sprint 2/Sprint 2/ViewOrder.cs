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
    /// This class contains relevant methods and variables for the ViewOrder form.
    /// </summary>
    public partial class ViewOrder : Form
    {
        public Customer c { get; set; }
        private Form previous;
        private Form2 loginScreen;

        /// <summary>
        /// The overloaded constructor of the ViewOrder class
        /// </summary>
        /// <param name="c">Customer instance called c</param>
        /// <param name="previous">Form instance relating to the previous form</param>
        public ViewOrder(Customer c, Form previous)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            this.c = c;
            this.previous = previous;
            getOrder();
            if (c.loggedIn)
            {
                buttonChange("Log Out");
            }
        }

        /// <summary>
        /// This method logs the user out or signs the user in.
        /// </summary>
        /// <param name="sender">Instance that represents the click of button</param>
        /// <param name="e">Instance that represents the event</param>
        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.Text == "Sign In")
            {
                loginScreen = new Form2();
                Hide();
                loginScreen.ShowDialog();
            }
            if (button3.Text == "Log Out")
            {
                buttonChange("Sign In");
                c.loggedIn = false;
                Hide();
                new Form1().ShowDialog();
            }
        }

        /// <summary>
        /// This method changes the text of button3.
        /// </summary>
        /// <param name="newText">The new text of button3</param>
        public void buttonChange(string newText)
        {
            button3.Text = newText;
        }

        /// <summary>
        /// This method sends the user to the home screen.
        /// </summary>
        /// <param name="sender">Instance that represents the click of button</param>
        /// <param name="e">Instance that represents the event</param>
        private void pictureBox12_Click(object sender, EventArgs e)
        {
            if (c != null && c.loggedIn)
            {
                Form1 f = new Form1(c);
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
        /// This method takes the user to the previous screen.
        /// </summary>
        /// <param name="sender">Instance that represents the click of button</param>
        /// <param name="e">Instance that represents the event</param>
        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            previous.Show();
        }

        /// <summary>
        /// This method adds the order to the listbox of the form and calculates the order.
        /// </summary>
        public void getOrder()
        {
            if (c.currentOrder != null)
            {

                List<Pizza> p = c.currentOrder.pizzas;
                List<Side> s = c.currentOrder.sides;
                List<Drink> d = c.currentOrder.drinks;
                for (int i = 0; i < p.Count; i++)
                {
                    if (i == p.Count)
                    {
                        break;
                    }
                    else
                    {
                        listBox1.Items.Add(p[i].size + " Pizza" + p[i].crust + " " + p[i].cheese + "\n $" + p[i].pizzaPrice);
                        for (int j = 0; j < p[i].toppings.Count; j++)
                        {
                            if (j == 0)
                            {
                                listBox1.Items.Add("Topping " + (j + 1) + p[i].toppings[j].name + " " + p[i].toppings[j].location + " $0");
                            }
                            else
                            {
                                p[i].toppings[j].setToppPrice();
                                listBox1.Items.Add("Topping " + (j + 1) + p[i].toppings[j].name + " " + p[i].toppings[j].location + " $" + p[i].toppings[j].toppingPrice);
                            }
                        }
                    }
                }
                for (int i = 0; i < s.Count; i++)
                {
                    if (i == s.Count)
                    {
                        break;
                    }
                    else
                    {
                        if (s[i].name == "Eight-Inch Breadsticks" || s[i].name == "Bite-Sized Breadsticks")
                        {
                            s[i].sidePrice = (2 * s[i].quantity);
                        }
                        else if (s[i].name == "Giant Cookie")
                        {
                            s[i].sidePrice = (4 * s[i].quantity);
                        }
                        listBox1.Items.Add(s[i].quantity + " " + s[i].name + " " + s[i].customization + "\n $" + s[i].sidePrice);
                    }
                }
                for (int i = 0; i < d.Count; i++)
                {
                    if (i == d.Count)
                    {
                        break;
                    }
                    else
                    {
                        if (d[i].size == "Cup(s)")
                        {
                            d[i].drinkPrice = 0;
                        }
                        listBox1.Items.Add(d[i].quantity + " " + d[i].size + " " + d[i].name + "\n $" + d[i].drinkPrice);
                    }
                }
            }
            SubtotalLabel.Text += c.currentOrder.orderTotal();
            TaxLabel.Text += c.currentOrder.orderTotal()*.06;
            TotalLabel.Text += c.currentOrder.orderTotal() * 1.06; 
        }

        /// <summary>
        /// This method "sends" the order to Mom and Pop and displays a message.
        /// </summary>
        /// <param name="sender">Instance that represents the click of button</param>
        /// <param name="e">Instance that represents the event</param>
        private void button1_Click(object sender, EventArgs e)
        {
            submitButton.Visible = true;
        }

        /// <summary>
        /// This method checks whether or not radioButton2 has been changed.
        /// The dropdown box will be enabled when it is checked; otherwise, the dropdown box will be disabled.
        /// </summary>
        /// <param name="sender">Instance that represents the click of button</param>
        /// <param name="e">Instance that represents the event</param>
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                comboBox1.Enabled = true;
            }
            else
            {
                comboBox1.Enabled = false;
            }   
        }
    }
}
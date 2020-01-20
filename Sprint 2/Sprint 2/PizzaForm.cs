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
    /// This class contains relevant methods and variables for the PizzaForm.
    /// </summary>
    public partial class PizzaForm : Form
    {
        private Form2 loginScreen;
        private Customer c;
        private Form previous;
        private Pizza p;

        /// <summary>
        /// The first overloaded constructor of the PizzaForm class
        /// </summary>
        /// <param name="c">Customer instance called c</param>
        /// <param name="previous">Form pertaining to the previous form</param>
        public PizzaForm(Customer c, Form previous)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            this.previous = previous;
            this.c = c;
            getOrder();
            if (c.loggedIn)
            {
                buttonChange("Log Out");
            }
        }

        /// <summary>
        /// The second overloaded constructor for the PizzaForm class
        /// </summary>
        /// <param name="c">Customer instance called c</param>
        public PizzaForm(Customer c)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            this.c = c;
            getOrder();
            if (c.loggedIn)
            {
                buttonChange("Log Out");
            }
        }

        /// <summary>
        /// This method returns the user to the home screen.
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
        /// This method signs the user out or logs the user in.
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
        /// This method adds the pizza to the order and continues to the OrderToppings form.
        /// </summary>
        /// <param name="sender">Instance that represents the click of button</param>
        /// <param name="e">Instance that represents the event</param>
        private void button2_Click(object sender, EventArgs e)
        {
            p = new Pizza();
            if (thinCrust.Checked)
            {
                p.crust = "Thin Crust";
            }
            else if (regCrust.Checked)
            {
                p.crust = "Reg Crust";
            }
            else
            {
                p.crust = "Pan Crust";
            }
            if (smallPizza.Checked)
            {
                p.size = "Small";
            }
            else if (mediumPizza.Checked)
            {
                p.size = "Medium";
            }
            else if (largePizza.Checked)
            {
                p.size = "Large";
            }
            else
            {
                p.size = "X-Large";
            }
            if (regCheese.Checked)
            {
                p.cheese = "Regular Cheese";
            }
            else if (extraCheese.Checked)
            {
                p.cheese = "Extra Cheese";
                p.AddTopping(new Topping(p, p.cheese, "Whole"));
            }
            else
            {
                p.cheese = "No cheese";
            }
            if (p.size == "Small")
            {
                p.pizzaPrice = 4.00f;
            }
            else if (p.size == "Medium")
            {
                p.pizzaPrice = 6.00f;
            }
            else if (p.size == "Large")
            {
                p.pizzaPrice = 8.00f;
            }
            else
            {
                p.pizzaPrice = 10.00f;
            }
            c.currentOrder.AddPizza(p);
            Hide();
            new OrderToppings(c, this, p).ShowDialog();
        }

        /// <summary>
        /// This method adds the order to the listbox of the form.
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
                                listBox1.Items.Add("Topping " + (j + 1) + " " + p[i].toppings[j].name + " " + p[i].toppings[j].location + " $0");
                            }
                            else
                            {
                                p[i].toppings[j].setToppPrice();
                                listBox1.Items.Add("Topping " + (j + 1) + " " + p[i].toppings[j].name + " " + p[i].toppings[j].location + " $" + p[i].toppings[j].toppingPrice);
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
                label12.Text += c.currentOrder.orderTotal();
            }
        }
    }
}
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
    /// This class contains relevant methods and variables for the OrderDrinks form.
    /// </summary>
    public partial class OrderDrinks : Form
    {
        private Form2 loginScreen;
        private Customer c;
        private Form previous;

        /// <summary>
        /// The overloaded constructor for the OrderDrinks class
        /// </summary>
        /// <param name="c">Customer instance called c</param>
        /// <param name="previous">Form instance referring to the previous form</param>
        public OrderDrinks(Customer c, Form previous)
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
        /// This method signs the user in or logs the user out.
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
        /// This method returns the user to the home page.
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
        /// This method takes the user back to the Sides form.
        /// </summary>
        /// <param name="sender">Instance that represents the click of button</param>
        /// <param name="e">Instance that represents the event</param>
        private void button2_Click(object sender, EventArgs e)
        {
            Sides s = new Sides(c);
            Hide();
            s.ShowDialog();
        }

        /// <summary>
        /// This method adds the order to the listbox on the form.
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
                        listBox2.Items.Add(p[i].size + " Pizza" + p[i].crust + " " + p[i].cheese + "\n $" + p[i].pizzaPrice);
                        for (int j = 0; j < p[i].toppings.Count; j++)
                        {
                            if (j == 0)
                            {
                                listBox2.Items.Add("Topping " + (j + 1) + " " + p[i].toppings[j].name + " " + p[i].toppings[j].location + " $0");
                            }
                            else
                            {
                                p[i].toppings[j].setToppPrice();
                                listBox2.Items.Add("Topping " + (j + 1) + " " + p[i].toppings[j].name + " " + p[i].toppings[j].location + " $" + p[i].toppings[j].toppingPrice);
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
                        listBox2.Items.Add(s[i].quantity + " " + s[i].name + " " + s[i].customization + "\n $" + s[i].sidePrice);
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
                        if(d[i].size == "Cup(s)")
                        {
                            d[i].drinkPrice = 0;
                        }
                        listBox2.Items.Add(d[i].quantity + " " + d[i].size + " " + d[i].name + "\n $" + d[i].drinkPrice);
                    }
                }
                label13.Text += c.currentOrder.orderTotal();
            }
        }

        /// <summary>
        /// This method adds the drinks to the order.
        /// </summary>
        /// <param name="sender">Instance that represents the click of button</param>
        /// <param name="e">Instance that represents the event</param>
        private void button1_Click(object sender, EventArgs e)
        {
            int pepsiNum = 0;
            int lemonNum = 0;
            int waterNum = 0;
            try
            {
                if (pepsiText.Text != "")
                {
                    pepsiNum = int.Parse(pepsiText.Text);
                }
                if (lemonText.Text != "")
                {
                    lemonNum = int.Parse(lemonText.Text);
                }
                if (mizuText.Text != "")
                {
                    waterNum = int.Parse(mizuText.Text);
                }
            }
            catch
            {
                errorLabel.Visible = true;
                return;
            }
            if(pepsiNum > 0 && dropdown.SelectedItem == null)
            {
                errorLabel.Text = "Please select a Pepsi product";
                errorLabel.Visible = true;
                return;
            }
            if (pepsiNum > 0 && dropdown.SelectedItem != null)
            {
                if (Sbepis.Checked)
                {
                    c.currentOrder.drinks.Add(new Drink(dropdown.SelectedItem.ToString(), "S", pepsiNum));
                }
                else if (Mbepis.Checked)
                {
                    c.currentOrder.drinks.Add(new Drink(dropdown.SelectedItem.ToString(), "M", pepsiNum));
                }
                else if (Lbepis.Checked)
                {
                    c.currentOrder.drinks.Add(new Drink(dropdown.SelectedItem.ToString(), "L", pepsiNum));
                }
            }
            if (lemonNum > 0)
            {
                if (Slemon.Checked)
                {
                    c.currentOrder.drinks.Add(new Drink("Lemonade", "S", lemonNum));
                }
                else if (Mlemon.Checked)
                {
                    c.currentOrder.drinks.Add(new Drink("Lemonade", "M", lemonNum));
                }
                else if (Llemon.Checked)
                {
                    c.currentOrder.drinks.Add(new Drink("Lemonade", "L", lemonNum));
                }
            }
            if (waterNum > 0)
            {
                if (FreeMizu.Checked)
                {
                    c.currentOrder.drinks.Add(new Drink("Water", "Cup(s)", waterNum));
                }
                else if (PaidMizu.Checked)
                {
                    c.currentOrder.drinks.Add(new Drink("Water", "Bottle(s)", waterNum));
                }
            }
            OrderDrinks d = new OrderDrinks(c, previous);
            Hide();
            d.ShowDialog();
        }

        /// <summary>
        /// This method error checks the drink quantity and sends the user to the View Order screen.
        /// </summary>
        /// <param name="sender">Instance that represents the click of button</param>
        /// <param name="e">Instance that represents the event</param>
        private void button4_Click(object sender, EventArgs e)
        {
            int pepsiNum = 0;
            int lemonNum = 0;
            int waterNum = 0;
            try
            {
                if (pepsiText.Text != "")
                {
                    pepsiNum = int.Parse(pepsiText.Text);
                }
                if (lemonText.Text != "")
                {
                    lemonNum = int.Parse(lemonText.Text);
                }
                if (mizuText.Text != "")
                {
                    waterNum = int.Parse(mizuText.Text);
                }
            }
            catch
            {
                errorLabel.Visible = true;
                return;
            }
            if (pepsiNum > 0 && dropdown.SelectedItem == null)
            {
                errorLabel.Text = "Please select a Pepsi product";
                errorLabel.Visible = true;
                return;
            }
            if (pepsiNum > 0 && dropdown.SelectedItem != null)
            {
                if (Sbepis.Checked)
                {
                    c.currentOrder.drinks.Add(new Drink(dropdown.SelectedItem.ToString(), "S", pepsiNum));
                }
                else if (Mbepis.Checked)
                {
                    c.currentOrder.drinks.Add(new Drink(dropdown.SelectedItem.ToString(), "M", pepsiNum));
                }
                else if (Lbepis.Checked)
                {
                    c.currentOrder.drinks.Add(new Drink(dropdown.SelectedItem.ToString(), "L", pepsiNum));
                }
            }
            if (lemonNum > 0)
            {
                if (Slemon.Checked)
                {
                    c.currentOrder.drinks.Add(new Drink("Lemonade", "S", lemonNum));
                }
                else if (Mlemon.Checked)
                {
                    c.currentOrder.drinks.Add(new Drink("Lemonade", "M", lemonNum));
                }
                else if (Llemon.Checked)
                {
                    c.currentOrder.drinks.Add(new Drink("Lemonade", "L", lemonNum));
                }
            }
            if (waterNum > 0)
            {
                if (FreeMizu.Checked)
                {
                    c.currentOrder.drinks.Add(new Drink("Water", "Cup(s)", waterNum));
                }
                else if (PaidMizu.Checked)
                {
                    c.currentOrder.drinks.Add(new Drink("Water", "Bottle(s)", waterNum));
                }
            }
            ViewOrder vo = new ViewOrder(c, this);
            Hide();
            vo.ShowDialog();
        }
    }
}
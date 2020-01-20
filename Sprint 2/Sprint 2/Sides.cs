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
    /// This class contains relevant methods and variables for the Sides form.
    /// </summary>
    public partial class Sides : Form
    {
        private Form2 loginScreen;
        private Customer c;
        private Form previous;

        /// <summary>
        /// The first overloaded constructor of the Sides Form
        /// </summary>
        /// <param name="c">Customer instance called c</param>
        /// <param name="previous">Form pertaining to the previous form</param>
        public Sides(Customer c, Form previous)
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
        /// The second overloaded constructor of the Sides class
        /// </summary>
        /// <param name="c">Customer instance called c</param>
        public Sides(Customer c)
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
        /// This method sends the user to the home page.
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
        /// This method sends the user back to the PizzaForm.
        /// </summary>
        /// <param name="sender">Instance that represents the click of button</param>
        /// <param name="e">Instance that represents the event</param>
        private void button2_Click(object sender, EventArgs e)
        {
            PizzaForm f = new PizzaForm(c);
            Hide();
            f.ShowDialog();
        }

        /// <summary>
        /// This method adds more sides to the order. 
        /// </summary>
        /// <param name="sender">Instance that represents the click of button</param>
        /// <param name="e">Instance that represents the event</param>
        private void button1_Click(object sender, EventArgs e)
        {
            int breadsticksNum = 0;
            int bitesizeNum = 0;
            int cookieNum = 0;
            try
            {
                if (EightQuantity.Text != "")
                {
                    breadsticksNum = int.Parse(EightQuantity.Text);
                }
                if (BiteQuantity.Text != "")
                {
                    bitesizeNum = int.Parse(BiteQuantity.Text);
                }
                if (CookieQuantity.Text != "")
                {
                    cookieNum = int.Parse(CookieQuantity.Text);
                }
            }
            catch
            {
                errorLabel.Visible = true;
                return;
            }
            if (breadsticksNum > 0)
            {
                if (EightGarlic.Checked)
                {
                    c.currentOrder.sides.Add(new Side("Eight-Inch Breadsticks", "w/ Garlic and Butter", breadsticksNum));
                }
                else if (EightPlain.Checked)
                {
                    c.currentOrder.sides.Add(new Side("Eight-Inch Breadsticks", "Plain", breadsticksNum));
                }
            }
            if (bitesizeNum > 0)
            {
                if (BiteGarlic.Checked)
                {
                    c.currentOrder.sides.Add(new Side("Bite-Sized Breadsticks", "w/ Garlic and Butter", bitesizeNum));
                }
                else if (BitePlain.Checked)
                {
                    c.currentOrder.sides.Add(new Side("Bite-Sized Breadsticks", "Plain", bitesizeNum));
                }
            }
            if (cookieNum > 0)
            {
                c.currentOrder.sides.Add(new Side("Giant Cookie", cookieNum));
            }
            Sides s = new Sides(c, new PizzaForm(c, new DeliveryMethodForm("Pizza")));
            Hide();
            s.ShowDialog();
        }

        /// <summary>
        /// This method adds sides to the listbox and continues to the OrderDrinks form.
        /// </summary>
        /// <param name="sender">Instance that represents the click of button</param>
        /// <param name="e">Instance that represents the event</param>
        private void button4_Click(object sender, EventArgs e)
        {
            int breadsticksNum = 0;
            int bitesizeNum = 0;
            int cookieNum = 0;
            try
            {
                if(EightQuantity.Text != "") {
                    breadsticksNum = int.Parse(EightQuantity.Text);
                }
                if (BiteQuantity.Text != "")
                {
                    bitesizeNum = int.Parse(BiteQuantity.Text);
                }
                if (CookieQuantity.Text != "")
                {
                    cookieNum = int.Parse(CookieQuantity.Text);
                }
            }
            catch
            {
                errorLabel.Visible = true;
                return;
            }
            if(breadsticksNum > 0)
            {
                if (EightGarlic.Checked)
                {
                    c.currentOrder.sides.Add(new Side("Eight-Inch Breadsticks", "w/ Garlic and Butter", breadsticksNum));
                }
                else if (EightPlain.Checked)
                {
                    c.currentOrder.sides.Add(new Side("Eight-Inch Breadsticks", "Plain", breadsticksNum));
                }
            }
            if (bitesizeNum > 0)
            {
                if (BiteGarlic.Checked)
                {
                    c.currentOrder.sides.Add(new Side("Bite-Sized Breadsticks", "w/ Garlic and Butter",  bitesizeNum));
                }
                else if (BitePlain.Checked)
                {
                    c.currentOrder.sides.Add(new Side("Bite-Sized Breadsticks", "Plain", bitesizeNum));
                }
            }
            if (cookieNum > 0)
            {
                c.currentOrder.sides.Add(new Side("Giant Cookie", cookieNum));
            }
            OrderDrinks d = new OrderDrinks(c, this);
            Hide();
            d.ShowDialog();
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
                        if (d[i].size == "Cup(s)")
                        {
                            d[i].drinkPrice = 0;
                        }
                        listBox2.Items.Add(d[i].quantity + " " + d[i].size + " " + d[i].name + "\n $" + d[i].drinkPrice);
                    }
                }
                label13.Text += c.currentOrder.orderTotal();
            }
        }
    }
}
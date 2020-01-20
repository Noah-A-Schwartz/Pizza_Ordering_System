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
    /// This class contains relevant methods and variables to the OrderToppings Form.
    /// </summary>
    public partial class OrderToppings : Form
    {
        private Form2 loginScreen;
        private Customer c;
        Pizza p;
        private Form previous;

        /// <summary>
        /// The overloaded constructor for the OrderToppings clas
        /// </summary>
        /// <param name="c">Customer instance called c</param>
        /// <param name="previous">Form instance of the previous form</param>
        /// <param name="p">Pizza instance called p</param>
        public OrderToppings(Customer c, Form previous, Pizza p)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            this.c = c;
            this.previous = previous;
            this.p = p;
            getOrder();
            if (c.loggedIn)
            {
                buttonChange("Log Out");
            }
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
                                listBox2.Items.Add(p[i].toppings[j].name + " " + p[i].toppings[j].location + " $0");
                            }
                            else
                            {
                                p[i].toppings[j].setToppPrice();
                                listBox2.Items.Add(p[i].toppings[j].name + " " + p[i].toppings[j].location + " $" + p[i].toppings[j].toppingPrice);
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
                label16.Text += c.currentOrder.orderTotal();
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
        /// This method adds another pizza to the order.
        /// </summary>
        /// <param name="sender">Instance that represents the click of button</param>
        /// <param name="e">Instance that represents the event</param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (Lpepperoni.Checked)
            {
                p.AddTopping(new Topping(p, "Pepperoni", "Left"));
            }
            else if (Wpepperoni.Checked)
            {
                p.AddTopping(new Topping(p, "Pepperoni", "Whole"));
            }
            else if (Rpepperoni.Checked)
            {
                p.AddTopping(new Topping(p, "Pepperoni", "Right"));
            }
            if (Lsas.Checked)
            {
                p.AddTopping(new Topping(p, "Sausage", "Left"));
            }
            else if (Wsas.Checked)
            {
                p.AddTopping(new Topping(p, "Sausage", "Whole"));
            }
            else if (Rsas.Checked)
            {
                p.AddTopping(new Topping(p, "Sausage", "Right"));
            }
            if (Lham.Checked)
            {
                p.AddTopping(new Topping(p, "Ham", "Left"));
            }
            else if (Wham.Checked)
            {
                p.AddTopping(new Topping(p, "Ham", "Whole"));
            }
            else if (Rham.Checked)
            {
                p.AddTopping(new Topping(p, "Ham", "Right"));
            }
            if (Lgpep.Checked)
            {
                p.AddTopping(new Topping(p, "Green Pepper", "Left"));
            }
            else if (Wgpep.Checked)
            {
                p.AddTopping(new Topping(p, "Green Pepper", "Whole"));
            }
            else if (Rgpep.Checked)
            {
                p.AddTopping(new Topping(p, "Green Pepper", "Right"));
            }
            if (Lon.Checked)
            {
                p.AddTopping(new Topping(p, "Onion", "Left"));
            }
            else if (Won.Checked)
            {
                p.AddTopping(new Topping(p, "Onion", "Whole"));
            }
            else if (Ron.Checked)
            {
                p.AddTopping(new Topping(p, "Onion", "Right"));
            }
            if (Ltom.Checked)
            {
                p.AddTopping(new Topping(p, "Tomato", "Left"));
            }
            else if (Wtom.Checked)
            {
                p.AddTopping(new Topping(p, "Tomato", "Whole"));
            }
            else if (Rtom.Checked)
            {
                p.AddTopping(new Topping(p, "Tomato", "Right"));
            }
            if (Lmush.Checked)
            {
                p.AddTopping(new Topping(p, "Mushroom", "Left"));
            }
            else if (Wmush.Checked)
            {
                p.AddTopping(new Topping(p, "Mushroom", "Whole"));
            }
            else if (Rmush.Checked)
            {
                p.AddTopping(new Topping(p, "Mushroom", "Right"));
            }
            if (Lpin.Checked)
            {
                p.AddTopping(new Topping(p, "Pineapple", "Left"));
            }
            else if (Wpin.Checked)
            {
                p.AddTopping(new Topping(p, "Pineapple", "Whole"));
            }
            else if (Rpin.Checked)
            {
                p.AddTopping(new Topping(p, "Pineapple", "Right"));
            }
            Hide();
            new PizzaForm(c, this).ShowDialog();
        }

        /// <summary>
        /// This method returns the user to the home screen.
        /// </summary>
        /// <param name="sender">Instance that represents the click of button</param>
        /// <param name="e">Instance that represents the event</param>
        private void pictureBox12_Click(object sender, EventArgs e)
        {
            if(c != null && c.loggedIn)
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
        /// This button continues the user to Sides after adding the sides to the order.
        /// </summary>
        /// <param name="sender">Instance that represents the click of button</param>
        /// <param name="e">Instance that represents the event</param>
        private void button4_Click(object sender, EventArgs e)
        {
            if (Lpepperoni.Checked)
            {
                p.AddTopping(new Topping(p, "Pepperoni", "Left"));
            }
            else if (Wpepperoni.Checked)
            {
                p.AddTopping(new Topping(p, "Pepperoni", "Whole"));
            }
            else if (Rpepperoni.Checked)
            {
                p.AddTopping(new Topping(p, "Pepperoni", "Right"));
            }
            if (Lsas.Checked)
            {
                p.AddTopping(new Topping(p, "Sausage", "Left"));
            }
            else if (Wsas.Checked)
            {
                p.AddTopping(new Topping(p, "Sausage", "Whole"));
            }
            else if (Rsas.Checked)
            {
                p.AddTopping(new Topping(p, "Sausage", "Right"));
            }
            if (Lham.Checked)
            {
                p.AddTopping(new Topping(p, "Ham", "Left"));
            }
            else if (Wham.Checked)
            {
                p.AddTopping(new Topping(p, "Ham", "Whole"));
            }
            else if (Rham.Checked)
            {
                p.AddTopping(new Topping(p, "Ham", "Right"));
            }
            if (Lgpep.Checked)
            {
                p.AddTopping(new Topping(p, "Green Pepper", "Left"));
            }
            else if (Wgpep.Checked)
            {
                p.AddTopping(new Topping(p, "Green Pepper", "Whole"));
            }
            else if (Rgpep.Checked)
            {
                p.AddTopping(new Topping(p, "Green Pepper", "Right"));
            }
            if (Lon.Checked)
            {
                p.AddTopping(new Topping(p, "Onion", "Left"));
            }
            else if (Won.Checked)
            {
                p.AddTopping(new Topping(p, "Onion", "Whole"));
            }
            else if (Ron.Checked)
            {
                p.AddTopping(new Topping(p, "Onion", "Right"));
            }
            if (Ltom.Checked)
            {
                p.AddTopping(new Topping(p, "Tomato", "Left"));
            }
            else if (Wtom.Checked)
            {
                p.AddTopping(new Topping(p, "Tomato", "Whole"));
            }
            else if (Rtom.Checked)
            {
                p.AddTopping(new Topping(p, "Tomato", "Right"));
            }
            if (Lmush.Checked)
            {
                p.AddTopping(new Topping(p, "Mushroom", "Left"));
            }
            else if (Wmush.Checked)
            {
                p.AddTopping(new Topping(p, "Mushroom", "Whole"));
            }
            else if (Rmush.Checked)
            {
                p.AddTopping(new Topping(p, "Mushroom", "Right"));
            }
            if (Lpin.Checked)
            {
                p.AddTopping(new Topping(p, "Pineapple", "Left"));
            }
            else if (Wpin.Checked)
            {
                p.AddTopping(new Topping(p, "Pineapple", "Whole"));
            }
            else if (Rpin.Checked)
            {
                p.AddTopping(new Topping(p, "Pineapple", "Right"));
            }
            Sides s = new Sides(c, new PizzaForm(c, new DeliveryMethodForm("Pizza")));
            Hide();
            s.ShowDialog();
        }

        /// <summary>
        /// This method checks if the checkbox for Pepporini is changed.
        /// </summary>
        /// <param name="sender">Instance that represents the click of button</param>
        /// <param name="e">Instance that represents the event</param>
        private void chPep_CheckedChanged(object sender, EventArgs e)
        {
            if (chPep.Checked)
            {
                Lpepperoni.Enabled = true;
                Wpepperoni.Enabled = true;
                Rpepperoni.Enabled = true;
                Wpepperoni.Checked = true; 
            }
            else
            {
                Lpepperoni.Checked = false;
                Wpepperoni.Checked = false;
                Rpepperoni.Checked = false;
                Lpepperoni.Enabled = false;
                Wpepperoni.Enabled = false;
                Rpepperoni.Enabled = false;
            }
        }

        /// <summary>
        /// This method checks if the checkbox for Sausage has changed.
        /// </summary>
        /// <param name="sender">Instance that represents the click of button</param>
        /// <param name="e">Instance that represents the event</param>
        private void chSas_CheckedChanged(object sender, EventArgs e)
        {
            if (chSas.Checked)
            {
                Lsas.Enabled = true;
                Wsas.Enabled = true;
                Rsas.Enabled = true;
                Wsas.Checked = true;
            }
            else 
            { 
                Lsas.Checked = false;
                Wsas.Checked = false;
                Rsas.Checked = false;
                Lsas.Enabled = false;
                Wsas.Enabled = false;
                Rsas.Enabled = false;
            }
        }

        /// <summary>
        /// This method checks if the checkbox for Ham has changed.
        /// </summary>
        /// <param name="sender">Instance that represents the click of button</param>
        /// <param name="e">Instance that represents the event</param>
        private void chHam_CheckedChanged(object sender, EventArgs e)
        {
            if (chHam.Checked)
            {
                Lham.Enabled = true;
                Wham.Enabled = true;
                Rham.Enabled = true;
                Wham.Checked = true;
            }    
            else 
            {    
                Lham.Checked = false;
                Wham.Checked = false;
                Rham.Checked = false;
                Lham.Enabled = false;
                Wham.Enabled = false;
                Rham.Enabled = false;
            }
        }

        /// <summary>
        /// This method checks if the checkbox for Green Pepper has changed.
        /// </summary>
        /// <param name="sender">Instance that represents the click of button</param>
        /// <param name="e">Instance that represents the click of button</param>
        private void chGpep_CheckedChanged(object sender, EventArgs e)
        {
            if (chGpep.Checked)
            {
                Lgpep.Enabled = true;
                Wgpep.Enabled = true;
                Rgpep.Enabled = true;
                Wgpep.Checked = true;
            }    
            else 
            {    
                Lgpep.Checked = false;
                Wgpep.Checked = false;
                Rgpep.Checked = false;
                Lgpep.Enabled = false;
                Wgpep.Enabled = false;
                Rgpep.Enabled = false;
            }
        }

        /// <summary>
        /// This method checks if the checkbox for Onion has changed.
        /// </summary>
        /// <param name="sender">Instance that represents the click of button</param>
        /// <param name="e">Instance that represents the event</param>
        private void chOn_CheckedChanged(object sender, EventArgs e)
        {
            if (chOn.Checked)
            {
                Lon.Enabled = true;
                Won.Enabled = true;
                Ron.Enabled = true;
                Won.Checked = true;
            }    
            else 
            {    
                Lon.Checked = false;
                Won.Checked = false;
                Ron.Checked = false;
                Lon.Enabled = false;
                Won.Enabled = false;
                Ron.Enabled = false;
            }
        }

        /// <summary>
        /// This method checks if the textbox for Tomato has changed.
        /// </summary>
        /// <param name="sender">Instance that represents the click of button</param>
        /// <param name="e">Instance that represents the event</param>
        private void chTom_CheckedChanged(object sender, EventArgs e)
        {
            if (chTom.Checked)
            {
                Ltom.Enabled = true;
                Wtom.Enabled = true;
                Rtom.Enabled = true;
                Wtom.Checked = true;
            }    
            else 
            {    
                Ltom.Checked = false;
                Wtom.Checked = false;
                Rtom.Checked = false;
                Ltom.Enabled = false;
                Wtom.Enabled = false;
                Rtom.Enabled = false;
            }
        }

        /// <summary>
        /// This method checks if the checkbox for Mushrooms has changed.
        /// </summary>
        /// <param name="sender">Instance that represents the click of button</param>
        /// <param name="e">Instance that represents the event</param>
        private void chMus_CheckedChanged(object sender, EventArgs e)
        {
            if (chMus.Checked)
            {
                Lmush.Enabled = true;
                Wmush.Enabled = true;
                Rmush.Enabled = true;
                Wmush.Checked = true;
            }    
            else 
            {    
                Lmush.Checked = false;
                Wmush.Checked = false;
                Rmush.Checked = false;
                Lmush.Enabled = false;
                Wmush.Enabled = false;
                Rmush.Enabled = false;
            }
        }

        /// <summary>
        /// This method checks if the checkbox for Pineapple has changed.
        /// </summary>
        /// <param name="sender">Instance that represents the click of button</param>
        /// <param name="e">Instance that represents the event</param>
        private void chPin_CheckedChanged(object sender, EventArgs e)
        {
            if (chPin.Checked)
            {
                Lpin.Enabled = true;
                Wpin.Enabled = true;
                Rpin.Enabled = true;
                Wpin.Checked = true;
            }    
            else 
            {    
                Lpin.Checked = false;
                Wpin.Checked = false;
                Rpin.Checked = false;
                Lpin.Enabled = false;
                Wpin.Enabled = false;
                Rpin.Enabled = false;
            }
        }

        /// <summary>
        /// This method sends the user to the home page.
        /// </summary>
        /// <param name="sender">Instance that represents the click of button</param>
        /// <param name="e">Instance that represents the event</param>
        private void pictureBox4_Click(object sender, EventArgs e)
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
    }
}
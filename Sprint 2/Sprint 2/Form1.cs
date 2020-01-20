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
    /// This class contains relevant methods and variables for Form1.
    /// </summary>
    public partial class Form1 : Form
    {
        private Form2 loginScreen;
        private string next;
        private User u;
        private Customer c;

        /// <summary>
        /// Default constructor for Form1
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            c = null;
        }

        /// <summary>
        /// First overloaded constructor for Form1
        /// </summary>
        /// <param name="c">Customer instance called c</param>
        public Form1(Customer c)
        {
            InitializeComponent();
            this.c = c;
            this.StartPosition = FormStartPosition.CenterScreen;
            if (c != null && c.loggedIn)
            {
                buttonChange("Log Out");
            }
        }

        /// <summary>
        /// The second overloaded constructor for Form1
        /// </summary>
        /// <param name="u">User instance called u</param>
        public Form1(User u)
        {
            InitializeComponent();
            this.u = u;
            this.StartPosition = FormStartPosition.CenterScreen;
            if (u != null && u.loggedIn)
            {
                buttonChange("Log Out");
            }
        }

        /// <summary>
        /// This method signs the user in or logs the user out.
        /// </summary>
        /// <param name="sender">Instance that represents the click of button</param>
        /// <param name="e">Instance that represents the event</param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Sign In")
            {
                loginScreen = new Form2();
                Hide();
                loginScreen.ShowDialog();
            }
            if (button1.Text == "Log Out")
            {
                buttonChange("Sign In");
                c.loggedIn = false;
                Hide();
                new Form1().ShowDialog();
            }
        }

        /// <summary>
        /// This method changes the text of button1.
        /// </summary>
        /// <param name="newText">The new text for button1</param>
        public void buttonChange(string newText)
        {
            button1.Text = newText;
        }

        /// <summary>
        /// This method closes the form.
        /// </summary>
        /// <param name="e">Instance that represents the event</param>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            Application.Exit();
        }

        /// <summary>
        /// This method sends the user to the Pizza Form.
        /// </summary>
        /// <param name="sender">Instance that represents the click of button</param>
        /// <param name="e">Instance that represents the event</param>
        private void button2_Click(object sender, EventArgs e)
        {
            next = "Pizza";
            DeliveryMethodForm d;
            PizzaForm p;
            if (c == null)
            {
                d = new DeliveryMethodForm(next, u);
                Hide();
                d.ShowDialog();

            }
            else if (c.currentOrder != null)
            {
                p = new PizzaForm(c);
                Hide();
                p.ShowDialog();
            }
            else if (u != null)
            {
                d = new DeliveryMethodForm(next, u);
                Hide();
                d.ShowDialog();
            }
            else
            {
                d = new DeliveryMethodForm(next);
                Hide();
                d.ShowDialog();
            }
        }

        /// <summary>
        /// This method sends the user to the Sides Form.
        /// </summary>
        /// <param name="sender">Instance that represents the click of button</param>
        /// <param name="e">Instance that represents the event</param>
        private void button3_Click(object sender, EventArgs e)
        {
            next = "Sides";
            DeliveryMethodForm d;
            Sides s;
            if (c == null)
            {
                d = new DeliveryMethodForm(next, u);
                Hide();
                d.ShowDialog();

            }
            else if (c.currentOrder != null)
            {
                s = new Sides(c, new PizzaForm(c));
                Hide();
                s.ShowDialog();
            }
            else if (u != null)
            {
                d = new DeliveryMethodForm(next, u);
                Hide();
                d.ShowDialog();
            }
            else
            {
                d = new DeliveryMethodForm(next);
                Hide();
                d.ShowDialog();
            }
        }

        /// <summary>
        /// This method sends the user to the Drink Form.
        /// </summary>
        /// <param name="sender">Instance that represents the click of button</param>
        /// <param name="e">Instance that represents the event</param>
        private void button4_Click(object sender, EventArgs e)
        {
            next = "Drinks";
            OrderDrinks od;
            DeliveryMethodForm d;
            if (c == null)
            {
                d = new DeliveryMethodForm(next, u);
                Hide();
                d.ShowDialog();
            }
            else if (c.currentOrder != null)
            {
                od = new OrderDrinks(c, new PizzaForm(c));
                Hide();
                od.ShowDialog();
            }
            else if (u != null)
            {
                d = new DeliveryMethodForm(next, u);
                Hide();
                d.ShowDialog();
            }
            else
            {
                d = new DeliveryMethodForm(next);
                Hide();
                d.ShowDialog();
            }
        }
    }
}
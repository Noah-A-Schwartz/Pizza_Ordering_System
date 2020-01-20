using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Sprint_2
{
    /// <summary>
    /// This class contains relevant methods and variables for Form2.
    /// </summary>
    public partial class Form2 : Form
    {
        private string username;
        private string password;
        private bool usernameValid;
        private bool passwordValid;
        private string tempFirst;
        private string tempLast;
        private string tempEmail;
        private string tempAddress;
        private int tempZip;
        private long tempPhone;
        private bool fileExists = false;
        private User newUser;

        /// <summary>
        /// The default constructor for Form2
        /// </summary>
        public Form2()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        /// <summary>
        /// This method logs the user in.
        /// </summary>
        /// <param name="sender">Instance that represents the click of button</param>
        /// <param name="e">Instance that represents the event</param>
        private void button3_Click(object sender, EventArgs e)
        {
            Check();
            if (usernameValid && passwordValid)
            {
                newUser.loggedIn = true;
                Form1 menu = new Form1(newUser);
                Hide();
                menu.ShowDialog();
            }
            else if(fileExists)
            {
                loginErrorLabel.Text = "Username and/or Password is incorrect";
                loginErrorLabel.Visible = true;
            }
        }

        /// <summary>
        /// This method continues the user as a guest.
        /// </summary>
        /// <param name="sender">Instance that represents the click of button</param>
        /// <param name="e">Instance that represents the event</param>
        private void button1_Click(object sender, EventArgs e)
        {
            Form1 menu = new Form1();
            Hide();
            menu.ShowDialog();
        }

        /// <summary>
        /// This method checks the username and password validity.
        /// </summary>
        private void Check()
        {
            username = userText.Text;
            password = passText.Text;
            try
            {
                bool end = false;
                StreamReader sr = new StreamReader(Application.UserAppDataPath + "/AccountInfo.txt");
                while (!end)
                {
                    string line = sr.ReadLine();
                    if (sr.EndOfStream)
                    {
                        end = true;
                    }
                    if(line == username)
                    {
                        usernameValid = true;
                    }
                    if (usernameValid)
                    {
                        line = sr.ReadLine();
                        if(line == password)
                        {
                            passwordValid = true;
                            SetUser(sr);
                            return;
                        }
                        else
                        {
                            usernameValid = false;
                        }
                    }
                    while (line != " " && !sr.EndOfStream)
                    {
                        line = sr.ReadLine();
                    }
                }
                sr.Close();
                fileExists = true;
            }
            catch(FileNotFoundException)
            {
                loginErrorLabel.Text = "No Current Users Exist";
                loginErrorLabel.Visible = true;
            }
        }

        /// <summary>
        /// This method sets the user information to a particular user.
        /// </summary>
        /// <param name="sr">StreamReader instance called sr</param>
        public void SetUser(StreamReader sr)
        {
            tempFirst = sr.ReadLine();
            tempLast = sr.ReadLine();
            tempPhone = Int64.Parse(sr.ReadLine());
            tempEmail = sr.ReadLine();
            tempAddress = sr.ReadLine();
            tempZip = int.Parse(sr.ReadLine());
            newUser = new User(tempFirst, tempLast, tempPhone, username, password, tempEmail, tempAddress, tempZip);
        }

        /// <summary>
        /// This method closes the form.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            Application.Exit();
        }

        /// <summary>
        /// This method sends the user to the Create an Account page.
        /// </summary>
        /// <param name="sender">Instance that represents the click of button</param>
        /// <param name="e">Instance that represents the event</param>
        private void button2_Click(object sender, EventArgs e)
        {
            SignUp form = new SignUp();
            form.SetPrevious(this);
            Hide();
            form.ShowDialog();
        }
    }
}
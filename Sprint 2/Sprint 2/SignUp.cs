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
    /// This class contains relevant methods and variables to the SignUp Form.
    /// </summary>
    public partial class SignUp : Form
    {
        private string first;
        private string last;
        private string email;
        private string phone;
        private string username;
        private string password;
        private string address;
        private string zip;
        private Form previousForm;
        private User newUser;

        /// <summary>
        /// The default constructor of the SignUp form
        /// </summary>
        public SignUp()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        /// <summary>
        /// This method sends the user to the previous page.
        /// </summary>
        /// <param name="sender">Instance that represents the click of button</param>
        /// <param name="e">Instance that represents the event</param>
        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            previousForm.Show();
        }

        /// <summary>
        /// This method creates the account for the user.
        /// </summary>
        /// <param name="sender">Instance that represents the click of button</param>
        /// <param name="e">Instance that represents the event</param>
        private void button2_Click(object sender, EventArgs e)
        {
            //checking for empty fields
            if (string.IsNullOrWhiteSpace(firstText.Text) ||
                    string.IsNullOrWhiteSpace(lastText.Text) ||
                    string.IsNullOrWhiteSpace(phoneText.Text) ||
                    string.IsNullOrWhiteSpace(emailText.Text) ||
                    string.IsNullOrWhiteSpace(addressText.Text) ||
                    string.IsNullOrWhiteSpace(zipText.Text) ||
                    string.IsNullOrWhiteSpace(userText.Text) ||
                    string.IsNullOrWhiteSpace(passText.Text))
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
                for(int i = 0; i < fixedPhone.Length; i++)
                {
                    if(fixedPhone[i] == '-' || fixedPhone[i] == '(' || fixedPhone[i] == ')' || fixedPhone[i] == ' ')
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
                bool end = false;
                StreamReader sr = new StreamReader(Application.UserAppDataPath + "/AccountInfo.txt");
                while (!end)
                {
                    string line = sr.ReadLine();
                    if (sr.EndOfStream)
                    {
                        end = true;
                    }
                    if (line == userText.Text)
                    {
                        errorLabel.Text = "Username taken";
                        errorLabel.Visible = true;
                        return;
                    }
                    while (line != " " && !sr.EndOfStream)
                    {
                        line = sr.ReadLine();
                    }
                }
                sr.Close();
            }
            catch (FileNotFoundException)
            {
                StreamWriter sw = new StreamWriter(Application.UserAppDataPath + "/AccountInfo.txt", true);
                sw.Close();
            }
            catch
            {
                fileError.Visible = true;
                return;
            }
            //creating new user and checking for other errors
            try
            {
                newUser = new User(firstText.Text, lastText.Text, Int64.Parse(fixedPhone), userText.Text, passText.Text, emailText.Text, addressText.Text, int.Parse(zipText.Text));
                newUser.loggedIn = true;
            }
            catch
            {
                errorLabel.Text = "A required field is invalid";
                errorLabel.Visible = true;
                return;
            }
            username = userText.Text;
            password = passText.Text;
            first = firstText.Text;
            last = lastText.Text;
            phone = fixedPhone;
            email = emailText.Text;
            address = addressText.Text;
            zip = zipText.Text;
            try
            {
                Console.WriteLine("Here");
                StreamWriter sw = new StreamWriter(Application.UserAppDataPath + "/AccountInfo.txt", true);
                sw.WriteLine(username);
                sw.WriteLine(password);
                sw.WriteLine(first);
                sw.WriteLine(last);
                sw.WriteLine(phone);
                sw.WriteLine(email);
                sw.WriteLine(address);
                sw.WriteLine(zip);
                sw.WriteLine(" ");
                sw.Close();
                Form1 f = new Form1(newUser);
                Hide();
                f.ShowDialog();
            }
            catch
            {
                fileError.Visible = true;
                return;
            }
        }

        /// <summary>
        /// This method sets the Form to the previous form.
        /// </summary>
        /// <param name="f">Form instance called f</param>
        public void SetPrevious(Form f)
        {
            previousForm = f;
        }
    }
}
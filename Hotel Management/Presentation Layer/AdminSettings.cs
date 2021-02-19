using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Hotel_Management.Presentation_Layer
{
    public partial class AdminSettings : Form
    {
        public AdminSettings()
        {
            InitializeComponent();
        }

        private void AdminSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            AdminHome adh = new AdminHome();
            adh.labelID.Text = labelID.Text;
            adh.Show();
            this.Hide();
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            Home h = new Home();
            h.Show();
            this.Hide();
        }

        public static bool IsValidEmail(string email)
        {
            const string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|" + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)" + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

            var regex = new Regex(pattern, RegexOptions.IgnoreCase);

            return regex.IsMatch(email);
        }

        private void buttonSPassword_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == null || textBox2.Text == null || textBox3.Text == null || textBoxEmail.Text == null || textBoxName1.Text == null || textBoxNewPassword.Text == null)
            {
                MessageBox.Show("Fill Every Field..!");
            }
            else
            {
                if (textBoxNewPassword.Text.Length < 4)
                {
                    MessageBox.Show("Password must be four letters or digits..!");
                }
                else
                {
                    if (IsValidEmail(textBoxEmail.Text))
                    {
                        MessageBox.Show("Updated..!");
                    }
                    else
                    {
                        MessageBox.Show("Invalid Email..!");
                    }
                }
            }
        }

        private void textBoxName1_KeyPress(object sender, KeyPressEventArgs e)
        {
            int number;
            bool success = Int32.TryParse(e.KeyChar.ToString(), out number);
            if (success)
            {
                MessageBox.Show("Invalid Input..!");
            }
            else
            {
                if (e.KeyChar == (char)Keys.Back)
                {
                    textBoxName1.Select(textBoxName1.Text.Length, 0);
                }
                else
                {
                    textBoxName1.Text = textBoxName1.Text;
                }
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            int number;
            bool success = Int32.TryParse(e.KeyChar.ToString(), out number);
            if (success)
            {
                MessageBox.Show("Invalid Input..!");
            }
            else
            {
                if (e.KeyChar == (char)Keys.Back)
                {
                    textBox3.Select(textBox3.Text.Length, 0);
                }
                else
                {
                    textBox3.Text = textBox3.Text;
                }
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            int number;
            bool success = Int32.TryParse(e.KeyChar.ToString(), out number);
            if (success)
            {
                textBox3.Text = textBox3.Text;
               
            }
            else
            {
                if (e.KeyChar == (char)Keys.Back)
                {
                    textBox3.Select(textBox3.Text.Length, 0);
                }
                else
                {
                    MessageBox.Show("Invalid Input..!");
                }
            }
        }
    }
}

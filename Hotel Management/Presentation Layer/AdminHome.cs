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
using Hotel_Management.Business_Logic_Layer;

namespace Hotel_Management.Presentation_Layer
{
    public partial class AdminHome : Form
    {
        Admin a = new Admin();
        TextBox t = new TextBox();
        Manager m = new Manager();
        public AdminHome()
        {
            InitializeComponent();
        }

        private void AdminHome_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            AdminSettings ads = new AdminSettings();
            ads.labelID.Text = labelID.Text;
            ads.Show();
            this.Hide();
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            Home h = new Home();
            h.Show();
            this.Hide();
        }

        private void buttonMonthlyRevenue_Click_1(object sender, EventArgs e)
        {
            MonthlyReport me = new MonthlyReport();
            me.labelID.Text = labelID.Text;
            me.Show();
            this.Hide();
        }

        private void buttonAnnualRevenue_Click_1(object sender, EventArgs e)
        {
            YearlyReport yr = new YearlyReport();
            yr.labelID.Text = this.labelID.Text;
            yr.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            LastTwelveMonthsReport ltm = new LastTwelveMonthsReport();
            ltm.labelID.Text = this.labelID.Text;
            ltm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Managers m = new Managers();
            m.labelID.Text = labelID.Text;
            m.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            t.Width = 153;
            t.Height = 20;
            t.Location = new Point(122, 138);
            this.groupBoxCreateManager.Controls.Add(t);
        }

        private void textBoxMName_KeyPress(object sender, KeyPressEventArgs e)
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
                    textBoxMName.Select(textBoxMName.Text.Length, 0);
                }
                else
                {
                    textBoxMName.Text = textBoxMName.Text;
                }
            }
        }

        public static bool IsValidEmail(string email)
        {
            const string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|" + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)" + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

            var regex = new Regex(pattern, RegexOptions.IgnoreCase);

            return regex.IsMatch(email);
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxMPassword.Text) || string.IsNullOrWhiteSpace(textBox3.Text) || string.IsNullOrWhiteSpace(textBoxMName.Text) || string.IsNullOrWhiteSpace(textBox1.Text)
                || string.IsNullOrWhiteSpace(textBoxMContact.Text) || string.IsNullOrWhiteSpace(textBox4.Text) || string.IsNullOrWhiteSpace(textBoxMEmail.Text))
            {
                MessageBox.Show("Fill Every Field..!");
            }
            else
            {
                if (textBoxMPassword.Text.Length < 4)
                {
                    MessageBox.Show("Password Must Have Four Latters or Digits..!");
                }
                else
                {
                    if (textBoxMPassword.Text == textBox4.Text)
                    {
                        if (IsValidEmail(textBoxMEmail.Text))
                        {
                            //return ad.AdminCreate(fname,lname,dob,contact1,contact2,gender,jDate,email,password,address,sal);
                            //public bool AdminCreate(string fname, string lname, string dob, int contact1, int contact2,string gender, string jDate, string email, string password,string address, int sal)
                            string gender;
                            if (radioButton1.Checked)
                            {
                                gender = "Female";
                            }
                            else
                            {
                                gender = "Male";
                            }
                            if (string.IsNullOrWhiteSpace(t.Text))
                            {
                                if (a.AdminCreate(textBoxMName.Text, textBox3.Text, dateTimePicker3.Value.ToString("dd-MM-yyyy"), int.Parse(textBoxMContact.Text.ToString()), gender, dateTimePicker4.Value.ToString("dd-MM-yyyy"), textBoxMEmail.Text, textBoxMPassword.Text, textBox2.Text, int.Parse(textBox1.Text.ToString())))
                                {
                                    MessageBox.Show("Created..!");
                                }
                                else
                                {
                                    MessageBox.Show("Not Created..!");
                                }
                            }
                            else
                            {
                                if (a.AdminCreate(textBoxMName.Text, textBox3.Text, dateTimePicker3.Value.ToString("dd-MM-yyyy"), int.Parse(textBoxMContact.Text.ToString()), int.Parse(t.Text.ToString()), gender, dateTimePicker4.Value.ToString("dd-MM-yyyy"), textBoxMEmail.Text, textBoxMPassword.Text, textBox2.Text, int.Parse(textBox1.Text.ToString())))
                                {
                                    MessageBox.Show("Created..!");
                                }
                                else
                                {
                                    MessageBox.Show("Not Created..!");
                                }
                            }

                        }
                        else
                        {
                            MessageBox.Show("Invalid Email..!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Password doesn't match..!");
                    }
                }
            }
        }

        private void textBoxMContact_KeyPress(object sender, KeyPressEventArgs e)
        {
            int number;
            bool success = Int32.TryParse(e.KeyChar.ToString(), out number);
            if (success)
            {
                textBoxMContact.Text = textBoxMContact.Text;
            }
            else
            {
                if (e.KeyChar == (char)Keys.Back)
                {
                    textBoxMContact.Select(textBoxMContact.Text.Length, 0);
                }
                else
                {
                    MessageBox.Show("Invalid Input..!");
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
                textBox1.Text = textBox1.Text;
            }
            else
            {
                if (e.KeyChar == (char)Keys.Back)
                {
                    textBox1.Select(textBox1.Text.Length, 0);
                }
                else
                {
                    MessageBox.Show("Invalid Input..!");
                }
            }
        }

        private void AdminHome_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxMPassword.Text) || string.IsNullOrWhiteSpace(textBox3.Text) || string.IsNullOrWhiteSpace(textBoxMName.Text) || string.IsNullOrWhiteSpace(textBox1.Text)
                || string.IsNullOrWhiteSpace(textBoxMContact.Text) || string.IsNullOrWhiteSpace(textBox4.Text) || string.IsNullOrWhiteSpace(textBoxMEmail.Text))
            {
                MessageBox.Show("Fill Every Field..!");
            }
            else
            {
                if (textBoxMPassword.Text.Length < 4)
                {
                    MessageBox.Show("Password Must Have Four Latters or Digits..!");
                }
                else
                {
                    if (textBoxMPassword.Text == textBox4.Text)
                    {
                        if (IsValidEmail(textBoxMEmail.Text))
                        {
                            //return ad.AdminCreate(fname,lname,dob,contact1,contact2,gender,jDate,email,password,address,sal);
                            //public bool AdminCreate(string fname, string lname, string dob, int contact1, int contact2,string gender, string jDate, string email, string password,string address, int sal)
                            string gender;
                            if (radioButton1.Checked)
                            {
                                gender = "Female";
                            }
                            else
                            {
                                gender = "Male";
                            }
                            if (string.IsNullOrWhiteSpace(t.Text))
                            {
                                if (m.ManagerCreate(textBoxMName.Text, textBox3.Text, dateTimePicker3.Value.ToString("dd-MM-yyyy"), int.Parse(textBoxMContact.Text.ToString()), gender, dateTimePicker4.Value.ToString("dd-MM-yyyy"), textBoxMEmail.Text, textBoxMPassword.Text, textBox2.Text, int.Parse(textBox1.Text.ToString())))
                                {
                                    MessageBox.Show("Created..!");
                                }
                                else
                                {
                                    MessageBox.Show("Not Created..!");
                                }
                            }
                            else
                            {
                                if (m.ManagerCreate(textBoxMName.Text, textBox3.Text, dateTimePicker3.Value.ToString("dd-MM-yyyy"), int.Parse(textBoxMContact.Text.ToString()), int.Parse(t.Text.ToString()), gender, dateTimePicker4.Value.ToString("dd-MM-yyyy"), textBoxMEmail.Text, textBoxMPassword.Text, textBox2.Text, int.Parse(textBox1.Text.ToString())))
                                {
                                    MessageBox.Show("Created..!");
                                }
                                else
                                {
                                    MessageBox.Show("Not Created..!");
                                }
                            }

                        }
                        else
                        {
                            MessageBox.Show("Invalid Email..!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Password doesn't match..!");
                    }
                }
            }
        }
    }
}

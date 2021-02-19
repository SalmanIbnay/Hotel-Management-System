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
    public partial class ManagerHome : Form
    {
        Receptionist r = new Receptionist();
        Employee emp = new Employee();
        public ManagerHome()
        {
            InitializeComponent();
        }

        private void ManagerHome_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            UpdateReport upr = new UpdateReport();
            upr.Show();
            this.Hide();
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            ManagerSettings ms = new ManagerSettings();
            ms.labelID.Text = this.labelID.Text;
            ms.Show(); this.Hide();
            this.Hide();
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            Home h = new Home();
            h.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            EmployeeSettings edp = new EmployeeSettings();
            edp.labelID.Text = this.labelID.Text;
            edp.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            EmployeeSettings edp = new EmployeeSettings();
            edp.labelID.Text = this.labelID.Text;
            edp.Show();
            this.Hide();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            int number;
            bool success = Int32.TryParse(e.KeyChar.ToString(), out number);

            if (success)
            {
                MessageBox.Show("Invalid!");
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

        private void textBoxMName_KeyPress(object sender, KeyPressEventArgs e)
        {
            int number;
            bool success = Int32.TryParse(e.KeyChar.ToString(), out number);

            if (success)
            {
                MessageBox.Show("Invalid!");
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

        private void textBoxMEmail_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            int number;
            bool success = Int32.TryParse(e.KeyChar.ToString(), out number);

            if (success)
            {
                textBox6.Text = textBox6.Text;
            }
            else
            {
                if (e.KeyChar == (char)Keys.Back)
                {
                    textBox6.Select(textBox6.Text.Length, 0);
                }
                else
                {
                    MessageBox.Show("Invalid!");
                }
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Task t = new Task();
            t.labelID.Text = this.labelID.Text;
            t.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            RoomDetails f = new RoomDetails();
            f.labelID.Text = this.labelID.Text;
            f.Show();
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            FoodDetails f = new FoodDetails();
            f.labelID.Text = this.labelID.Text;
            f.Show();
            this.Hide();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            ServiceUpdate s = new ServiceUpdate();
            s.labelID.Text = this.labelID.Text;
            s.Show();
            this.Hide();
        }

        private bool CheckInput()
        {
            if (textBox3.Text == null || textBox6.Text == null || textBoxMName.Text == null || textBoxMContact.Text == null || textBoxMEmail.Text == null || textBox8.Text == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsValidEmail(string email)
        {
            const string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|" + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)" + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

            var regex = new Regex(pattern, RegexOptions.IgnoreCase);

            return regex.IsMatch(email);
        }

        private void ManagerHome_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
        }

        private void buttonRCreate_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(textBoxMName.Text) || string.IsNullOrWhiteSpace(textBox3.Text) || string.IsNullOrWhiteSpace(textBox7.Text) || string.IsNullOrWhiteSpace(textBox6.Text)
            || string.IsNullOrWhiteSpace(textBoxMContact.Text) || string.IsNullOrWhiteSpace(textBox8.Text) || string.IsNullOrWhiteSpace(textBoxMEmail.Text) || string.IsNullOrWhiteSpace(textBox5.Text))
            {

                MessageBox.Show("Fill Every Field..!");
            }
            else
            {
                if (IsValidEmail(textBoxMEmail.Text))
                {
                    if (textBox8.Text.Length < 4)
                    {
                        MessageBox.Show("Password must be four letters or digits..!");
                    }



                    else
                    {
                        if (textBox8.Text == textBox5.Text)
                        {
                            if (IsValidEmail(textBoxMEmail.Text))
                            {
                                string gender;
                                if (radioButton1.Checked)
                                {
                                    gender = "Female";
                                }
                                else
                                {
                                    gender = "Male";
                                }
                                if (r.ReceiptionistCreate(textBoxMName.Text, textBox3.Text, dateTimePicker1.Value.ToString("dd-MM-yyyy"), int.Parse(textBoxMContact.Text.ToString()), gender, dateTimePicker2.Value.ToString("dd-MM-yyyy"), textBoxMEmail.Text, textBox8.Text, textBox7.Text, int.Parse(textBox6.Text.ToString())))
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

        private void buttonEcreate_Click(object sender, EventArgs e)
        {





            if (string.IsNullOrWhiteSpace(textBoxMName.Text) || string.IsNullOrWhiteSpace(textBox3.Text) || string.IsNullOrWhiteSpace(textBox7.Text) || string.IsNullOrWhiteSpace(textBox6.Text)
            || string.IsNullOrWhiteSpace(textBoxMContact.Text) || string.IsNullOrWhiteSpace(textBox8.Text) || string.IsNullOrWhiteSpace(textBoxMEmail.Text) || string.IsNullOrWhiteSpace(textBox5.Text))
            {

                MessageBox.Show("Fill Every Field..!");
            }
            else
            {
                if (IsValidEmail(textBoxMEmail.Text))
                {
                    if (textBox8.Text.Length < 4)
                    {
                        MessageBox.Show("Password must be four letters or digits..!");
                    }



                    else
                    {
                        if (textBox8.Text == textBox5.Text)
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
                                if (emp.EmployeeCreate(textBoxMName.Text, textBox3.Text, dateTimePicker1.Value.ToString("dd-MM-yyyy"), int.Parse(textBoxMContact.Text.ToString()), gender, dateTimePicker2.Value.ToString("dd-MM-yyyy"), textBoxMEmail.Text, textBox8.Text, textBox7.Text, int.Parse(textBox6.Text.ToString())))
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
}
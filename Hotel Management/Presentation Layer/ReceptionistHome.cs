using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hotel_Management.Business_Logic_Layer;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace Hotel_Management.Presentation_Layer
{
    public partial class ReceptionistHome : Form
    {
        
        Receptionist r = new Receptionist();
        public ReceptionistHome()
        {
            InitializeComponent();
        }

        private void ReceptionistHome_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            Home h = new Home();
            h.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CustomerInfo ece = new CustomerInfo(r.CustomerInfo(),r.ACRoomDetails(),r.NonACRoomDetails());
            ece.labelID.Text = this.labelID.Text;
            ece.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Services rd = new Services(r.ServiceDetails());
            rd.labelID.Text = labelID.Text;
            rd.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            TextBox t = new TextBox();
            t.Text = "";
            t.Location = new Point(104,113);
            t.Height = 20;
            t.Width = 156;
            this.groupBoxCuInfo.Controls.Add(t);
            t.KeyPress += new KeyPressEventHandler(t_keyPress);
            t.Show();
        }

        private void t_keyPress(object sender, KeyPressEventArgs e)
        {
            int number;
            bool success = Int32.TryParse(e.KeyChar.ToString(), out number);

            if (success)
            {
                textBoxCuContact.Text = textBoxCuContact.Text;
            }
            else
            {
                if (e.KeyChar == (char)Keys.Back)
                {
                    textBoxCuContact.Select(textBoxCuContact.Text.Length, 0);
                }
                else
                {
                    MessageBox.Show("Invalid!");
                }
            }
        }

        private void ReceptionistHome_Load(object sender, EventArgs e)
        {
            textBoxAdvancedPay.Text = "0";
            radioButtonFemale.Checked = true;
            dataGridView2.DataSource = r.ACRoomDetails();
            dataGridView3.DataSource = r.NonACRoomDetails();
        }

        private void button_Food_Click(object sender, EventArgs e)
        {
            FoodCorner f = new FoodCorner(r.FoodDetails());
            f.labelID.Text = this.labelID.Text;
            f.Show();
            this.Hide();
        }
        public static bool IsValidEmail(string email)
        {
            const string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|" + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)" + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

            var regex = new Regex(pattern, RegexOptions.IgnoreCase);

            return regex.IsMatch(email);
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxCuFName.Text) || string.IsNullOrWhiteSpace( textBoxCULName.Text)  ||string.IsNullOrWhiteSpace( textBoxCuContact.Text)  || string.IsNullOrWhiteSpace(textBoxAddress.Text)  )
            {
                MessageBox.Show("Fill Every Field..!");
            }
            else
            { 
                if(textBoxCuEmail.Text == null)
                {
                    string gender;
                    if (radioButtonFemale.Checked)
                    {
                        gender = "Female";
                    }
                    else
                    {
                        gender = "Male";
                    }
                    DataTable d = r.CustomerInfo(textBoxCuFName.Text, textBoxCULName.Text, int.Parse(textBoxCuContact.Text), gender, dateTimePicker4.Value.ToString(), textBoxCuEmail.Text, dateTimePicker1.Value.ToString(), dateTimePicker2.Value.ToString(), textBoxAddress.Text, int.Parse(textBoxAdvancedPay.Text));
                    textBox2.Text = d.Rows[0]["Id"].ToString();
                }
                else
                {
                    if (IsValidEmail(textBoxCuEmail.Text))
                    {
                        string gender;
                        if(radioButtonFemale.Checked)
                        {
                            gender = "Female";
                        }
                        else
                        {
                            gender = "Male";
                        }
                        DataTable d = new DataTable();
                        d = r.CustomerInfo(textBoxCuFName.Text, textBoxCULName.Text, int.Parse(textBoxCuContact.Text), gender, dateTimePicker4.Value.ToString(), textBoxCuEmail.Text, dateTimePicker1.Value.ToString(), dateTimePicker2.Value.ToString(), textBoxAddress.Text, int.Parse(textBoxAdvancedPay.Text));
                        MessageBox.Show("Inserted..!");
                        textBox2.Text = ((int)d.Rows[0]["Id"]).ToString();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Email..!");
                    }
                }
                
            }
            //dateTimePicker1.Value.Date
            //dateTimePicker1.Value
            /*try 
            { 
                SqlConnection con;
                con = new SqlConnection(@"Data Source=SHOAIB-PC\SQLEXPRESS;Initial Catalog=HotelManagement;Integrated Security=True");
                con.Open();
                string query = string.Format("insert into date(datetime,date2) values('"+dateTimePicker1.Text+"','"+dateTimePicker2.Text+"')");
                SqlCommand cmd = new SqlCommand(query,con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Date Saved");
                TimeSpan difference = (dateTimePicker2.Value.Date - dateTimePicker1.Value.Date);
                textBoxDateDiff.Text = difference.Days.ToString();

            }
            catch(Exception ex)
            {
                 MessageBox.Show(ex.ToString());
            }*/

        }

        private void textBoxCuFName_KeyPress(object sender, KeyPressEventArgs e)
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
                    textBoxCuFName.Select(textBoxCuFName.Text.Length, 0);
                }
                else
                {
                    textBoxCuFName.Text = textBoxCuFName.Text;
                }
            }
        }

        private void textBoxCULName_KeyPress(object sender, KeyPressEventArgs e)
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
                    textBoxCULName.Select(textBoxCULName.Text.Length, 0);
                }
                else
                {
                    textBoxCULName.Text = textBoxCULName.Text;
                }
            }
        }

        private void textBoxCuContact_KeyPress(object sender, KeyPressEventArgs e)
        {
            int number;
            bool success = Int32.TryParse(e.KeyChar.ToString(), out number);

            if (success)
            {
                textBoxCuContact.Text = textBoxCuContact.Text;
            }
            else
            {
                if (e.KeyChar == (char)Keys.Back)
                {
                    textBoxCuContact.Select(textBoxCuContact.Text.Length, 0);
                }
                else
                {
                    MessageBox.Show("Invalid!");
                }
            }
        }

        private void textBoxAdvancedPay_KeyPress(object sender, KeyPressEventArgs e)
        {
            int number;
            bool success = Int32.TryParse(e.KeyChar.ToString(), out number);
            if (success)
            {
                textBoxAdvancedPay.Text = textBoxAdvancedPay.Text;
            }
            else
            {
                if (e.KeyChar.ToString() == ".")
                {
                    textBoxAdvancedPay.Text = textBoxAdvancedPay.Text;
                }
                else if (e.KeyChar == (char)Keys.Back)
                {
                    textBoxAdvancedPay.Select(textBoxAdvancedPay.Text.Length, 0);
                }
                else
                {
                    MessageBox.Show("Invalid!");
                }
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            int number;
            bool success = Int32.TryParse(e.KeyChar.ToString(), out number);
            if (success)
            {
                textBox5.Text = textBox5.Text;
            }
            else
            {
                if (e.KeyChar == (char)Keys.Back)
                {
                    textBox5.Select(textBox5.Text.Length, 0);
                }
                else
                {
                    MessageBox.Show("Invalid!");
                }
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            int number;
            bool success = Int32.TryParse(e.KeyChar.ToString(), out number);
            if (success)
            {
                textBox7.Text = textBox7.Text;
            }
            else if (e.KeyChar == (char)Keys.Back)
            {
                
                    textBox7.Select(textBox7.Text.Length, 0);
            }
             else
            {
                    MessageBox.Show("Invalid!");
            }
            
        }

        private void buttonChangePassword_Click(object sender, EventArgs e)
        {
            ReceptionistPasswordChange o = new ReceptionistPasswordChange();
            o.labelID.Text = this.labelID.Text;
            o.Show();
            this.Hide();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxRoomNo.Text = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxRoomNo.Text = dataGridView3.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataTable da = new DataTable();
            if(string.IsNullOrWhiteSpace(textBox5.Text))
            {
                if(string.IsNullOrWhiteSpace(textBox7.Text))
                {
                    MessageBox.Show("Fill Field..!");
                }
                else
                {
                    if(r.UpdateBillFinalByContact(int.Parse(textBox7.Text)))
                    {
                        r.UpdateBillFinalByContact(int.Parse(textBox7.Text));
                        dt = r.GeneratedBillContact(int.Parse(textBox7.Text));
                        da = r.CustomerInfo3(int.Parse(textBox7.Text));
                    }
                    MessageBox.Show("Found..!");
                    label50.Text = dt.Rows[0]["Totalbill"].ToString();
                    label8.Text = da.Rows[0]["advancedpay"].ToString();
                }
            }
            else
            {
                if (r.UpdateBillFinalById(int.Parse(textBox5.Text)))
                {
                     r.UpdateBillFinalById (int.Parse(textBox5.Text));
                     dt = r.GeneratedBillId(int.Parse(textBox5.Text));
                     da = r.CustomerInfo2(int.Parse(textBox5.Text));
                }
                MessageBox.Show("Found..!");
                label50.Text = dt.Rows[0]["Totalbill"].ToString();
                label8.Text = da.Rows[0]["advancedpay"].ToString();
            }

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            DateTime febDate = dateTimePicker2.Value;
            DateTime pickerDate = dateTimePicker1.Value;

            TimeSpan tspan = febDate - pickerDate;

            int differenceInDays = tspan.Days;
            if (r.AssignRoom(dateTimePicker2.Value.ToString("dd-MM-yy"), int.Parse(textBox2.Text),differenceInDays, int.Parse(textBoxRoomNo.Text),int.Parse(textBoxCuContact.Text)))
            {
                MessageBox.Show("Assigned..!");
                r.InsertBill(int.Parse(textBox2.Text), int.Parse(textBoxCuContact.Text));
                r.UpdateBillFinalById(int.Parse(textBox2.Text));
            }
            else
            {
                MessageBox.Show("Not Assigned..!");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            double temp = double.Parse(label50.Text);
            if (comboBox2.Text == "10%")
            {
                double dis = (temp * 0.1);
                temp -= dis;
            }
            if (comboBox2.Text == "15%")
            {
                double dis = (temp * 0.15);
                temp -= dis;
            }
            if (comboBox2.Text == "20%")
            {
                double dis = (temp * 0.2);
                temp -= dis;
            }
            if (comboBox2.Text == "30%")
            {
                double dis = (temp * 0.3);
                temp -= dis;
            }
            if (comboBox2.Text == "40%")
            {
                double dis = (temp * 0.4);
                temp -= dis;
            }
            if (comboBox2.Text == "50%")
            {
                double dis = (temp * 0.5);
                temp -= dis;
            }
            temp -= double.Parse(label8.Text);
            label27.Text = temp.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (r.UpdateRevenue(int.Parse(label27.Text), dateTimePicker3.Value.ToString("dd-MM-yyyy")))
            {
                MessageBox.Show("Cleared..!");
            }
            else
            {
                MessageBox.Show("Not Found..!");
            }
            
        }
    }
}

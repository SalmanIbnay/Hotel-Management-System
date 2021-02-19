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

namespace Hotel_Management.Presentation_Layer
{
    public partial class RoomDetails : Form
    {
        Receptionist r = new Receptionist();
        Manager m = new Manager();
        public RoomDetails()
        {
            InitializeComponent();
        }

        private void RoomDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void buttonChangePassword_Click(object sender, EventArgs e)
        {
            ManagerHome rh = new ManagerHome();
            rh.labelID.Text = labelID.Text;
            rh.Show();
            this.Hide();
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            Home h = new Home();
            h.Show();
            this.Hide();
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
                    Home h = new Home();
                    h.Show();
                    this.Hide();
                }
            }
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
                    Home h = new Home();
                    h.Show();
                    this.Hide();
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
                    MessageBox.Show("Invalid!");
                    Home h = new Home();
                    h.Show();
                    this.Hide();
                }
            }
        }

        private void textBoxMEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            int number;
            bool success = Int32.TryParse(e.KeyChar.ToString(), out number);

            if (success)
            {
                textBoxMEmail.Text = textBoxMEmail.Text;
            }
            else
            {
                if (e.KeyChar == (char)Keys.Back)
                {
                    textBoxMEmail.Select(textBoxMEmail.Text.Length, 0);
                }
                else
                {
                    MessageBox.Show("Invalid!");
                    Home h = new Home();
                    h.Show();
                    this.Hide();
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == null || textBox5.Text == null || textBox6.Text == null)
            {
                MessageBox.Show("Fill Every Field..!");
            }
            else
            {
                if(m.Insertroom(int.Parse(textBox4.Text),int.Parse(textBox5.Text),int.Parse(textBox6.Text)))
                {
                     MessageBox.Show("Inserted.!");
                     GridUpdateAC();
                     GridUpdateNonAC();
                }
                else
                {
                    MessageBox.Show("Not Inserted..!");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == null)
            {
                MessageBox.Show("Fill Filed..!");
            }
            else
            {
                MessageBox.Show("Found..!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == null || textBoxMContact.Text == null || textBoxMEmail.Text == null)
            {
                MessageBox.Show("Fill Every Field..!");
            }
            else
            {
                MessageBox.Show("Updated..!");
                GridUpdateNonAC();
                GridUpdateAC();
            }
        }
        DataTable dt = new DataTable();
        private void GridUpdateAC()
        {
            dt = r.ACRoomDetails();
            dataGridView2.DataSource = dt;
        }

        private void GridUpdateNonAC()
        {
            dt = r.NonACRoomDetails();
            dataGridView1.DataSource = dt;
        }
        

        private void RoomDetails_Load(object sender, EventArgs e)
        {
            dataGridView2.DataSource = r.ACRoomDetails();
            dataGridView1.DataSource = r.NonACRoomDetails();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_Management.Presentation_Layer
{
    public partial class FoodDetails : Form
    {
        public FoodDetails()
        {
            InitializeComponent();
        }

        private void FoodDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
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

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            int number;
            bool success = Int32.TryParse(e.KeyChar.ToString(), out number);

            if (success)
            {
                textBox2.Text = textBox2.Text;
            }
            else
            {
                if (e.KeyChar == (char)Keys.Back)
                {
                    textBox2.Select(textBox2.Text.Length, 0);
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

        private void buttonChangePassword_Click(object sender, EventArgs e)
        {
            ManagerHome m = new ManagerHome();
            m.labelID.Text = this.labelID.Text;
            m.Show();
            this.Hide();
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            Home h = new Home();
            h.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == null || textBox6.Text == null)
            {
                MessageBox.Show("Fill Every Field..!");
            }
            else
            {
                MessageBox.Show("Inserted..!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == null || textBox5.Text == null)
            {
                MessageBox.Show("Fill Every Field..!");
            }
            else
            {
                MessageBox.Show("Updated..!");
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
    }
}

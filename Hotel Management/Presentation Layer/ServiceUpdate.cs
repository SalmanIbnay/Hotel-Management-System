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
    public partial class ServiceUpdate : Form
    {
        public ServiceUpdate()
        {
            InitializeComponent();
        }

        private void ServiceUpdate_FormClosing(object sender, FormClosingEventArgs e)
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
                }
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
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

        private void buttonChangePassword_Click(object sender, EventArgs e)
        {
            ManagerHome m = new ManagerHome();
            m.labelID.Text = this.labelID.Text;
            m.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == null || textBox6.Text == null)
            {
                MessageBox.Show("Fill Every Field");
            }
            else
            {
                MessageBox.Show("Inserted");
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
                MessageBox.Show("Found");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == null || textBox5.Text == null)
            {
                MessageBox.Show("Fill Every Field");
            }
            else
            {
                MessageBox.Show("Inserted");
            }
        }
    }
}

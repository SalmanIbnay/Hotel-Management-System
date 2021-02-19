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
    public partial class CustomerInfo : Form
    {
        DataTable dt = new DataTable();
        DataTable a = new DataTable();
        DataTable b = new DataTable();
        public CustomerInfo()
        {
            InitializeComponent();
        }
        public CustomerInfo(DataTable cusInfo,DataTable ac,DataTable nonac)
        {
            InitializeComponent();
            this.dt = cusInfo;
            this.a = ac;
            this.b = nonac;
        }
        private void EditCustomerProfile_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void buttonChangePassword_Click(object sender, EventArgs e)
        {
            ReceptionistHome rh = new ReceptionistHome();
            rh.labelID.Text = this.labelID.Text;
            rh.Show();
            this.Hide();
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            Home h = new Home();
            h.Show();
            this.Hide();
        }

        private void CustomerInfo_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dt;
            dataGridView2.DataSource = a;
            dataGridView3.DataSource = b;
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
                }
            }
        }

        private void textBoxCuName_KeyPress(object sender, KeyPressEventArgs e)
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
                    textBoxCuName.Select(textBoxCuName.Text.Length, 0);
                }
                else
                {
                    textBoxCuName.Text = textBoxCuName.Text;
                }
            }
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

        private void textBoxAddress_KeyPress(object sender, KeyPressEventArgs e)
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
                    textBoxAddress.Select(textBoxAddress.Text.Length, 0);
                }
                else
                {
                    textBoxAddress.Text = textBoxAddress.Text;
                }
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxRoomNo.Text = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxRoomNo.Text = dataGridView3.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxCuName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBoxCuContact.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBoxCuEmail.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            textBoxAddress.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == null)
            {
                if (textBox2.Text == null)
                {
                    MessageBox.Show("Fill Field..!");
                }
                else
                {
                    MessageBox.Show("Found..!");
                }
            }
            else
            {
                MessageBox.Show("Found..!");
            }
        }
    }
}

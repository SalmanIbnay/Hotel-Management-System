using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;
using System.Windows;
using Hotel_Management.Business_Logic_Layer;

namespace Hotel_Management.Presentation_Layer
{
    public partial class FoodCorner : Form
    {
        Receptionist r = new Receptionist();
        int ammount = 0;
        DataTable fd;
        public FoodCorner()
        {
            InitializeComponent();
        }
        public FoodCorner(DataTable dt)
        {
            InitializeComponent();
            fd = dt;
        }

        private void FoodCorner_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void FoodCorner_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = fd;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            
            int count = dataGridView1.RowCount;
            try 
            {
                for (int i = 0; i < count; i++)
                {
                    if (dataGridView1.Rows[i].Cells[0].Value.ToString() != null)
                    {
                        dataGridView1.Rows[i].Cells[1].Value = (int.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString()) * int.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString())).ToString();
                        ammount += int.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString());
                    }
                    else
                    {
                        MessageBox.Show("No Input..!");
                    }
                }
             }
            catch(NullReferenceException)
            {
                MessageBox.Show("Calculated..!");
            }
            labelAmmount.Text = ammount.ToString();
        }

        private void textBoxCuID_KeyPress(object sender, KeyPressEventArgs e)
        {
            int number;
            bool success = Int32.TryParse(e.KeyChar.ToString(), out number);

            if (success)
            {
                textBoxCuID.Text = textBoxCuID.Text;
            }
            else
            {
                if (e.KeyChar == (char)Keys.Back)
                {
                    textBoxCuID.Select(textBoxCuID.Text.Length, 0);
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

        private void textBoxContact_KeyPress(object sender, KeyPressEventArgs e)
        {
            int number;
            bool success = Int32.TryParse(e.KeyChar.ToString(), out number);

            if (success)
            {
                textBoxContact.Text = textBoxContact.Text;
            }
            else
            {
                if (e.KeyChar == (char)Keys.Back)
                {
                    textBoxContact.Select(textBoxContact.Text.Length, 0);
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

        private void button2_Click(object sender, EventArgs e)
        {
            ReceptionistHome o = new ReceptionistHome();
            o.labelID.Text = this.labelID.Text;
            o.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if ( textBoxCuID.Text == null)
            {
                if (textBoxContact.Text == null)
                {
                    MessageBox.Show("Fill Field..!");
                }
                else
                {
                    r.UpdateBillId(int.Parse(labelAmmount.Text),int.Parse(textBoxContact.Text));
                    MessageBox.Show("Placed..!");
                }
            }
            else
            {
                r.UpdateBillContact(int.Parse(labelAmmount.Text), int.Parse(textBoxCuID.Text));
                MessageBox.Show("Placed..!");
            }
        }
    }
}

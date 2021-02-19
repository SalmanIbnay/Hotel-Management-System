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
    public partial class Services : Form
    {
        Receptionist r = new Receptionist();
        DataTable dt = new DataTable();
        int ammount = 0;
        public Services()
        {
            InitializeComponent();
        }
        public Services(DataTable da)
        {
            InitializeComponent();
            this.dt = da;
        }

        private void Services_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
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
            if (textBoxCuID.Text == null)
            {
                if (textBoxContact.Text == null)
                {
                    MessageBox.Show("Fill Field..!");
                }
                else
                {
                    r.UpdateBillId(int.Parse(labelAmmount.Text), int.Parse(textBoxContact.Text));
                    MessageBox.Show("Placed..!");
                }
            }
            else
            {
                r.UpdateBillContact(int.Parse(labelAmmount.Text), int.Parse(textBoxCuID.Text));
                MessageBox.Show("Placed..!");
            }
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
            catch (NullReferenceException)
            {
                MessageBox.Show("Calculated..!");
            }
            labelAmmount.Text = ammount.ToString();
        }

        private void Services_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dt;
        }
    }
}

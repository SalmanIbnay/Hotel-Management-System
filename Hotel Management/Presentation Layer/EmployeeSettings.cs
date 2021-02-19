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
    public partial class EmployeeSettings : Form
    {
        Employee e = new Employee();
        public EmployeeSettings()
        {
            InitializeComponent();
        }

        private void EmployeeSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            ManagerHome mh = new ManagerHome();
            mh.labelID.Text = this.labelID.Text;
            mh.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(textBox2.Text == null)
            {
                MessageBox.Show("Fill Field..!");
            }
            else
            {
                MessageBox.Show("Found..!");
            }
        }

        private void EmployeeSettings_Load(object sender, EventArgs e)
        {
            
        }
    }
}

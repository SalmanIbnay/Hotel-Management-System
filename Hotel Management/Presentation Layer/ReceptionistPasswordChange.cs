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
    public partial class ReceptionistPasswordChange : Form
    {
        public ReceptionistPasswordChange()
        {
            InitializeComponent();
        }

        private void ReceptionistPasswordChange_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            Home h = new Home();
            h.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.Parse(labelID.Text) < 20000)
            {
                ReceptionistHome h = new ReceptionistHome();
                h.labelID.Text = this.labelID.Text;
                h.Show();
                this.Hide();
            }
            else
            {
                EmployeeHome eh = new EmployeeHome();
                eh.labelID.Text = this.labelID.Text;
                eh.Show();
                this.Hide();
            }
        }
    }
}

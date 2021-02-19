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
    public partial class LastTwelveMonthsReport : Form
    {
        public LastTwelveMonthsReport()
        {
            InitializeComponent();
        }

        private void LastTwelveMonthsReport_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminHome adh = new AdminHome();
            adh.labelID.Text = this.labelID.Text;
            adh.Show();
            this.Hide();
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            Home h = new Home();
            h.Show();
            this.Hide();
        }

        private void LastTwelveMonthsReport_Load(object sender, EventArgs e)
        {

        }
    }
}

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
    public partial class UpdateReport : Form
    {
        public UpdateReport()
        {
            InitializeComponent();
        }

        private void UpdateReport_FormClosing(object sender, FormClosingEventArgs e)
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

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            Home h = new Home();
            h.Show();
            this.Hide();
        }
    }
}

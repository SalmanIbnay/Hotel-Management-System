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
    public partial class Task : Form
    {
        public Task()
        {
            InitializeComponent();
        }

        private void Task_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Task_Load(object sender, EventArgs e)
        {

        }

        private void buttonChangePassword_Click(object sender, EventArgs e)
        {
            ManagerHome m = new ManagerHome();
            m.labelID.Text = this.labelID.Text;
            m.Show();
            this.Hide();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Hotel_Management.Business_Logic_Layer;

namespace Hotel_Management.Presentation_Layer
{
    public partial class Managers : Form
    {
        Manager m = new Manager();
        public Managers()
        {
            InitializeComponent();
        }

        private void Managers_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            AdminHome ah = new AdminHome();
            ah.labelID.Text = labelID.Text;
            ah.Show();
            this.Hide();
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            Home h = new Home();
            h.Show();
            this.Hide();
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            int number;
            bool success = Int32.TryParse(e.KeyChar.ToString(), out number);
            if (success)
            {
                MessageBox.Show("Invalid Input..!");
            }
            else
            {
                if (e.KeyChar == (char)Keys.Back)
                {
                    textBox6.Select(textBox6.Text.Length, 0);
                }
                else
                {
                    textBox6.Text = textBox6.Text;
                }
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            int number;
            bool success = Int32.TryParse(e.KeyChar.ToString(), out number);
            if (success)
            {
                MessageBox.Show("Invalid Input..!");
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
                    MessageBox.Show("Invalid Input..!");
                }
            }
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
                    MessageBox.Show("Invalid Input..!");
                }
            }
        }

        public static bool IsValidEmail(string email)
        {
            const string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|" + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)" + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

            var regex = new Regex(pattern, RegexOptions.IgnoreCase);

            return regex.IsMatch(email);
        }

        private void GridUpdate()
        {
            dataGridView1.DataSource = m.GetAllManagers();
        }

        private void buttonSPassword_Click(object sender, EventArgs e)
        {
            m.ManagerUpdate(int.Parse(textBox7.Text), textBox6.Text, textBox3.Text, int.Parse(textBox2.Text), textBox8.Text, textBox4.Text, textBox5.Text, int.Parse(textBox1.Text));
            MessageBox.Show("Updated..!");
            GridUpdate();
        }

        private void Managers_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = m.GetAllManagers();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
            textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox8.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult res=MessageBox.Show("Are You Sure?","Confirmation",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            if (res.Equals(DialogResult.Yes))
            {
                if (m.Delete(int.Parse(textBox7.Text)))
                {
                    MessageBox.Show("Deleted..!");
                    GridUpdate();
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox7.Text = "";
                    textBox8.Text = "";
                }
            }
            else
            {
                GridUpdate();
            }

        }
    }
}

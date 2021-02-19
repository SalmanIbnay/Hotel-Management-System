using System;
using System.Windows.Forms;
using Hotel_Management.Business_Logic_Layer;

namespace Hotel_Management.Presentation_Layer
{
    public partial class Home : Form
    {
        Admin a = new Admin();
        Manager m = new Manager();
        Receptionist r = new Receptionist();
        Employee emp = new Employee();
        public Home()
        {
            InitializeComponent();
        }

        private void Home_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if(textBoxID.Text == "" || textBoxPassword.Text == "")
            {
                MessageBox.Show("Invalid Login please check id and password ");
            }
            else
            {
                if (int.Parse(textBoxID.Text) <= 100)
                {
                    MessageBox.Show("Invalid ID");
                }
                else if (int.Parse(textBoxID.Text) > 100 && int.Parse(textBoxID.Text) < 1000)
                {
                    if (a.AdminLogin(int.Parse(textBoxID.Text), textBoxPassword.Text))
                    {
                        AdminHome ah = new AdminHome();
                        ah.labelID.Text = textBoxID.Text;
                        ah.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Login please check id and password");
                    }
                }
                else if (int.Parse(textBoxID.Text) >= 1000 && int.Parse(textBoxID.Text) < 100000)
                {
                    if (m.ManagerLogin(int.Parse(textBoxID.Text), textBoxPassword.Text))
                    {
                        ManagerHome mh = new ManagerHome();
                        mh.labelID.Text = textBoxID.Text;
                        mh.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Login please check id and password");
                    }
                }
                else if (int.Parse(textBoxID.Text) >= 100000 && int.Parse(textBoxID.Text) < 200000)
                {
                    if (r.ReceptionistLogin(int.Parse(textBoxID.Text), textBoxPassword.Text))
                    {
                        ReceptionistHome rh = new ReceptionistHome();
                        rh.labelID.Text = textBoxID.Text;
                        rh.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Login please check id and password");
                    }
                }
                else if (int.Parse(textBoxID.Text) >= 200000)
                {
                    if (emp.EmployeeLogin(int.Parse(textBoxID.Text), textBoxPassword.Text))
                    {
                        EmployeeHome eh = new EmployeeHome();
                        eh.labelID.Text = textBoxID.Text;
                        eh.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Login please check id and password");
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBoxID.Text = textBoxPassword.Text = "";
        }

        private void textBoxID_KeyPress(object sender, KeyPressEventArgs e)
        {
            int number;
            bool success = Int32.TryParse(e.KeyChar.ToString(),out number);

            if (success)
            {
                textBoxID.Text = textBoxID.Text;
            }
            else
            {
                if(e.KeyChar == (char)Keys.Back)
                {
                    textBoxID.Select(textBoxID.Text.Length, 0);
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
     }
}
/*public static bool IsValidEmail(string email)
        {
            const string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|" + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)" + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

            var regex = new Regex(pattern, RegexOptions.IgnoreCase);

            return regex.IsMatch(email);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (IsValidEmail(textBox1.Text))
            {
                MessageBox.Show("valid");
            }
            else
            {
                MessageBox.Show("Invalid");
            }
        }*/
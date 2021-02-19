using System;
using System.Data.SqlClient;
using System.Data;

namespace Hotel_Management.Data_Access_Layer
{
    class AdminData
    {
        SqlConnection con;
        public AdminData()
        {
            try
            {
                con = new SqlConnection(@"Data Source=SHOAIB-PC\SQLEXPRESS;Initial Catalog=HotelManagement;Integrated Security=True");
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
            }
            catch(Exception ex)
            {
                con.Close();
            }
        }
        public bool AdminLogin(int id,string password)
        {
            try
            {
                string query = string.Format("Select * from admins where id={0} and password='{1}' ", id, password);
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    return true;
                }
                return false;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        public bool AdminCreate(string fname, string lname, string dob, int contact1,int contact2,string gender, string jDate, string email, string password, string address, int sal)
        {
            try
            {
                string query = string.Format("Insert Into admins (First_name,last_name,dob,contact1,contact2,gender,joining_date,address,email,password,salary) values('" + fname + "','" + lname + "','" + dob + "','" + contact1 + "','"+contact2+"','" + gender + "','" + jDate + "','" + address + "','" + email + "','" + password + "','" + sal + "')");
                SqlCommand cmd = new SqlCommand(query, con);
                int rows = -1;
                rows = cmd.ExecuteNonQuery();
                if (rows >= 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public bool AdminCreate(string fname, string lname, string dob, int contact1,string gender, string jDate, string email, string password,string address, int sal)
        {
            try
            {
                string query = string.Format("Insert Into admins (First_name,last_name,dob,contact1,gender,joining_date,address,email,password,salary) values('" + fname + "','" + lname + "','" + dob + "','" + contact1 + "','" + gender + "','" + jDate + "','" + address + "','" + email + "','" + password + "','" + sal + "')");
                SqlCommand cmd = new SqlCommand(query, con);
                int rows = -1;
                rows = cmd.ExecuteNonQuery();
                if (rows >= 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
            
        }
    }
}

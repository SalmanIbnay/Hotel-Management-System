using System;
using System.Data;
using System.Data.SqlClient;

namespace Hotel_Management.Data_Access_Layer
{
    class ManagerData
    {
        SqlConnection con;
        public ManagerData()
        {
            con = new SqlConnection(@"Data Source=SHOAIB-PC\SQLEXPRESS;Initial Catalog=HotelManagement;Integrated Security=True");
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }

        public DataTable GetAllManagers()
        {
            string query = string.Format("SELECT * FROM managers");
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public bool ManagerUpdate(int id, string fname, string lname, int contact, string address, string email, string password, int sal)
        {
            con.Open();
            string query = string.Format("UPDATE managers SET first_name='{0}',last_name='{1}',contact1 ={2},address='{3}',email='{4}',password='{5}',salary={6} WHERE id={7} ", fname, lname,contact,address,email,password,sal,id);
            SqlCommand cmd = new SqlCommand(query, con);
            int rows = -1;
            rows = cmd.ExecuteNonQuery();
            if (rows >= 0)
            {
                return true;
            }
            return false;
        }

        public bool ManagerLogin(int id,string password)
        {
            string query = string.Format("Select * from managers where id={0} and password='{1}' ", id,password);
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
        public bool ManagerCreate(string fname, string lname, string dob, int contact1, int contact2, string gender, string jDate, string email, string password, string address, int sal)
        {
            try
            {
                string query = string.Format("Insert Into managers (First_name,last_name,dob,contact1,contact2,gender,joining_date,address,email,password,salary) values('" + fname + "','" + lname + "','" + dob + "','" + contact1 + "','" + contact2 + "','" + gender + "','" + jDate + "','" + address + "','" + email + "','" + password + "','" + sal + "')");
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

        public bool ManagerCreate(string fname, string lname, string dob, int contact1, string gender, string jDate, string email, string password, string address, int sal)
        {
            try
            {
                string query = string.Format("Insert Into managers (First_name,last_name,dob,contact1,gender,joining_date,address,email,password,salary) values('" + fname + "','" + lname + "','" + dob + "','" + contact1 + "','" + gender + "','" + jDate + "','" + address + "','" + email + "','" + password + "','" + sal + "')");
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
        public bool Delete(int id)
        {
            con.Open();
            string query = string.Format("DELETE FROM managers WHERE id={0}", id);
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            return true;
        }
    }
}

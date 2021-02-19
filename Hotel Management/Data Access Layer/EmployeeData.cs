using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Hotel_Management.Data_Access_Layer
{
    class EmployeeData
    {
        SqlConnection con;
        public EmployeeData()
        {
            try
            {
                con = new SqlConnection(@"Data Source=SHOAIB-PC\SQLEXPRESS;Initial Catalog=HotelManagement;Integrated Security=True");
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
            }
            catch (Exception ex)
            {
                con.Close();
            }
        }
        public bool EmployeeLogin(int id,string password)
        {
            try
            {
                string query = string.Format("Select * from employees where id={0} and password='{1}' ", id, password);
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
        public bool EmployeeCreate(string fname, string lname, string dob, int contact1, string gender, string jDate, string email, string password, string address, int sal)
        {
            try
            {
                string query = string.Format("Insert Into Employees (First_name,last_name,dob,contact1,gender,joining_date,address,email,password,salary) values('" + fname + "','" + lname + "','" + dob + "','" + contact1 + "','" + gender + "','" + jDate + "','" + address + "','" + email + "','" + password + "','" + sal + "')");
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
        public DataTable GetEmployee()
        {
            try
            {
                string query = string.Format("Select * from employees");
                SqlCommand cmd = new SqlCommand(query,con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;

            
            }
            catch(Exception e)
            { 
                return null;
            }
        }
    }
}
    

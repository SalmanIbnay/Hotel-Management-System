using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Hotel_Management.Data_Access_Layer
{
    class CustomerData
    {
        SqlConnection con;
        public CustomerData()
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
        public DataTable CustomerInfo(string fname, string lname, int contact1, string gender, string bDate, string email, string cIn,string cOut, string address,int adv)
        {
            try
            {
                string query = string.Format("Insert Into Customers (First_name,last_name,contact,gender,bookingdate,checkin,checkout,address,email,advancedpay) values('" + fname + "','" + lname + "','" + contact1 + "','" + gender + "','" + bDate + "','" + cIn + "','" + cOut + "','" + address + "','" + email + "','"+adv+"')");
                SqlCommand cmd = new SqlCommand(query, con);
                //SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                string query1 = string.Format("Select * from customers where id = (select max(id) from customers)");
                SqlCommand cmd1 = new SqlCommand(query1, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd1);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception e)
            {
                return null;
            }

        }
    }
}

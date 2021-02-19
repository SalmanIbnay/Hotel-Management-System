using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Hotel_Management.Data_Access_Layer
{
    class FoodData
    {
        SqlConnection con;
        public FoodData()
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
        public DataTable FoodDetails()
        {
            try
            {
                string query = string.Format("Select name,price from foods order by name asc");
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch(Exception ex)
            {
                return null;
            }
            
        }
    }
}

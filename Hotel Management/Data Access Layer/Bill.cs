using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Hotel_Management.Data_Access_Layer
{
    class Bill
    {
        SqlConnection con = new SqlConnection();
        public Bill()
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
        public bool InsertBill(int cid,int contact)
        {
            string query = string.Format("insert into bills(paid_unpaid,customerid,contact,totalbill) values('{0}',{1},{2},{3})","Unpaid", cid, contact,0);
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            return true;
        }
        public bool UpdateBillById(int ammount,int id)
        {
            string query = string.Format("UPDATE bills SET totalbill=(totalbill+{0}) WHERE customerid={1} ", ammount,id);
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            return true;
        }
        public bool UpdateBillByContact(int ammount, int contact)
        {
            string query = string.Format("UPDATE bills SET totalbill=(totalbill+{0}) WHERE contact={1} ", ammount, contact);
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            return true;
        }
        public bool UpdateBillFinalById(int id)
        {
            
            string query2 = string.Format("Select  * from bills where customerid={0}",id);
            SqlCommand cmd1 = new SqlCommand(query2, con);
            cmd1.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd1);
            DataTable dt = new DataTable();

            da.Fill(dt);
            int rentBill = (int)dt.Rows[0][1];

            string query = string.Format("UPDATE bills SET totalbill=(totalbill+{0}) WHERE customerid={1}",rentBill, id);
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            return true;
        }
        public bool UpdateBillFinalByContact(int contact)
        {
            string query2 = string.Format("Select  * from bills where Contact={0}", contact);
            SqlCommand cmd1 = new SqlCommand(query2, con);
            cmd1.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd1);
            DataTable dt = new DataTable();

            da.Fill(dt);
            int rentBill = (int)dt.Rows[0][1];

            string query = string.Format("UPDATE bills SET totalbill=(totalbill+{0}) WHERE customerid={1} or contact={2}", rentBill,contact);
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            return true;
        }
        public DataTable GeneratedBillContact(int contact)
        {
            string query2 = string.Format("Select * from bills where  customer_contact={0}", contact);
            SqlCommand cmd1 = new SqlCommand(query2, con);
            cmd1.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd1);
            DataTable dt = new DataTable();

            da.Fill(dt);
            return dt;
        }

        public DataTable GeneratedBillId(int id)
        {
            string query2 = string.Format("Select * from bills where  customerid={0}", id);
            SqlCommand cmd1 = new SqlCommand(query2, con);
            cmd1.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd1);
            DataTable dt = new DataTable();

            da.Fill(dt);
            return dt;
        }
        public bool UpdateRevenue(int ammount,string date)
        {
            con.Open();
            try
            {
                string query = string.Format("INSERT INTO revenues(paymentdate,revenue) VALUES('{0}',{1})", date, ammount);
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            
        }
    }
}

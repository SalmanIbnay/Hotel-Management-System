using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Hotel_Management.Data_Access_Layer
{
    public class RoomData
    {
        SqlConnection con;
        public RoomData()
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
        public bool InsertRoom(int roomno, int rent, int contact)
        {
            
            try
            {
                string query = string.Format("Insert into rooms(room_no,type,rent,contact,ac_nonac) values('{0}','{1}',{2},{3},'{4}')",roomno,"single",rent,contact,"AC");
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /*private void GridUpdate()
        {
            try
            {
                string query = string.Format("Select room_no,type,rent,[booked/vacant],vacant_date,reserved_from,reserved_till,contact,customer_id from rooms where [AC/NonAC]='AC'");
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }*/
        public bool AssignRoom(string vdate,int cid,int day,int roomno,int contact)
        {
            try
            {
                string query = string.Format("UPDATE rooms SET booked_vacant='{0}', vacant_date='{1}',customer_id={2},day={3},customer_contact={4} WHERE room_no={5}","Booked",vdate, cid,day,contact , roomno);
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                return true;
              
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public DataTable ACRoomDetails()
        {
            try
            {
                string query = string.Format("Select * from rooms where ac_nonac='AC'");
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataTable NonACRoomDetails()
        {
            try
            {
                string query = string.Format("Select * from rooms where ac_nonac='NonAC'");
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

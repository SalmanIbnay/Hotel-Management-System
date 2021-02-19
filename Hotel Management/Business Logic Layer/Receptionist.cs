using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel_Management.Data_Access_Layer;
using System.Data;


namespace Hotel_Management.Business_Logic_Layer
{  
    class Receptionist
    {
        Customer c = new Customer();
        CustomerData cd = new CustomerData();
        Service sd = new Service();
        FoodData fd = new FoodData();
        RoomData rmd = new RoomData();
        ReceptionistData rd = new ReceptionistData();
        Customer cus = new Customer();
        Bill b = new Bill();
        public bool ReceptionistLogin(int id, string password)
        {
            return rd.ReceptionistLogin(id, password);
        }
        public DataTable ACRoomDetails()
        {
            return rmd.ACRoomDetails();
        }
        public DataTable NonACRoomDetails()
        {
            return rmd.NonACRoomDetails();
        }
        public DataTable FoodDetails()
        {
            return fd.FoodDetails();
        }
        public DataTable ServiceDetails()
        {
            return sd.ServiceDetails();
        }
        public DataTable CustomerInfo()
        {
            return cus.CustomerDetails();
        }
        public bool ReceiptionistCreate(string fname, string lname, string dob, int contact1, string gender, string jDate, string email, string password, string address, int sal)
        {
            return rd.ReceiptionistCreate(fname, lname, dob, contact1, gender, jDate, email, password, address, sal);
        }
        public DataTable CustomerInfo(string fname, string lname, int contact1, string gender, string bDate, string email, string cIn,string cOut, string address,int adv)
        {
            return cd.CustomerInfo(fname,lname, contact1, gender,bDate, email,  cIn, cOut,address,adv);
        }
        public DataTable CustomerInfo2(int id)
        {
            return c.CustomerDetails2(id);
        }
        public DataTable CustomerInfo3(int contact)
        {
            return c.CustomerDetails3(contact);
        }
        public bool AssignRoom(string vdate,int cid,int day,int roomno,int contact)
        {
            return rmd.AssignRoom(vdate,cid,day,roomno,contact);
        }
        public bool InsertBill(int cid, int contact)
        {
            return b.InsertBill(cid, contact);
        }
        public bool UpdateBillId(int ammount, int id)
        {
            return b.UpdateBillById(ammount,id);
        }
        public bool UpdateBillContact(int ammount, int contact)
        {
            return b.UpdateBillById(ammount, contact);
        }
        public bool UpdateBillFinalByContact(int contact)
        {
            return b.UpdateBillFinalByContact(contact);
        }
        public bool UpdateBillFinalById(int id)
        {
            return b.UpdateBillFinalById(id);
        }
        public DataTable GeneratedBillId(int id)
        {
            return b.GeneratedBillId(id);
        }
        public DataTable GeneratedBillContact(int contact)
        {
            return b.GeneratedBillContact(contact);
        }
        public bool UpdateRevenue(int ammount, string date)
        {
            if (b.UpdateRevenue(ammount, date))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

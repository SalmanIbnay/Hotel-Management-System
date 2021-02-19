using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel_Management.Data_Access_Layer;

namespace Hotel_Management.Business_Logic_Layer
{
    class Admin
    {
        AdminData ad = new AdminData();
        ManagerData md = new ManagerData();
        public bool AdminLogin(int id,string password)
        {
            return ad.AdminLogin(id,password);
        }
        public bool AdminCreate(string fname, string lname, string dob, int contact1,string gender, string jDate, string email, string password,string address, int sal)
        {
            return ad.AdminCreate(fname,lname,dob,contact1,gender,jDate,email,password,address,sal);
        }
        public bool AdminCreate(string fname, string lname, string dob, int contact1,int contact2, string gender, string jDate, string email, string password, string address, int sal)
        {
            return ad.AdminCreate(fname, lname, dob, contact1,contact2, gender, jDate, email, password, address, sal);
        }
        
    }
}

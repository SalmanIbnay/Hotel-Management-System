using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel_Management.Data_Access_Layer;
using System.Data;

namespace Hotel_Management.Business_Logic_Layer
{
    class Manager
    {
        RoomData r = new RoomData();
        ManagerData md = new ManagerData();
        public bool ManagerLogin(int id, string password)
        {
            return md.ManagerLogin(id, password);
        }
        public bool ManagerCreate(string fname, string lname, string dob, int contact1, string gender, string jDate, string email, string password, string address, int sal)
        {
            return md.ManagerCreate(fname, lname, dob, contact1, gender, jDate, email, password, address, sal);
        }
        public bool ManagerCreate(string fname, string lname, string dob, int contact1, int contact2, string gender, string jDate, string email, string password, string address, int sal)
        {
            return md.ManagerCreate(fname, lname, dob, contact1, contact2, gender, jDate, email, password, address, sal);
        }

        public DataTable GetAllManagers()
        {
            return md.GetAllManagers();
        }
        public bool ManagerUpdate(int id, string fname, string lname, int contact, string address, string email, string password, int sal)
        {
            return md.ManagerUpdate(id, fname, lname, contact, address, email, password, sal);
        }

        public bool Delete(int id)
        {
            return md.Delete(id);
        }
        public bool Insertroom(int roomno,int rent,int contact)
        {
            if (r.InsertRoom(roomno, rent, contact))
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

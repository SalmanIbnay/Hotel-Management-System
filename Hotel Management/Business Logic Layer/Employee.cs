using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Hotel_Management.Data_Access_Layer;

namespace Hotel_Management.Business_Logic_Layer
{
    class Employee
    {
        EmployeeData ed = new EmployeeData();
        public bool EmployeeLogin(int id, string password)
        {
            return ed.EmployeeLogin(id, password);
        }
        public bool EmployeeCreate(string fname, string lname, string dob, int contact1, string gender, string jDate, string email, string password, string address, int sal)
        {
            return ed.EmployeeCreate(fname, lname, dob, contact1, gender, jDate, email, password, address, sal);
        }
        public DataTable  GetAllEmployee()
        {
            return ed.GetEmployee();
        }
    }
}

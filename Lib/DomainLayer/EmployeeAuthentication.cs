using Lib.DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.DomainLayer
{
    public class EmployeeAuthentication
    {
        private Employee _employee = null;
        public Employee employee{ get { return _employee; } }


        public EmployeeAuthentication()
        {
        }

        public bool Login(string email, string password)
        {
            Employee tmp = Employee.GetByEmail(email);
            try { 
                if (tmp.Password == password)
                {
                    _employee = tmp;
                    return true;
                }
                else
                    return false;
            }
            catch
            {
                return false;
            }


        }


    }
}

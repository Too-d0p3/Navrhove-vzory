using Lib.DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Lib.DomainLayer
{
    public class UserAuthentication
    {
        private User _user = null;
        public User user{ get { return _user; } }


        public UserAuthentication()
        {
        }

        public static bool Login(string email, string password)
        {
            User tmp = User.GetByEmail(email);
            try { 
                if (tmp.Password == password)
                {
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

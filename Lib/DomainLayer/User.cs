using Lib.DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.DomainLayer
{
    public class User
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public Address address { get; set; }
        public string Email { get; set; }
        public int phone { get; set; }

        public void Insert()
        {
            UserTableGateway DataGateway = new UserTableGateway();
            DataGateway.Insert(FirstName, LastName, Email, Password);
        }

        public static User GetByID(int id)
        {
            try
            {
                UserTableGateway DataGateway = new UserTableGateway();
                DataTable TableData = DataGateway.FindByID(id);
                DataRow row = TableData.Rows[0];
                return map(row);
            }
            catch
            {
                return null;
            }
        }

        public static User GetByEmail(string email)
        {
            try
            {
                UserTableGateway DataGateway = new UserTableGateway();
                DataTable TableData = DataGateway.FindByEmail(email);
                DataRow row = TableData.Rows[0];
                return map(row);
            }
            catch
            {
                return null;
            }
        }

        public static List<User> getList()
        {
            UserTableGateway DataGateway = new UserTableGateway();
            DataTable TableData = DataGateway.Find();
            List<User> tmp = new List<User>();
            foreach (DataRow row in TableData.Rows)
            {
                tmp.Add(map(row));
            }
            return tmp;
        }

        private static User map(DataRow row)
        {
            User tmp = new User
            {

                ID = int.Parse(row[0].ToString()),
                FirstName = row[1].ToString(),
                LastName = row[2].ToString(),
                Password = row[3].ToString(),
                address = Address.getByID(int.Parse(row[4].ToString())),
                Email = row[5].ToString(),
                phone = int.Parse(row[6].ToString())
            };
            return tmp;
        }
    }
}

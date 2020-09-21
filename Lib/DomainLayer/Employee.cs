using Lib.DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.DomainLayer
{
    public class Employee
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public Address address { get; set; }
        public int SalaryValue { get; set; }
        public string Email { get; set; }

        private Lazy<List<Salary>> _salaryList;
        public List<Salary> salaryList { 
            get {
                return _salaryList.Value;
            } 
        }

        private bool _isAdmin = false;
        public bool isAdmin{ 
            get { return _isAdmin; } 
            set {
                AdminTableGateway DataGateway = new AdminTableGateway();
                DataTable TableData = DataGateway.FindByEmployeeID(ID);
                if (TableData.Rows.Count > 0)
                {
                    _isAdmin = true;             
                }
            }
        }
        
        public Employee()
        {
            _salaryList = new Lazy<List<Salary>>(() => GetEmployeeSalary());
        }

        private List<Salary> GetEmployeeSalary()
        {
            return Salary.getByEmployeeID(ID);
        }

        public static Employee GetByID(int id)
        {
            //TableData = dataGateway.FindByID(id);
            try
            {
                EmployeeTableGateway DataGateway = new EmployeeTableGateway();
                DataTable TableData = DataGateway.FindByID(id);
                DataRow row = TableData.Rows[0];
                return map(row);
            }
            catch
            {
                return null;
            }
        }

        public static Employee GetByEmail(string email)
        {
            try
            {
                EmployeeTableGateway DataGateway = new EmployeeTableGateway();
                DataTable TableData = DataGateway.FindByEmail(email);
                DataRow row = TableData.Rows[0];
                return map(row);
            }
            catch
            {
                return null;
            }
        }

        public static List<Employee> getList()
        {
            EmployeeTableGateway DataGateway = new EmployeeTableGateway();
            DataTable TableData = DataGateway.Find();
            List<Employee> tmp = new List<Employee>();
            foreach(DataRow row in TableData.Rows)
            {
                tmp.Add(map(row));
            }
            return tmp;
        }

        private static Employee map(DataRow row)
        {
            Employee tmp = new Employee
            {

                ID = int.Parse(row[0].ToString()),
                FirstName = row[1].ToString(),
                LastName = row[2].ToString(),
                Password = row[3].ToString(),
                address = Address.getByID(int.Parse(row[4].ToString())),
                SalaryValue = int.Parse(row[5].ToString()),
                Email = row[6].ToString(),
                isAdmin = false
            };
            return tmp;
        }

    }
}

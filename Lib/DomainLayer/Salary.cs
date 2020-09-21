using Lib.DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.DomainLayer
{
    public class Salary
    {
        public int ID { get; set; }
        public int ID_Employee { get; set; }
        public int Hours { get; set; }
        public DateTime Date { get; set; }

        public static List<Salary> getByEmployeeID(int id)
        {
            
            SalaryTableGateway DataGateway = new SalaryTableGateway();
            
            DataTable TableData = DataGateway.FindByEmployeeID(id);
            List<Salary> tmp = new List<Salary>();
            
            foreach (DataRow row in TableData.Rows)
            {
                tmp.Add(map(row));
            }
            return tmp;
        }

        private static Salary map(DataRow row)
        {
            Salary tmp = new Salary
            {
                ID = int.Parse(row[0].ToString()),
                ID_Employee = int.Parse(row[1].ToString()),
                Hours = int.Parse(row[2].ToString()),
                Date = DateTime.Parse(row[3].ToString())
            };
            

            return tmp;
        }

    }
}

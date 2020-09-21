using Lib.DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.DomainLayer
{
    public class Address
    {
        public int ID { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public int PSC { get; set; }

        public static Address getByID(int id)
        {
            try
            {
                AddressTableGateway DataGateway = new AddressTableGateway();
                DataTable TableData = DataGateway.FindByID(id);
                DataRow row = TableData.Rows[0];
                return map(row);
            }
            catch
            {
                return null;
            }
        }


        public static Address map(DataRow row)
        {
            Address tmp = new Address
            {
                ID = int.Parse(row[0].ToString()),
                Street = row[1].ToString(),
                City = row[2].ToString(),
                PSC = int.Parse(row[3].ToString())
            };
            return tmp;
        }
    }
}

using Lib.DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.DomainLayer
{
    class Order
    {
        public int ID { get; set; }
        public User user { get; set; }
        public Car car { get; set; }
        public DateTime Date { get; set; }


        public static List<Order> getList()
        {
            OrderTableGateway DataGateway = new OrderTableGateway();
            DataTable TableData = DataGateway.Find();
            List<Order> tmp = new List<Order>();
            foreach (DataRow row in TableData.Rows)
            {
                tmp.Add(map(row));
            }
            return tmp;
        }

        public static List<Order> getListByUserID(int id)
        {
            OrderTableGateway DataGateway = new OrderTableGateway();
            DataTable TableData = DataGateway.Find(id);
            List<Order> tmp = new List<Order>();
            foreach (DataRow row in TableData.Rows)
            {
                tmp.Add(map(row));
            }
            return tmp;
        }


        public static Order GetByID(int id)
        {
            try
            {
                OrderTableGateway DataGateway = new OrderTableGateway();
                DataTable TableData = DataGateway.FindByID(id);
                DataRow row = TableData.Rows[0];
                return map(row);
            }
            catch
            {
                return null;
            }
        }

        public static Order GetByCarID(int id)
        {
            try
            {
                OrderTableGateway DataGateway = new OrderTableGateway();
                DataTable TableData = DataGateway.FindByCarID(id);
                DataRow row = TableData.Rows[0];
                return map(row);
            }
            catch
            {
                return null;
            }
        }

        private static Order map(DataRow row)
        {
            Order tmp = new Order
            {
                ID = int.Parse(row[0].ToString()),
                user = User.GetByID(int.Parse(row[1].ToString())),
                car = Car.getCarByID(int.Parse(row[2].ToString())),
                Date = DateTime.Parse(row[3].ToString())
            };
            return tmp;
        }
    }
}

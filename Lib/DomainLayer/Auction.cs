using Lib.DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.DomainLayer
{
    public class Auction
    {
        public int ID { get; set; }
        public int ID_car { get; set; }
        public int CurrentBid { get; set; }
        public int StartBid { get; set; }
        public User user { get; set; }
        public DateTime CurrentBidDate { get; set; }
        public DateTime EndDate { get; set; }


        public bool increaseBid(User user, int bid)
        {
            if(user.ID != this.user.ID)
            {
                Car car = Car.getCarByID(ID_car);
                if(car.user.ID != user.ID)
                {
                    if(DateTime.Now < EndDate)
                    {
                        if(bid > CurrentBid * 1.02)
                        {
                            Console.WriteLine("Zvyseno");
                            AuctionTableGateway DataGateway = new AuctionTableGateway();
                            DataGateway.updateByID(ID, user.ID, DateTime.Now, bid);
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public static Auction GetByID(int id)
        {
            try
            {
                AuctionTableGateway DataGateway = new AuctionTableGateway();
                DataTable TableData = DataGateway.FindByID(id);
                DataRow row = TableData.Rows[0];
                return map(row);
            }
            catch
            {
                return null;
            }
        }

        public static List<Auction> getUserAuctionListByID(int id)
        {
            AuctionTableGateway DataGateway = new AuctionTableGateway();
            DataTable TableData = DataGateway.FindByUserID(id);
            List<Auction> tmp = new List<Auction>();
            foreach (DataRow row in TableData.Rows)
            {
                tmp.Add(map(row));
            }
            return tmp;
        }

        public static Auction GetByCarID(int id)
        {
            try
            {
                AuctionTableGateway DataGateway = new AuctionTableGateway();
                DataTable TableData = DataGateway.FindByCarID(id);
                DataRow row = TableData.Rows[0];
                return map(row);
            }
            catch
            {
                return null;
            }
        }


        private static Auction map(DataRow row)
        {
            Auction tmp = new Auction
            {
                ID = int.Parse(row[0].ToString()),
                ID_car = int.Parse(row[1].ToString()),
                CurrentBid = int.Parse(row[2].ToString()),
                StartBid = int.Parse(row[3].ToString()),
                user = User.GetByID(int.Parse(row[4].ToString())),
                CurrentBidDate = DateTime.Parse(row[5].ToString()),
                EndDate = DateTime.Parse(row[6].ToString())
            };
            return tmp;
        }

    }
}

using Lib.DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Lib.DomainLayer
{
    public class Car
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public double Consumption { get; set; }
        public int Price { get; set; }
        public bool IsOnMarket { get; set; }
        public int YearOfManufacture { get; set; }
        public int Tachometer { get; set; }
        public string Fuel { get; set; }
        public User user { get; set; }
        public Auction auction { get; set; }


        public static void toXML()
        {
            List<Car> cars = Car.getList();
            XmlDocument doc = new XmlDocument();
            XmlElement e = (XmlElement)doc.AppendChild(doc.CreateElement("Cars"));
            foreach (Car car in cars)
            {
                XmlElement el = (XmlElement)e.AppendChild(doc.CreateElement("Car"));
                el.SetAttribute("ID", car.ID.ToString());
                el.AppendChild(doc.CreateElement("Name")).InnerText = car.Name;
                el.AppendChild(doc.CreateElement("Type")).InnerText = car.Type;
                el.AppendChild(doc.CreateElement("Consumption")).InnerText = car.Consumption.ToString();
                el.AppendChild(doc.CreateElement("Price")).InnerText = car.Price.ToString();
                el.AppendChild(doc.CreateElement("IsOnMarket")).InnerText = car.IsOnMarket.ToString();
                el.AppendChild(doc.CreateElement("YearOfManufacture")).InnerText = car.YearOfManufacture.ToString();
                el.AppendChild(doc.CreateElement("Tachometer")).InnerText = car.Tachometer.ToString();
                el.AppendChild(doc.CreateElement("Fuel")).InnerText = car.Fuel;
                el.AppendChild(doc.CreateElement("ID_User")).InnerText = car.user.ID.ToString();
            }

            doc.Save("./cars.xml");
        }

        public static List<Car> loadFromXML()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("./cars.xml");
            List<Car> cars = new List<Car>();
            
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                // first node is the url ... have to go to nexted loc node
                Car tmp = new Car();
                tmp.ID = int.Parse(node.Attributes["ID"].Value);
              
                foreach (XmlNode locNode in node)
                {
                    
                    switch (locNode.Name)
                    {
                        case "Name":
                            tmp.Name = locNode.InnerText;
                            break;
                        case "Type":
                            tmp.Type = locNode.InnerText;
                            break;
                        case "Consumption":
                            tmp.Consumption = double.Parse(locNode.InnerText);
                            break;
                        case "Price":
                            tmp.Price = int.Parse(locNode.InnerText);
                            break;
                        case "IsOnMarket":
                            tmp.IsOnMarket = bool.Parse(locNode.InnerText);
                            break;
                        case "YearOfManufacture":
                            tmp.YearOfManufacture = int.Parse(locNode.InnerText);
                            break;
                        case "Tachometer":
                            tmp.Tachometer = int.Parse(locNode.InnerText);
                            break;
                        case "Fuel":
                            tmp.Fuel = locNode.InnerText;
                            break;
                        case "ID_User":
                            tmp.user = User.GetByID(int.Parse(locNode.InnerText));
                            break;
                    }                                
                }
                cars.Add(tmp);
            }
            return cars;

        }

        public bool hasCarAuction()
        {
            if (auction == null)
                return false;
            else
                return true;
        }
        public static void syncXmlWithDB(List<Car> cars)
        {
            foreach(Car car in cars)
            {
                if(Car.getCarByID(car.ID) == null)
                {
                    car.Insert();
                }
            }
        }

        public int calcCarPrice()
        {
            List<Car> cars = Car.getList();
            int price = 0;
            int count = 0;
            foreach(Car car in cars)
            {

                if(Math.Abs(car.Tachometer-Tachometer) < 50000){
                    if(car.Type == Type)
                    {
                        if (Math.Abs(car.YearOfManufacture - YearOfManufacture) < 4)
                        {
                            price += car.Price;
                            count++;
                        }
                    }
                }
            }
            return price/count;
        }

        public static void Delete(int ID)
        {
            CarTableGateway DataGateway = new CarTableGateway();
            DataGateway.Delete(ID);
        }

        public void Update()
        {
            CarTableGateway DataGateway = new CarTableGateway();
            DataGateway.Update(ID ,Name, Type, Consumption, Price, IsOnMarket, YearOfManufacture, Tachometer, Fuel, user.ID);
        }

        public void Insert()
        {
            CarTableGateway DataGateway = new CarTableGateway();
            DataGateway.Insert(Name, Type, Consumption, Price, IsOnMarket, YearOfManufacture, Tachometer, Fuel, user.ID);
        }
        public static Car getCarByID(int id) {
            try
            {
                CarTableGateway DataGateway = new CarTableGateway();
                DataTable TableData = DataGateway.FindByID(id);
                DataRow row = TableData.Rows[0];
                return map(row);
            }
            catch
            {
                return null;
            }
        }

        public static List<Car> getCarsByUserID(int id)
        {
            CarTableGateway DataGateway = new CarTableGateway();
            DataTable TableData = DataGateway.FindByUserID(id);
            List<Car> tmp = new List<Car>();
            foreach (DataRow row in TableData.Rows)
            {
                tmp.Add(map(row));
            }
            return tmp;
        }

        public static List<Car> getList()
        {
            CarTableGateway DataGateway = new CarTableGateway();
            DataTable TableData = DataGateway.Find();
            List<Car> tmp = new List<Car>();
            foreach (DataRow row in TableData.Rows)
            {
                tmp.Add(map(row));
            }
            return tmp;
        }


        private static Car map(DataRow row)
        {
            Car tmp = new Car
            {
                ID = int.Parse(row[0].ToString()),
                Name = row[1].ToString(),
                Type = row[2].ToString(),
                Consumption = double.Parse(row[3].ToString()),
                Price = int.Parse(row[4].ToString()),
                IsOnMarket = bool.Parse(row[5].ToString()),
                YearOfManufacture = int.Parse(row[6].ToString()),
                Tachometer = int.Parse(row[7].ToString()),
                Fuel = row[8].ToString(),
                user = User.GetByID(int.Parse(row[9].ToString())),
                auction = Auction.GetByCarID(int.Parse(row[0].ToString()))
            };
            return tmp;
        }

    }
}

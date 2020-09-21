using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.DataLayer
{
    class CarTableGateway
    {
        public DataTable FindByID(int id)
        {
            var dataTable = new DataTable();
            string sql = "SELECT * FROM CARS WHERE ID = @id;";

            using (MySqlConnection connection = new MySqlConnection(DBConnector.GetBuilder().ConnectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        dataTable.Load(reader);
                    }
                }
            }
            return dataTable;
        }


        public DataTable Find()
        {
            var dataTable = new DataTable();
            string sql = "SELECT * FROM CARS";

            using (MySqlConnection connection = new MySqlConnection(DBConnector.GetBuilder().ConnectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        dataTable.Load(reader);
                    }
                }
            }
            return dataTable;
        }

        public DataTable FindByUserID(int id)
        {
            var dataTable = new DataTable();
            string sql = "SELECT * FROM CARS WHERE ID_User = @id;";

            using (MySqlConnection connection = new MySqlConnection(DBConnector.GetBuilder().ConnectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        dataTable.Load(reader);
                    }
                }
            }
            return dataTable;
        }

        public void Insert(string Name, string Type, double Consumption, int Price, bool IsOnMarket, int YearOfManufacture, int Tachometer, string Fuel, int ID_User)
        {
            string sql = "INSERT INTO CARS(Name, Type, Consumption, Price, IsOnMarket, YearOfManufacture, Tachometer, Fuel, ID_User) VALUES ( @Name, @Type, @Consumption, @Price, @IsOnMarket, @YearOfManufacture, @Tachometer, @Fuel, @ID_User);";
            using (MySqlConnection connection = new MySqlConnection(DBConnector.GetBuilder().ConnectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Name", Name);
                    command.Parameters.AddWithValue("@Type", Type);
                    command.Parameters.AddWithValue("@Consumption", Consumption);
                    command.Parameters.AddWithValue("@Price", Price);
                    command.Parameters.AddWithValue("@IsOnMarket", IsOnMarket);
                    command.Parameters.AddWithValue("@YearOfManufacture", YearOfManufacture);
                    command.Parameters.AddWithValue("@Tachometer", Tachometer);
                    command.Parameters.AddWithValue("@Fuel", Fuel);
                    command.Parameters.AddWithValue("@ID_User", ID_User);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Close();
                }
            }
        }

        public void Delete(int ID)
        {
            string sql = "DELETE FROM CARS WHERE ID = @id;";
            using (MySqlConnection connection = new MySqlConnection(DBConnector.GetBuilder().ConnectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id", ID);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Close();
                }
            }
        }

        public void Update(int ID,string Name, string Type, double Consumption, int Price, bool IsOnMarket, int YearOfManufacture, int Tachometer, string Fuel, int ID_User)
        {
            string sql = "UPDATE CARS SET Name=@Name, Type=@Type, Consumption=@Consumption, Price=@Price, IsOnMarket=@IsOnMarket, YearOfManufacture=@YearOfManufacture, Tachometer=@Tachometer, Fuel=@Fuel, ID_User=@ID_User WHERE ID = @id;";
            using (MySqlConnection connection = new MySqlConnection(DBConnector.GetBuilder().ConnectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Name", Name);
                    command.Parameters.AddWithValue("@Type", Type);
                    command.Parameters.AddWithValue("@Consumption", Consumption);
                    command.Parameters.AddWithValue("@Price", Price);
                    command.Parameters.AddWithValue("@IsOnMarket", IsOnMarket);
                    command.Parameters.AddWithValue("@YearOfManufacture", YearOfManufacture);
                    command.Parameters.AddWithValue("@Tachometer", Tachometer);
                    command.Parameters.AddWithValue("@Fuel", Fuel);
                    command.Parameters.AddWithValue("@ID_User", ID_User);
                    command.Parameters.AddWithValue("@id", ID);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Close();
                }
            }
        }

    }
}

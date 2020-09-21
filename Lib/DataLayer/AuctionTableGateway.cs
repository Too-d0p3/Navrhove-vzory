using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.DataLayer
{
    class AuctionTableGateway
    {
        public DataTable FindByID(int id)
        {
            var dataTable = new DataTable();
            string sql = "SELECT * FROM AUCTION WHERE ID = @id;";

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


        public DataTable FindByUserID(int id)
        {
            var dataTable = new DataTable();
            string sql = "SELECT * FROM AUCTION WHERE ID_User = @id;";

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

        public DataTable FindByCarID(int id)
        {
            var dataTable = new DataTable();
            string sql = "SELECT * FROM AUCTION WHERE ID_Car = @id;";

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


        public void updateByID(int id, int User_ID, DateTime dateTime, int bid)
        {
            string sql = "UPDATE AUCTION SET CurrentBid=@CurrentBid, ID_User=@ID_User, CurrentBidDate=@CurrentBidDate WHERE ID=@id";
            using (MySqlConnection connection = new MySqlConnection(DBConnector.GetBuilder().ConnectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@ID_User", User_ID);
                    command.Parameters.AddWithValue("@CurrentBidDate", dateTime);
                    command.Parameters.AddWithValue("@CurrentBid", bid);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                    }
                }
            }
        }

    }


}

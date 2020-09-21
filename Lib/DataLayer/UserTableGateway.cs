using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.DataLayer
{
    class UserTableGateway
    {
        public DataTable FindByID(int id)
        {
            var dataTable = new DataTable();
            string sql = "SELECT * FROM USER WHERE ID = @id;";

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
            string sql = "SELECT * FROM USER";

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

        public DataTable FindByEmail(string email)
        {
            var dataTable = new DataTable();
            string sql = "SELECT * FROM USER WHERE EMAIL = @email;";

            using (MySqlConnection connection = new MySqlConnection(DBConnector.GetBuilder().ConnectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@email", email);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        dataTable.Load(reader);
                    }
                }
            }
            return dataTable;
        }

        public void Insert(string FirstName, string LastName, string Email, string Password)
        {
            string sql = "INSERT INTO USER(FirstName,LastName,Email, Password) VALUES ( @FirstName, @LastName, @Email, @Password);";
            using (MySqlConnection connection = new MySqlConnection(DBConnector.GetBuilder().ConnectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@FirstName", FirstName);
                    command.Parameters.AddWithValue("@LastName", LastName);
                    command.Parameters.AddWithValue("@Email", Email);
                    command.Parameters.AddWithValue("@Password", Password);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Close();
                }
            }
        }
    }
}

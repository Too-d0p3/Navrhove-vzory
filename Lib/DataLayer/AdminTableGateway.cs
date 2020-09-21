using MySql.Data.MySqlClient;
using System.Data;

namespace Lib.DataLayer
{
    internal class AdminTableGateway
    {
        public DataTable FindByEmployeeID(int id)
        {
            var dataTable = new DataTable();
            string sql = "SELECT * FROM ADMIN WHERE ID_EMPLOYEE = @id;";

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
    }
}
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.DataLayer
{
    class SalaryTableGateway
    {
        public DataTable FindByEmployeeID(int id)
        {
            var dataTable = new DataTable();
            string sql = "SELECT * FROM SALARY WHERE ID_EMPLOYEE = @id;";

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

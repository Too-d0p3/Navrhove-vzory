using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.DataLayer
{
    class DBConnector
    {
        public static MySqlConnectionStringBuilder GetBuilder()
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = "localhost";
            builder.Database = "autobazar";
            builder.UserID = "root";     
            builder.Password = "";
            return builder;
        }
    }
}

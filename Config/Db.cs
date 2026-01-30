using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SistemaDeReservas.Config
{
    internal class Db
    {
        private static string dbConfig = "Server=localhost\\SQLEXPRESS; Database=ReservationSystem; Integrated Security=true";
        private static SqlConnection connection = new SqlConnection(dbConfig);

        public static SqlConnection getConnection()
        {
            return connection; 
        }
    
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cau1.EmployeeDTO
{
    public class DBConnection
    {
        public DBConnection()
        {

        }
        public SqlConnection CreateConnection()
        {
            SqlConnection conn = new SqlConnection
            {
                ConnectionString = @"Data Source=DESKTOP-MDGC5QQ\SQLEXPRESS;Initial Catalog=HR;User Id=sa;Password=sa"
            };
            return conn;
        }
    }
}

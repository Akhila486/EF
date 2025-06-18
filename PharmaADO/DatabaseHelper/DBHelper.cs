
using System.Data.SqlClient;

namespace PharmaADO.DatabaseHelper
{
    public class DBHelper
    {
        private readonly IConfiguration _configuration;//for security as private
        public DBHelper(IConfiguration configuration1)  //encapsulation
        {
            _configuration = configuration1;

        }
        public SqlConnection GetConnection() 
        {
            var connString = _configuration.GetConnectionString("MedicineConnection");

            return new SqlConnection(connString);
        }
    }
}

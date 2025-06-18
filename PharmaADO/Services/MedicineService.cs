using System.Data.SqlClient;
using PharmaADO.DatabaseHelper;
using PharmaADO.Models;
using PharmaADO.Services.Interfaces;

namespace PharmaADO.Services
{
    public class MedicineService : IMedicine
    {
        private readonly DBHelper _dbHelper;
        public MedicineService(DBHelper dBHelper)
        {
            _dbHelper = dBHelper;
        }
        public List<Medicine> GetMedicines()
        {
            var medicines = new List<Medicine>();
            using (SqlConnection conn = _dbHelper.GetConnection())
            {
                //open the connection
                conn.Open();

                //give the command
                string command = "select * from [AdventureWorks2022].[dbo].[Medicines]";
                SqlCommand cmd = new SqlCommand(command, conn);

                //execute and read the data 
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        medicines.Add(new Medicine
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),


                        });
                    }

                }
                //return the data
                return medicines;
            }
        }
    }
}

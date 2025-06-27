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

        public Medicine GetMedicineById(int id)
        {
            Medicine akhila = null;
            try
            {
                //open the connection
                using (SqlConnection conn = _dbHelper.GetConnection())
                {
                    conn.Open();


                    //command to connect to database
                    string query = "select * from [AdventureWorks2022].[dbo].[Medicines] where Id=@medicine_id";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@medicine_id", id);
                    //execute the command
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        if (reader.Read())
                        {
                            akhila = new Medicine
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1)

                            };
                        }
                    }

                   
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine( ex.Message);
            }
            return akhila;
            //return akhila == null ? null : new Medicine();
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

using System.Data;
using System.Data.SqlClient;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http.HttpResults;
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

        public String CreateMedicines(Medicine medicine)
        {
            int ret = 0;
            string retMessage = "";
            //open the database connection

            using (SqlConnection conn = _dbHelper.GetConnection())
            {
                conn.Open();
                string insertQuery = @"INSERT INTO [dbo].[Medicines]
            (Name
            ,Price
            ,Quantity
            ,Manufacturer
            ,ExpiredDate
            ,ManufacturingDate
            ,CustomerID)
              VALUES (@name, @price, @quantity, @Manufacturer, @ed, @md, @ci)
              select SCOPE_IDENTITY()";

                using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                {
                    cmd.Parameters.Add("@name", SqlDbType.NVarChar, 100).Value = medicine.Name;
                    cmd.Parameters.Add("@price", SqlDbType.Decimal).Value = medicine.Price;
                    cmd.Parameters.Add("@quantity", SqlDbType.Int).Value = medicine.Quantity;
                    cmd.Parameters.Add("@Manufacturer", SqlDbType.NVarChar, 100).Value = medicine.Manufacturer;
                    cmd.Parameters.Add("@ed", SqlDbType.DateTime2).Value = medicine.ExpiredDate;
                    cmd.Parameters.Add("@md", SqlDbType.DateTime2).Value = medicine.ManufacturingDate;
                    cmd.Parameters.Add("@ci", SqlDbType.Int).Value = medicine.CustomerID;
                    //Console.WriteLine();
                    ret = Convert.ToInt32(cmd.ExecuteScalar());
                    if (ret>0)
                    {
                        //retMessage = "Record Inserted successfully with Id="+ret +"hello";
                        retMessage = $"Record Inserted successfully with Id={ret} hello" ;
                    }
                }
            }

            //create command and execute will post the data to database
            return retMessage;

        }

        

        /*
public int CreateMedicines(Medicine medicine)
{
   if (medicine == null)
       throw new ArgumentNullException(nameof(medicine));

   int ret = 0;

   if (_dbHelper == null)
       throw new InvalidOperationException("_dbHelper is not initialized.");

   using (SqlConnection conn = _dbHelper.GetConnection())
   {
       conn.Open();
       string insertQuery = @"
       INSERT INTO [dbo].[Medicines] 
       (Name, Price, Quantity, Manufacturer, ExpiredDate, ManufacturingDate, CustomerID)
       VALUES (@name, @price, @quantity, @Manufacturer, @ed, @md, @ci)";

       using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
       {
           cmd.Parameters.Add("@name", SqlDbType.NVarChar, 100).Value = medicine.Name ?? (object)DBNull.Value;
           cmd.Parameters.Add("@price", SqlDbType.Decimal).Value = medicine.Price;
           cmd.Parameters.Add("@quantity", SqlDbType.Int).Value = medicine.Quantity;
           cmd.Parameters.Add("@Manufacturer", SqlDbType.NVarChar, 100).Value = medicine.Manufacturer ?? (object)DBNull.Value;
           cmd.Parameters.Add("@ed", SqlDbType.DateTime2).Value = medicine.ExpiredDate;
           cmd.Parameters.Add("@md", SqlDbType.DateTime2).Value = medicine.ManufacturingDate;
           cmd.Parameters.Add("@ci", SqlDbType.Int).Value = medicine.CustomerID;

           // Get the inserted ID
           // ret = (int)cmd.ExecuteScalar()


           object result = cmd.ExecuteScalar();
           if (result != null)
           {
               ret = Convert.ToInt32(result);
           }
           else
           {
               // Handle the case where the ID isn't returned or something went wrong
               ret = 0;  // You could throw an exception here if the insert failed.
           }
       }
   }

   return ret;
}

*/

        public Medicine GetMedicineById(int id)
        {
            Medicine akhila = null;
            SqlConnection conn = null;
            SqlCommand cmd = null;
            SqlDataAdapter adapter = null;
            DataSet ds = new DataSet();

            try
            {
                conn = _dbHelper.GetConnection();
                conn.Open();

                string query = "SELECT * FROM [AdventureWorks2022].[dbo].[Medicines] WHERE Id = @medicine_id";

                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@medicine_id", id);

                adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);

                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    DataRow row = ds.Tables[0].Rows[0];

                    akhila = new Medicine
                    {
                        Id = row["Id"] != DBNull.Value ? Convert.ToInt32(row["Id"]) : 0,
                        Name = row["Name"] != DBNull.Value ? row["Name"].ToString() : null
                    };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return akhila;
            //return akhila == null ? null : new Medicine();

        }


        public String DeleteMedicineById(int id)
        {
            string retMessage = " ";
            using (SqlConnection conn = _dbHelper.GetConnection())
            {
                conn.Open();


                string command = "Delete from [AdventureWorks2022].[dbo].[Medicines] where Id=@id";
                SqlCommand cmd = new SqlCommand(command, conn);
                cmd.Parameters.Add("id", SqlDbType.Int).Value = id;
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    retMessage = $"Updated medicine successfully for id={id}";
                }

                return retMessage;
            }
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

        public string UpdateMedicines(Medicine medicine)
        {
            string retMessage = "";
            string query = @"UPDATE [dbo].[Medicines]
            SET Name=@name,Price = @price where Id=@id";
            try
            {
                using SqlConnection conn = _dbHelper.GetConnection();
                using SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add("@name", SqlDbType.NVarChar, 100).Value = medicine.Name;
                cmd.Parameters.Add("@price", SqlDbType.Decimal).Value = medicine.Price;
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = medicine.Id;
                conn.Open();
                int rowsAffected=cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    retMessage = $"Updated medicine successfully for id={medicine.Id}";
                }
            }
            catch (Exception ex)
            {

            }

            return retMessage;
        }
    }
}

﻿using System.Data;
using System.Data.SqlClient;
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

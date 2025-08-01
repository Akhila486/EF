﻿
using System.Data;
using System.Data.SqlClient;
using System.Text.Json;
using Microsoft.AspNetCore.Http.HttpResults;
using PharmaADO.DatabaseHelper;
using PharmaADO.Models;
using PharmaADO.Services.Interfaces;

namespace PharmaADO.Services

{
    public class CustomerService : ICustomer
    {
        private readonly DBHelper _dbHelper;
        public CustomerService(DBHelper dBHelper)
        {
            _dbHelper = dBHelper;
        }

        public Customer GetCustomerById(int id)
        {
            Customer akhila = null;
            SqlConnection conn = null;
            SqlCommand cmd = null;
            SqlDataAdapter adapter = null;
            DataSet ds = new DataSet();

            try
            {
                conn = _dbHelper.GetConnection();
                conn.Open();

                string query = "SELECT * FROM [AdventureWorks2022].[dbo].[Customers] WHERE Id = @customer_id";

                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@customer_id", id);

                adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);

                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    DataRow row = ds.Tables[0].Rows[0];

                    akhila = new Customer
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
        public List<Customer> GetCustomers()
        {
            var customers = new List<Customer>();
            using (SqlConnection conn = _dbHelper.GetConnection())
            {
                //open the connection
                conn.Open();

                //give the command
                string command = "select * from [AdventureWorks2022].[dbo].[Customers]";
                SqlCommand cmd = new SqlCommand(command, conn);

                //execute and read the data 
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        customers.Add(new Customer
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),


                        });
                    }

                }
                //return the data
                return customers;
            }
        }

        public String CreateCustomers(Customer customer)
        {
            int ret = 0;
            string retMessage = "";
            //open the database connection
            string jsonData = JsonSerializer.Serialize(customer, new JsonSerializerOptions { WriteIndented = true });

            using (SqlConnection conn = _dbHelper.GetConnection())
            {
                conn.Open();
                string insertQuery = @"INSERT INTO [dbo].[Customers]
            (Name, MedicinesJson)
              VALUES (@name, @medicinesJson )
              select SCOPE_IDENTITY()";

                using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                {
                    cmd.Parameters.Add("@name", SqlDbType.NVarChar, 100).Value = customer.Name;
                    cmd.Parameters.Add("@medicinesJson", SqlDbType.NVarChar).Value = jsonData;

                    //Console.WriteLine();
                    ret = Convert.ToInt32(cmd.ExecuteScalar());
                    if (ret > 0)
                    {
                        //retMessage = "Record Inserted successfully with Id="+ret +"hello";
                        retMessage = $"Record Inserted successfully with Id={ret} hello";
                    }
                }
            }

            //create command and execute will post the data to database
            return retMessage;

        }




        public string UpdateCustomers(Customer customer)
        {
            string retMessage = "";
            string query = @"UPDATE [dbo].[Customers]
            SET Name=@name where Id=@id";
            try
            {
                using SqlConnection conn = _dbHelper.GetConnection();
                using SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add("@name", SqlDbType.NVarChar, 100).Value = customer.Name;
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = customer.Id;

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    retMessage = $"Updated medicine successfully for id={customer.Id}";
                }
            }
            catch (Exception ex)
            {

            }

            return retMessage;
        }

        public string createCustomerWithMedicine(Customer customer)
        {
            int customerId = 0;
            string retMessage=null;
            //open connection
            try
            {
                using SqlConnection conn = _dbHelper.GetConnection();
                conn.Open();

                //begin transactions
                using var transaction = conn.BeginTransaction();

                //customer insert
                string insertCustomer = @"INSERT INTO [dbo].[Customers]
            (Name)
              VALUES (@name)
              select SCOPE_IDENTITY()";

                using (SqlCommand cmd = new SqlCommand(insertCustomer, conn, transaction))
                {
                    cmd.Parameters.Add("@name", SqlDbType.NVarChar, 100).Value = customer.Name;

                    //retrieve the inserted customerid
                    customerId = Convert.ToInt32(cmd.ExecuteScalar());

                }

                if (customer.Medicines.Any())
                {

                    //insert medicines
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

                    foreach (var medicine in customer.Medicines)
                    {
                        using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                        {
                            cmd.Parameters.Add("@name", SqlDbType.NVarChar, 100).Value = medicine.Name;
                            cmd.Parameters.Add("@price", SqlDbType.Decimal).Value = medicine.Price;
                            cmd.Parameters.Add("@quantity", SqlDbType.Int).Value = medicine.Quantity;
                            cmd.Parameters.Add("@Manufacturer", SqlDbType.NVarChar, 100).Value = medicine.Manufacturer;
                            cmd.Parameters.Add("@ed", SqlDbType.DateTime2).Value = medicine.ExpiredDate;
                            cmd.Parameters.Add("@md", SqlDbType.DateTime2).Value = medicine.ManufacturingDate;
                            cmd.Parameters.Add("@ci", SqlDbType.Int).Value = customerId;
                            //Console.WriteLine();
                            int ret = Convert.ToInt32(cmd.ExecuteScalar());
                            if (ret > 0)
                            {
                                retMessage = "record inserted successfully";
                            }
                                                        //transaction commit
                        }
                    }
                }
            }

            catch (Exception ex)
            {
            }

            return retMessage;
        }
    }
}

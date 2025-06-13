using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PharmaProject.Data;
using PharmaProject.Models;
using PharmaProject.Services.Interfaces;
using System.Linq.Expressions;

namespace PharmaProject.Services
{
    public class MedicineService : IMedicine
    {
        private readonly MedicineDBContext _dbContext;
        public MedicineService(MedicineDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Medicine GetMedicineById(int id)
        {
            //get the context(ado.net connect to server)
           //Medicine medicineRecord = new Medicine();
            var response = _dbContext.Medicines.ToList();
            //understanding the below LINQ and lambda expression with the help of for each code
           /* foreach(var m  in response)
            {
                if(m.Id == id)
                {
                    medicineRecord = m;
                }

            }*/

            //get the data based on ID from the context
           Medicine medicineRecord =response.FirstOrDefault(m => m.Id == id);

            //return the record with given ID
            return medicineRecord;
        }

        //write a insert or post call 
        ID=10
            name="paracetamol"
            price=50
            Quantity=1
            customer="Vineela"
            customerID=10

            
            public List<Medicine> PostMedicineByID(int id)
        {
            _dbContext.Medicines.ToList()= var response;
            Medicine medicineRecord = response.FirstOrDefault(m => m.Id == id);

        }


       public List<Medicine> GetMedicines()
        {
            
            List<Medicine> medicines = new List<Medicine>();
            var response = _dbContext.Medicines.ToList();
            foreach (var data in response)
            {
                Medicine rm = new Medicine();
                //rm.Name = data.Name;
                rm.Price = data.Price;
                rm.ExpiredDate = data.ExpiredDate;
                rm.Id = data.Id;
              //  rm.Customer

                //adding item into list
                medicines.Add(rm);


            }
            //getting data
            return medicines;
        }
    }
}

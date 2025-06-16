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

        public Models.Response CreateMedicine(Medicine NewMedicine)
        {
            var response = new Models.Response();

            // Get the context
           var db =  _dbContext.Medicines;

            // enter the new medicine values as parameters

            db.Add(NewMedicine);    
           int issaved = _dbContext.SaveChanges();

            if(issaved >0)
            {
                response.Message = "new medicine inserted sucessfully";
                response.statusCode = System.Net.HttpStatusCode.Created;
            }
            //pass each value to corresponding database column by mapping

            //save the data to database by a button click


            return response;
            
        }

        public Models.Response DeleteMedicine(int id)
        {
            var response = new Models.Response();
            var mR1 = _dbContext.Medicines.ToList();
            if (mR1 != null)
            {
                Medicine medicineRecord1 = mR1.FirstOrDefault(m => m.Id == id);

                _dbContext.Medicines.Remove(medicineRecord1);
                int isDeleted = _dbContext.SaveChanges();

                if (isDeleted > 0)
                {
                    response.Message = "Medicine Deleted Successfully";
                    response.statusCode = System.Net.HttpStatusCode.OK;
                }
            }
            return response;
        }
    }
}

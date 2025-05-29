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
            throw new NotImplementedException();
        }

        public async Task<ResponseMedicine> GetMedicines()
        {
            ResponseMedicine rm = new ResponseMedicine();
            var response = _dbContext.Medicines.ToList();
            foreach(var data in response)
            {

                rm.Name = data.Name;
                rm.Price = data.Price;
            }
            //getting data
            return rm;
        }
    }
}

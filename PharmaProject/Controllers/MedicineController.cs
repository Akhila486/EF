using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PharmaProject.Data;
using PharmaProject.Models;

namespace PharmaProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineController : ControllerBase
    {
        private readonly MedicineDBContext _dbContext;
        public MedicineController(MedicineDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Medicine>>> getMedicines()
        {
            var data = _dbContext.Medicines;
            var data1 = test();
            return await _dbContext.Medicines.ToListAsync();
           
        }
        
    }
}

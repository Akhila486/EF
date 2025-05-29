using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PharmaProject.Data;
using PharmaProject.Models;
using PharmaProject.Services;
using PharmaProject.Services.Interfaces;

namespace PharmaProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineController : ControllerBase
    {
        private readonly IMedicine _service;
        public MedicineController(IMedicine service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponseMedicine>>> getMedicines()
        {
            var response = await _service.GetMedicines();
            return Ok(response);
        }
        
    }
}

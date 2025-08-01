using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmaADO.DatabaseHelper;
using PharmaADO.Models;
using PharmaADO.Services;
using PharmaADO.Services.Interfaces;

namespace PharmaADO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineController : Controller
    {
        private readonly IMedicine _service;
        public MedicineController(IMedicine service)
        {
            _service = service;
        }

        [HttpGet("getMedicines")]
        public async Task<IActionResult> getMedicines()
        {
            var response = _service.GetMedicines();
            return Ok(response);
        }

        [HttpGet("GetMedicineById")]
        public async Task<IActionResult> AkhilaMethod(int id)
        {
            var response = _service.GetMedicineById(id);
            return Ok(response);

        }

        [HttpPost("CreateMedicines")]
        public async Task<IActionResult> CreateMedicines(Medicine medicine)
        {
            var response = _service.CreateMedicines(medicine);
            return Ok(response);
        }

        [HttpPost("UpdateMedicines")]
        public async Task<IActionResult> UpdateMedicines(Medicine medicine)
        {
            var response = _service.UpdateMedicines(medicine);
            return Ok(response);
        }

        [HttpDeleteAttribute("DeleteMedicineById")]
        public async Task<IActionResult> DeleteMedicineById(int id)
        {
            var response = _service.DeleteMedicineById(id);
            return Ok(response);
        }
    }
}

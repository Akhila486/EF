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
    }
}

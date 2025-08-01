using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmaADO.Models;
using PharmaADO.Services.Interfaces;

namespace PharmaADO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerJsonController : ControllerBase
    {
        private readonly ICustomerJson _service;

        public CustomerJsonController(ICustomerJson service)
        {
            _service = service;
        }

        [HttpPost ("CreateCustomerJson")]
        public async Task<IActionResult> CreateCustomerJson(Customer customer)
        {
            var response = _service.CreateCustomerJson(customer);
            return Ok(response);
        }

    }
}

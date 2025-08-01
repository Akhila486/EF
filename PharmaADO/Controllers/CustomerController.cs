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
    public class CustomerController : ControllerBase
    {

        private readonly ICustomer _service;
        public CustomerController(ICustomer service)
        {
            _service = service;
        }

        [HttpGet("getCustomers")]
        public async Task<IActionResult> getCustomers()
        {
            var response = _service.GetCustomers();
            return Ok(response);
        }

        [HttpGet("GetCustomerById")]
        public async Task<IActionResult> AkhilaMethod(int id)
        {
            var response = _service.GetCustomerById(id);
            return Ok(response);

        }

        [HttpPost("CreateCustomers")]
        public async Task<IActionResult> CreateCustomers(Customer customer)
        {
            var response = _service.CreateCustomers(customer);
            return Ok(response);
        }

        [HttpPost("UpdateCustomers")]
        public async Task<IActionResult> UpdateCustomers(Customer customer)
        {
            var response = _service.UpdateCustomers(customer);
            return Ok(response);
        }
    }
}

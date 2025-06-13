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

        [HttpGet("getMedicines")]
        public async Task<IActionResult> getMedicines()
        {
            var response = _service.GetMedicines();
            return Ok(response);
        }

        [HttpGet("getMedicinesById")]
        public async Task<IActionResult> getMedicinesById(int id)
        {
            var response = _service.GetMedicineById(id);
            return Ok(response);
        }

        [HttpPost("PostMedicinesByID")]
        public async Task<IActionResult> PostmedicinesByID()
        {
            var response = _service.PostMedicinesByID();
            return Ok(response);
        }

    }
}

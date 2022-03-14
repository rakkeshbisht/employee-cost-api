using EmployeeCostAPI.Models;
using EmployeeCostAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeCostAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetEmployees()
        {
           var employees = await _employeeService.GetEmployees();

           return Ok(employees);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(Employee employee)
        {
            var result = await _employeeService.AddEmployee(employee);

            return Ok(result);
        }

    }
}

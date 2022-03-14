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
    public class DependentController : ControllerBase
    {
        public IDependentService _dependentService;

        public DependentController(IDependentService dependentService)
        {
            _dependentService = dependentService;
        }

        [HttpGet]
        public async Task<List<Dependent>> GetDependents()
        {
            return null;
        }

        [HttpPost]
        public async Task<bool> AddDependent(Dependent dependent)
        {
            return false;
        }
    }
}

using EmployeeCostAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeCostAPI.Services
{
    public interface IEmployeeService
    {
        public Task<List<Employee>> GetEmployees();

        public Task<bool> AddEmployee(Employee employee);

    }
}

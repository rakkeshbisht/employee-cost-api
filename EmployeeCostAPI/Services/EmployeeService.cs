using EmployeeCostAPI.DataContext;
using EmployeeCostAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeCostAPI.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly EmployeeDbContext _employeeDbContext;
        private readonly decimal COST_OF_BENEFIT_EMPLOYEE = 1000;
        private readonly decimal EMPLOYEE_DISCOUNT_PERCENTAGE = 10;

        private readonly decimal COST_OF_BENEFIT_DEPENDENT = 500;
        private readonly decimal DEPENDENT_DISCOUNT_PERCENTAGE = 10;

        private readonly decimal NUMBER_OF_PAYCHECKS = 26;

        public EmployeeService(EmployeeDbContext employeeDbContext)
        {
            _employeeDbContext = employeeDbContext;
        }
        public async Task<bool> AddEmployee(Employee employee)
        {
            _employeeDbContext.Add(employee);
            var result = await _employeeDbContext.SaveChangesAsync();

            if (result > 0)
                return true;

            return false;
        }

        public async Task<List<Employee>> GetEmployees()
        {
            var result = await _employeeDbContext.Employees.Include(x => x.Dependents).ToListAsync();

            ComputeInsuranceCost(result);

            return result;
        }

        private void ComputeInsuranceCost(List<Employee> result)
        {
            foreach (var item in result)
            {
                if (item.Name.StartsWith("A"))
                {
                    item.CostOfInsurancePerPayCheque = Math.Round((COST_OF_BENEFIT_EMPLOYEE / NUMBER_OF_PAYCHECKS) * ((100 - EMPLOYEE_DISCOUNT_PERCENTAGE) / 100),2);
                }
                else
                {
                    item.CostOfInsurancePerPayCheque = Math.Round((COST_OF_BENEFIT_EMPLOYEE / NUMBER_OF_PAYCHECKS), 2);
                }

                if (item.Dependents != null && item.Dependents.Any())
                {
                    foreach (var dependent in item.Dependents)
                    {
                        if (dependent.Name.StartsWith("A"))
                        {
                            dependent.CostOfInsurancePerPayCheque = Math.Round((COST_OF_BENEFIT_DEPENDENT / NUMBER_OF_PAYCHECKS) * ((100 - DEPENDENT_DISCOUNT_PERCENTAGE) / 100), 2);
                        }
                        else
                        {
                            dependent.CostOfInsurancePerPayCheque = Math.Round((COST_OF_BENEFIT_DEPENDENT / NUMBER_OF_PAYCHECKS), 2);
                        }
                    }
                }
            }
        }
    }
}

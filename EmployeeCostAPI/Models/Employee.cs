using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EmployeeCostAPI.Models
{
    [Table("Employee")]
    public class Employee
    {
        public Employee()
        {
            Dependents = new HashSet<Dependent>();
        }

        [Key]
        public int EmployeeId { get; set; }
        public string Name { get; set; }

        public string Role { get; set; }

        public decimal Salary { get; set; }

        [NotMapped]
        public decimal CostOfInsurancePerPayCheque { get; set; }

        public virtual ICollection<Dependent> Dependents { get; set; }
    }
}

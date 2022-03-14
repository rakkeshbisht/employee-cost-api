using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeCostAPI.Models
{
    [Table("Dependent")]
    public class Dependent
    {
        [Key]
        public int DependentId { get; set; }

        public string Name { get; set; }

        public string RelationShip { get; set; }

        [NotMapped]
        public decimal CostOfInsurancePerPayCheque { get; set; }

        [Column("DepEmployee_ID")]
        public int EmployeeId { get; set; }
    }
}

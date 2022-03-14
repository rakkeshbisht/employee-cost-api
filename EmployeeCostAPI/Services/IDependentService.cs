using EmployeeCostAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeCostAPI.Services
{
    public interface IDependentService
    {
        public List<Dependent> GetDependents();

        public bool AddDependent(Dependent dependent);
    }
}

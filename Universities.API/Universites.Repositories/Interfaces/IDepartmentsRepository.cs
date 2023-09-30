using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Universites.Repositories.Models;

namespace Universites.Repositories.Interfaces
{
    public interface IDepartmentsRepository
    {
        Task<Department> CreateDepartment(Department departmentToCreate);
        Task<IEnumerable<Department>> ListDepartmentsByUniversity(string UniversityName);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Universites.Repositories.Models;

namespace Universities.Services.Interfaces
{
    public interface IDepartmentsServices
    {
        Task<Department> CreateDepartment(Department departmentToCreate);
        Task<IEnumerable<Department>> ListDepartmentsByUniversity(string UniversityName);
    }
}

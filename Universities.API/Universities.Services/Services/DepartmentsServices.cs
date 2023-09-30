using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Universites.Repositories.Interfaces;
using Universites.Repositories.Models;
using Universities.Services.Interfaces;

namespace Universities.Services.Services
{
    public class DepartmentsServices : IDepartmentsServices
    {
        private readonly IDepartmentsRepository _repository;

        public DepartmentsServices(IDepartmentsRepository repository)
        {
            _repository = repository;
        }

        public Task<Department> CreateDepartment(Department departmentToCreate)
        {
            return _repository.CreateDepartment(departmentToCreate);
        }

        public Task<IEnumerable<Department>> ListDepartmentsByUniversity(string UniversityName)
        {
            return _repository.ListDepartmentsByUniversity(UniversityName);
        }
    }
}

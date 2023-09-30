using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Universites.Repositories.Interfaces;
using Universites.Repositories.Models;

namespace Universites.Repositories.Repositories
{
    public class DepartmentRepository : IDepartmentsRepository
    {
        private readonly IUniversitiesContext _context;
        public DepartmentRepository(IUniversitiesContext universitiesContext)
        {
            _context = universitiesContext;
        }
        public async Task<IEnumerable<Department>> ListDepartmentsByUniversity(string UniversityName)
        {
            University university = _context.Universities.Where(u => u.Name == UniversityName).FirstOrDefault();
            if (university == null) { return null; }
            return await _context.Departments.Where(x => x.UniversityID == university.Id).ToListAsync();
        }
        public async Task<Department> CreateDepartment(Department departmentToCreate)
        {

            var exists = _context.Departments.Any(b =>
                    b.Name == departmentToCreate.Name && 
                    b.UniversityID == departmentToCreate.UniversityID);

            if (exists)
            {
                return null;
            }

            _context.Departments.Add(departmentToCreate);
            await _context.SaveChangesAsync();

            return departmentToCreate;

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Universites.Repositories.Models;

namespace Universites.Repositories.Interfaces
{
    public interface IUniversitiesRepository
    {
        Task<University> CreateUniversity(University universityToCreate);
        Task<IEnumerable<University>> ListUniversities();

        Task<IEnumerable<Department>> ListDepartamentsForUni(Guid Id);
        Task<IEnumerable<Course>> ListCoursesForDep(Guid Id);

    }
}

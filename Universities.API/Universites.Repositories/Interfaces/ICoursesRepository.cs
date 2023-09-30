using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Universites.Repositories.Models;

namespace Universites.Repositories.Interfaces
{
    public interface ICoursesRepository
    {
        Task<Course> CreateCourse(Course courseToCreate);
        Task<IEnumerable<Course>> ListCoursesByDepartment(string DepartmentName, string UniversityName);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Universites.Repositories.Models;

namespace Universities.Services.Interfaces
{
    public interface ICoursesServices
    {
        Task<Course> CreateCourse(Course courseToCreate);
        Task<IEnumerable<Course>> ListCoursesByDepartment(string DepartmentName, string UniversityName);
    }
}

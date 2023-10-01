using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Universites.Repositories.Models;
using Universities.Services.Models;

namespace Universities.Services.Interfaces
{
    public interface ICoursesServices
    {
        Task<Course> CreateCourse(Course courseToCreate);
        Task<IEnumerable<CourseDTO>> ListCoursesByDepartment(string DepartmentName, string UniversityName);
    }
}

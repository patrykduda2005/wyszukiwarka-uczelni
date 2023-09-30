using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Universites.Repositories.Interfaces;
using Universites.Repositories.Models;
using Universites.Repositories.Repositories;
using Universities.Services.Interfaces;

namespace Universities.Services.Services
{
    public class CoursesServices : ICoursesServices
    {
        private readonly ICoursesRepository _repository;

        public CoursesServices(ICoursesRepository repository)
        {
            _repository = repository;
        }
        public Task<Course> CreateCourse(Course courseToCreate)
        {
            return _repository.CreateCourse(courseToCreate);
        }

        public Task<IEnumerable<Course>> ListCoursesByDepartment(string DepartmentName, string UniversityName)
        {
            return _repository.ListCoursesByDepartment(DepartmentName, UniversityName);
        }
    }
}

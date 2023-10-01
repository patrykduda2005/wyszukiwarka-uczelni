using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Universites.Repositories.Interfaces;
using Universites.Repositories.Models;
using Universites.Repositories.Repositories;
using Universities.Services.Interfaces;
using Universities.Services.Models;

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

        public async Task<IEnumerable<CourseDTO>> ListCoursesByDepartment(string DepartmentName, string UniversityName)
        {
            IEnumerable<Course> courses = await _repository.ListCoursesByDepartment(DepartmentName, UniversityName);
            List<CourseDTO> coursesDTOs = new List<CourseDTO>();
            foreach (var course in courses)
            {
                coursesDTOs.Add(await toDTO(course));
            }
            return coursesDTOs;
        }

        private async Task<CourseDTO> toDTO(Course course)
        {
            CourseDTO courseDTO = new CourseDTO();
            courseDTO.Description = course.Description;
            courseDTO.ExpirenceAfter = course.ExpirenceAfter;
            courseDTO.Level = course.Level;
            courseDTO.Name = course.Name;
            courseDTO.Id = course.Id;
            courseDTO.DepartmentID = course.DepartmentID;
            return courseDTO;
        }
    }
}

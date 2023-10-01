using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Universites.Repositories.Interfaces;
using Universites.Repositories.Models;
using Universities.Services.Interfaces;
using Universities.Services.Models;

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

        public async Task<IEnumerable<DepartmentDTO>> ListDepartmentsByUniversity(string UniversityName)
        {
            IEnumerable<Department> departments = await _repository.ListDepartmentsByUniversity(UniversityName);
            List<DepartmentDTO> departmentsDTOs = new List<DepartmentDTO>();
            foreach (var department in departments)
            {
                departmentsDTOs.Add(await toDTO(department));
            }
            return departmentsDTOs;
        }
        private async Task<DepartmentDTO> toDTO(Department department)
        {
            DepartmentDTO departmentDTO = new DepartmentDTO();
            departmentDTO.Description = department.Description;
            departmentDTO.BossOfDepartament = department.BossOfDepartament;
            IEnumerable<Course> courses = await _repository.ListCoursesForDep(department.Id);
            List<CourseDTO> coursesD = new List<CourseDTO>();
            foreach (var course in courses)
            {
                coursesD.Add(await toDTO(course));
            }
            departmentDTO.Courses = coursesD;
            departmentDTO.Id = department.Id;
            departmentDTO.UniversityID = department.UniversityID;
            departmentDTO.Name = department.Name;
            return departmentDTO;
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

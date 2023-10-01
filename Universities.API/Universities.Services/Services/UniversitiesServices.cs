using Microsoft.EntityFrameworkCore;
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
    public class UniversitiesServices : IUniversitiesServices
    {
        private readonly IUniversitiesRepository _repository;

        public UniversitiesServices(IUniversitiesRepository repository)
        {
            _repository = repository;
        }
        public Task<University> CreateUniversity(University universityToCreate)
        {
            return _repository.CreateUniversity(universityToCreate);
        }

        public async Task<IEnumerable<UniversityDTO>> ListUniversities()
        {
            IEnumerable<University> universities = await _repository.ListUniversities();
            List<UniversityDTO> universityDTOs = new List<UniversityDTO>();
            foreach (var univer in universities)
            {
                universityDTOs.Add(await toDTO(univer));
            }
            return universityDTOs;
        }

        private async Task<UniversityDTO> toDTO(University university) { 
            UniversityDTO universityDTO = new UniversityDTO();
            universityDTO.City = university.City;
            universityDTO.Ranking = university.Ranking;
            universityDTO.DateOfCreation = university.DateOfCreation;
            universityDTO.Id = university.Id;
            IEnumerable<Department> departments = await _repository.ListDepartamentsForUni(universityDTO.Id);
            List<DepartmentDTO> departmentDTOs = new List<DepartmentDTO>();
            foreach (var department in departments)
            {
                departmentDTOs.Add(await toDTO(department));
            }
            universityDTO.Departments = departmentDTOs;
            universityDTO.Students = university.Students;
            universityDTO.Name = university.Name;
            universityDTO.RectorName = university.RectorName;
            universityDTO.Type = university.Type;
            return universityDTO;
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

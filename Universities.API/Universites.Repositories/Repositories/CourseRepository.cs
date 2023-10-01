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
    public class CourseRepository : ICoursesRepository
    {
        private readonly IUniversitiesContext _context;
        public CourseRepository(IUniversitiesContext universitiesContext)
        {
            _context = universitiesContext;
        }
        public async Task<IEnumerable<Course>> ListCoursesByDepartment(string DepartmentName,string UniversityName)//Guid ID)
        {
            University university = _context.Universities.Where(u => u.Name == UniversityName).FirstOrDefault();
            if(university == null) { return null; }
            Department department = _context.Departments.Where(d => d.Name == DepartmentName && d.UniversityID == university.Id).FirstOrDefault();
            if(department == null) { return null; }
            return await _context.Courses.Where(x => x.DepartmentID == department.Id).ToListAsync();
        }
        public async Task<Course> CreateCourse(Course courseToCreate)
        {

            var exists = _context.Departments.Any(b =>
                    b.Name == courseToCreate.Name &&
                    b.UniversityID == courseToCreate.DepartmentID);

            if (exists)
            {
                return null;
            }

            _context.Courses.Add(courseToCreate);
            await _context.SaveChangesAsync();

            return courseToCreate;

        }
    }
}

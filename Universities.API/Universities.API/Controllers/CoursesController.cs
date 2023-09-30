﻿using Microsoft.AspNetCore.Mvc;
using Universites.Repositories.Models;
using Universities.Services.Interfaces;

namespace Universities.API.Controllers
{
    [Route("/Courses")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICoursesServices _service;

        public CoursesController(ICoursesServices service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetDepartmentsByUniversity(string dName,string uName)
        {
            if (await _service.ListCoursesByDepartment(dName,uName) == null)
            {
                return NotFound();
            }

            return Ok(await _service.ListCoursesByDepartment(dName,uName));
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<Course>>> PostDepartments(string Name, string Description, string experienceAfter,string level, Guid departmentID)
        {
            Course course = new Course();
            course.Name = Name;
            course.Description = Description;
            course.ExpirenceAfter = experienceAfter;
            course.Level = level;
            course.DepartmentID = departmentID;
            course.Id = Guid.NewGuid();
            if (await _service.CreateCourse(course) == null)
            {
                return NotFound();
            }

            return Ok(await _service.CreateCourse(course));
        }
    }
}

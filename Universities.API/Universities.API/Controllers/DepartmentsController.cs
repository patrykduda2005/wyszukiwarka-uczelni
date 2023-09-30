using Microsoft.AspNetCore.Mvc;
using Universites.Repositories.Models;
using Universities.Services.Interfaces;

namespace Universities.API.Controllers
{
    [Route("/Departments")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentsServices _service;

        public DepartmentsController(IDepartmentsServices service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Department>>> GetDepartmentsByUniversity(string name)
        {
            if (await _service.ListDepartmentsByUniversity(name) == null)
            {
                return NotFound();
            }

            return Ok(await _service.ListDepartmentsByUniversity(name));
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<Department>>> PostDepartments(string Name, string Description, string BossName, Guid universityID)
        {
            Department department = new Department();
            department.Name = Name;
            department.Description = Description;
            department.BossOfDepartament = BossName;
            department.UniversityID = universityID;
            department.Id = Guid.NewGuid();
            if (await _service.CreateDepartment(department) == null)
            {
                return NotFound();
            }

            return Ok(await _service.CreateDepartment(department));
        }
    }
}

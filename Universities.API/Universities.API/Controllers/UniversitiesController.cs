using Microsoft.AspNetCore.Mvc;
using Universites.Repositories.Models;
using Universities.Services.Interfaces;

namespace Universities.API.Controllers
{
    [Route("/Universities")]
    [ApiController]
    public class UniversitiesController : ControllerBase
    {
        private readonly IUniversitiesServices _service;

        public UniversitiesController(IUniversitiesServices service)
        {
            _service = service;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<University>>> GetUniversitets()
        {
            if (await _service.ListUniversities() == null)
            {
                return NotFound();
            }

            return Ok(await _service.ListUniversities());
        }
        
        [HttpPost]
        public async Task<ActionResult<IEnumerable<University>>> PostUniversitets(string Name,string City,string RectorName,DateTime dateOfCreation,string Type,int Ranking,int Students)
        {
            University university = new University();
            university.Name = Name;
            university.City = City;
            university.Students = Students;
            university.Ranking = Ranking;
            university.RectorName = RectorName;
            university.Type = Type;
            university.DateOfCreation = dateOfCreation;
            university.Id = Guid.NewGuid();
            if (await _service.CreateUniversity(university) == null)
            {
                return NotFound();
            }

            return Ok(await _service.CreateUniversity(university));
        }
    }
}

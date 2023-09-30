using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Universites.Repositories.Interfaces;
using Universites.Repositories.Models;
using Universities.Services.Interfaces;

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

        public async Task<IEnumerable<University>> ListUniversities()
        {
            return await _repository.ListUniversities();
        }
    }
}

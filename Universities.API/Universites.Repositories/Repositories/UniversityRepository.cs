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
    public class UniversityRepository : IUniversitiesRepository
    {
        private readonly IUniversitiesContext _context;
        public UniversityRepository(IUniversitiesContext universitiesContext)
        {
            _context = universitiesContext;
        }

        public async Task<IEnumerable<University>> ListUniversities()
        {

            return await _context.Universities.ToListAsync();
        }
        public async Task<University> CreateUniversity(University universityToCreate)
        {

            var exists = _context.Universities.Any(b =>
                    b.Name == universityToCreate.Name);

            if (exists)
            {
                return null;
            }

            _context.Universities.Add(universityToCreate);
            await _context.SaveChangesAsync();

            return universityToCreate;

        }
    }
}

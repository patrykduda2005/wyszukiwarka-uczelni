using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Universites.Repositories.Models;

namespace Universities.Services.Interfaces
{
    public interface IUniversitiesServices
    {
        Task<University> CreateUniversity(University universityToCreate);
        Task<IEnumerable<University>> ListUniversities();
    }
}

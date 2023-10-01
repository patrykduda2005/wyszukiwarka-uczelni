using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Universites.Repositories.Models;

namespace Universities.Services.Models
{
    public class UniversityDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string RectorName { get; set; }
        public DateTime DateOfCreation { get; set; }
        public string Type { get; set; }
        public int Ranking { get; set; }
        public int Students { get; set; }

        public List<DepartmentDTO> Departments { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Universites.Repositories.Models;

namespace Universities.Services.Models
{
    public class DepartmentDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string BossOfDepartament { get; set; }
        public List<CourseDTO> Courses { get; set; }
        public Guid UniversityID { get; set; }
    }
}

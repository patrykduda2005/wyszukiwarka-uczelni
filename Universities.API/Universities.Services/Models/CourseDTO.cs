using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Universites.Repositories.Models;

namespace Universities.Services.Models
{
    public class CourseDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ExpirenceAfter { get; set; }
        public string Level { get; set; }

        public Guid DepartmentID { get; set; }

    }
}

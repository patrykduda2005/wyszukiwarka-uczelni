using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Universites.Repositories.Models
{
    public class Department
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string BossOfDepartament { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        public Guid UniversityID { get; set; }
        public virtual University University { get; set; }
    }
}

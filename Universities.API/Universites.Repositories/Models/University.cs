using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universites.Repositories.Models
{
    public class University
    {
        //Date
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string RectorName { get; set; }
        public DateTime DateOfCreation { get; set; }
        public string Type { get; set; }
        public int Ranking { get; set; }
        public int Students { get; set; }

        public virtual ICollection<Department> Departments { get; set; }

        //future - train/bus connections

        public University()
        {
            Id = Guid.NewGuid();
            Name = string.Empty;
            City = string.Empty;

            RectorName = string.Empty;
            DateOfCreation = DateTime.Now;
            Type = string.Empty;
            Ranking = 0;
            Students = 0;
        }
    }
}

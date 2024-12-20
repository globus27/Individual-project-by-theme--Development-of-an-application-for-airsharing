using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Airfield
    {
        public Airfield()
        {
            Employees = new HashSet<Employee>();
        }

        public int IdAirfield { get; set; }
        public string Name { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string? City { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}

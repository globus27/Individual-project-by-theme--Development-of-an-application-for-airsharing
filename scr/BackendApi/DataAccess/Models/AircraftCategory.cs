using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class AircraftCategory
    {
        public AircraftCategory()
        {
            Aircraft = new HashSet<Aircraft>();
        }

        public int IdAircraftCategory { get; set; }
        public string AircraftType { get; set; } = null!;

        public virtual ICollection<Aircraft> Aircraft { get; set; }
    }
}

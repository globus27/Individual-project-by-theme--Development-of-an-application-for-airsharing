using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class ServiceInfo
    {
        public int IdServiceInfo { get; set; }
        public DateTime TimeOfViolation { get; set; }
        public string Decription { get; set; } = null!;
        public int IdAircraft { get; set; }

        public virtual Aircraft IdAircraftNavigation { get; set; } = null!;
    }
}

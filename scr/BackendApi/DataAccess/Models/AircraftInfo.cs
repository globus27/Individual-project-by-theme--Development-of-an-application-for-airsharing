using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class AircraftInfo
    {
        public int IdAircraftInfo { get; set; }
        public int PassengerCapacity { get; set; }
        public decimal MaxWeight { get; set; }
        public string EngineType { get; set; } = null!;
        public int EnginesCount { get; set; }
        public int IdAircraft { get; set; }

        public virtual Aircraft IdAircraftNavigation { get; set; } = null!;
    }
}

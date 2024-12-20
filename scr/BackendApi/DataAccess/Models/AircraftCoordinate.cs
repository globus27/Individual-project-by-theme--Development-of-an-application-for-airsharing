using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class AircraftCoordinate
    {
        public int IdAircraftCoordinates { get; set; }
        public decimal Altitude { get; set; }
        public decimal PressureOnBoard { get; set; }
        public decimal Speed { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public int IdAircraft { get; set; }

        public virtual Aircraft IdAircraftNavigation { get; set; } = null!;
    }
}

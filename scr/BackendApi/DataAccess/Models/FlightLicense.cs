using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class FlightLicense
    {
        public FlightLicense()
        {
            Rentals = new HashSet<Rental>();
        }

        public string Surname { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string NumberFlightLicense { get; set; } = null!;
        public int IdFlightLicense { get; set; }
        public DateTime BirthDay { get; set; }
        public DateTime DateofIssue { get; set; }
        public DateTime DateofExpiry { get; set; }
        public string LicenseCategory { get; set; } = null!;
        public string? CityofResidence { get; set; }
        public string CountryofResidence { get; set; } = null!;
        public int IdUser { get; set; }

        public virtual User IdUserNavigation { get; set; } = null!;
        public virtual ICollection<Rental> Rentals { get; set; }
    }
}

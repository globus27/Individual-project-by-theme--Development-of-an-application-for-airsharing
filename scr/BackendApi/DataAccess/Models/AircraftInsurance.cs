using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class AircraftInsurance
    {
        public string InsuranceNumber { get; set; } = null!;
        public string SerialNumber { get; set; } = null!;
        public string InsuranceCompany { get; set; } = null!;
        public DateTime DateofIssue { get; set; }
        public DateTime DateofExpiry { get; set; }
        public decimal CoverageAmount { get; set; }
        public string Status { get; set; } = null!;
        public int IdAircraft { get; set; }
        public int IdLeasingCompany { get; set; }
        public int IdAircraftInsurance { get; set; }

        public virtual Aircraft IdAircraftNavigation { get; set; } = null!;
        public virtual LeasingCompany IdLeasingCompanyNavigation { get; set; } = null!;
    }
}

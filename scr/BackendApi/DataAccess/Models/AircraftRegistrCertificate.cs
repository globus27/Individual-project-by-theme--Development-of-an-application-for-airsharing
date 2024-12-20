using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class AircraftRegistrCertificate
    {
        public string SerialNumber { get; set; } = null!;
        public string CertifacteNumber { get; set; } = null!;
        public DateTime DateofIssue { get; set; }
        public DateTime DateofExpiry { get; set; }
        public int IdAircaft { get; set; }
        public int Attribute1 { get; set; }
        public int IdAircraftRegistrCertificate { get; set; }

        public virtual LeasingCompany Attribute1Navigation { get; set; } = null!;
        public virtual Aircraft IdAircaftNavigation { get; set; } = null!;
    }
}

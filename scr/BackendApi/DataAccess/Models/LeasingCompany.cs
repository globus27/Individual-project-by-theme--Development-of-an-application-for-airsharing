using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class LeasingCompany
    {
        public LeasingCompany()
        {
            AircraftInsurances = new HashSet<AircraftInsurance>();
            AircraftRegistrCertificates = new HashSet<AircraftRegistrCertificate>();
            LeasingInfos = new HashSet<LeasingInfo>();
        }

        public string Ogrn { get; set; } = null!;
        public string CompanyName { get; set; } = null!;
        public string ContactEmail { get; set; } = null!;
        public int IdLeasingCompany { get; set; }

        public virtual ICollection<AircraftInsurance> AircraftInsurances { get; set; }
        public virtual ICollection<AircraftRegistrCertificate> AircraftRegistrCertificates { get; set; }
        public virtual ICollection<LeasingInfo> LeasingInfos { get; set; }
    }
}

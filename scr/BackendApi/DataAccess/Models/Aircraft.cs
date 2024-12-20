using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Aircraft
    {
        public Aircraft()
        {
            AircraftCoordinates = new HashSet<AircraftCoordinate>();
            AircraftInfos = new HashSet<AircraftInfo>();
            AircraftInsurances = new HashSet<AircraftInsurance>();
            AircraftRegistrCertificates = new HashSet<AircraftRegistrCertificate>();
            LeasingInfos = new HashSet<LeasingInfo>();
            Rentals = new HashSet<Rental>();
            ServiceInfos = new HashSet<ServiceInfo>();
        }

        public int IdAircraft { get; set; }
        public string SerialNumber { get; set; } = null!;
        public string ModelName { get; set; } = null!;
        public string ManufactureCountry { get; set; } = null!;
        public string? Status { get; set; }
        public int IdAircraftCategory { get; set; }

        public virtual AircraftCategory IdAircraftCategoryNavigation { get; set; } = null!;
        public virtual ICollection<AircraftCoordinate> AircraftCoordinates { get; set; }
        public virtual ICollection<AircraftInfo> AircraftInfos { get; set; }
        public virtual ICollection<AircraftInsurance> AircraftInsurances { get; set; }
        public virtual ICollection<AircraftRegistrCertificate> AircraftRegistrCertificates { get; set; }
        public virtual ICollection<LeasingInfo> LeasingInfos { get; set; }
        public virtual ICollection<Rental> Rentals { get; set; }
        public virtual ICollection<ServiceInfo> ServiceInfos { get; set; }
    }
}

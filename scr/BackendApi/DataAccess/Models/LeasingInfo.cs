using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class LeasingInfo
    {
        public int IdLeasingInfo { get; set; }
        public string SerialNumber { get; set; } = null!;
        public DateTime LeaseStartDate { get; set; }
        public DateTime LeaseEndDate { get; set; }
        public decimal MonthlyPayment { get; set; }
        public int IdAircraft { get; set; }
        public int IdLeasingCompany { get; set; }

        public virtual Aircraft IdAircraftNavigation { get; set; } = null!;
        public virtual LeasingCompany IdLeasingCompanyNavigation { get; set; } = null!;
    }
}

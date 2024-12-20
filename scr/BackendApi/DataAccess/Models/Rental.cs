using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Rental
    {
        public Rental()
        {
            MoneyTransactions = new HashSet<MoneyTransaction>();
        }

        public int IdRental { get; set; }
        public DateTime StartDate { get; set; }
        public TimeSpan RentalTime { get; set; }
        public int CountOfHours { get; set; }
        public decimal TotalPrice { get; set; }
        public string RentalStatus { get; set; } = null!;
        public int IdUser { get; set; }
        public int IdFlightLicense { get; set; }
        public int IdAircraft { get; set; }

        public virtual Aircraft IdAircraftNavigation { get; set; } = null!;
        public virtual FlightLicense IdFlightLicenseNavigation { get; set; } = null!;
        public virtual User IdUserNavigation { get; set; } = null!;
        public virtual ICollection<MoneyTransaction> MoneyTransactions { get; set; }
    }
}

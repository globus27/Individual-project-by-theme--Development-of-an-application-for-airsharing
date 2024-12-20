using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class User
    {
        public User()
        {
            Admins = new HashSet<Admin>();
            FlightLicenses = new HashSet<FlightLicense>();
            MoneyTransactions = new HashSet<MoneyTransaction>();
            PaymentInfos = new HashSet<PaymentInfo>();
            Rentals = new HashSet<Rental>();
        }

        public int IdUser { get; set; }
        public string Login { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int IdPassport { get; set; }

        public virtual Passport IdPassportNavigation { get; set; } = null!;
        public virtual ICollection<Admin> Admins { get; set; }
        public virtual ICollection<FlightLicense> FlightLicenses { get; set; }
        public virtual ICollection<MoneyTransaction> MoneyTransactions { get; set; }
        public virtual ICollection<PaymentInfo> PaymentInfos { get; set; }
        public virtual ICollection<Rental> Rentals { get; set; }
    }
}

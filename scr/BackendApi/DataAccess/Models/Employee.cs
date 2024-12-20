using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Employee
    {
        public int IdEmployee { get; set; }
        public string FullName { get; set; } = null!;
        public string PassportNumber { get; set; } = null!;
        public string PostName { get; set; } = null!;
        public string MailAdress { get; set; } = null!;
        public decimal SalaryRate { get; set; }
        public int IdAirfield { get; set; }
        public int Number { get; set; }

        public virtual Airfield IdAirfieldNavigation { get; set; } = null!;
        public virtual Passport NumberNavigation { get; set; } = null!;
    }
}

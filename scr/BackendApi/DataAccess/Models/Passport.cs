using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Passport
    {
        public Passport()
        {
            Employees = new HashSet<Employee>();
            Users = new HashSet<User>();
        }

        public int IdPassport { get; set; }
        public string Surname { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? MiddleName { get; set; }
        public DateTime DateofIssue { get; set; }
        public string CodeDepartament { get; set; } = null!;
        public string Sex { get; set; } = null!;
        public DateTime BirthDay { get; set; }
        public string PlaceBorn { get; set; } = null!;
        public string PlaceIssue { get; set; } = null!;
        public string Number { get; set; } = null!;

        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Admin
    {
        public int Idadmin { get; set; }
        public int IdUser { get; set; }

        public virtual User IdUserNavigation { get; set; } = null!;
    }
}

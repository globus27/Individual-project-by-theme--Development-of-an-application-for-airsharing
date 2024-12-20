using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class EmployeeServiceInfo
    {
        public int IdEmployee { get; set; }
        public int IdServiceInfo { get; set; }

        public virtual Employee IdEmployeeNavigation { get; set; } = null!;
        public virtual ServiceInfo IdServiceInfoNavigation { get; set; } = null!;
    }
}

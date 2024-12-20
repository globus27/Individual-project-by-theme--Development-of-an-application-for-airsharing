using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class ServiceInfoAirfield
    {
        public int IdServiceInfo { get; set; }
        public int IdAirfield { get; set; }

        public virtual Airfield IdAirfieldNavigation { get; set; } = null!;
        public virtual ServiceInfo IdServiceInfoNavigation { get; set; } = null!;
    }
}

using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class PaymentInfo
    {
        public int IdPaymetnInfo { get; set; }
        public string CardNumber { get; set; } = null!;
        public string Cvc { get; set; } = null!;
        public int IdUser { get; set; }

        public virtual User IdUserNavigation { get; set; } = null!;
    }
}

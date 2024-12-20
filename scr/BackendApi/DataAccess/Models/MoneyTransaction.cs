using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class MoneyTransaction
    {
        public int IdMoneyTransaction { get; set; }
        public string TransactionType { get; set; } = null!;
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public int IdUserSender { get; set; }
        public int IdRental { get; set; }

        public virtual Rental IdRentalNavigation { get; set; } = null!;
        public virtual User IdUserSenderNavigation { get; set; } = null!;
    }
}

using InternetBanking.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetBanking.Core.Domain.Entities
{
    public class Loan : AuditableBaseEntity
    {
        public decimal Amount { get; set; }
        public decimal Payed { get; set; }
        public int AccountId { get; set; } // FK de la cuenta 
        public Account Account { get; set; }
    }
}

using InternetBanking.Core.Domain.Common;

namespace InternetBanking.Core.Domain.Entities
{
    public class Transaction : AuditableBaseEntity
    {

        public string Type { get; set; }
        public decimal Amount { get; set; }
        public int? OriginAccountId { get; set; }
        public int? DestinationAccountId { get; set; }
        public Account OriginAccount { get; set; }
        public Account DestinationAccount { get; set; }

    }
}

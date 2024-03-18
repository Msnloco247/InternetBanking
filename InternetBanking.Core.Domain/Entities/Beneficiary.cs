
using InternetBanking.Core.Domain.Common;

namespace InternetBanking.Core.Domain.Entities
{
    public class Beneficiary : AuditableBaseEntity
    {

        public string BeneficiaryName { get; set; }

        public string AccountNumber { get; set; }

        public string UserId { get; set; }
    }
}

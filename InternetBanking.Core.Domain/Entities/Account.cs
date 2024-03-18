using InternetBanking.Core.Application.Enums;
using System.Transactions;


namespace InternetBanking.Core.Domain.Entities
{
    public class Account
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public decimal Amount { get; set; }
        public string UserId { get; set; }
        public AccountType Type { get; set; }
        public ICollection<Loan> Loans { get; set; }

        public ICollection<Transaction> DetinationTransactions { get; set; } // Transacciones donde esta cuenta es la cuenta origen

        public ICollection<Transaction> OriginTransactions { get; set; } // Transacciones donde esta cuenta es la cuenta origen

    }
}

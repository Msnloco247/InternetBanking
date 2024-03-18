using Microsoft.EntityFrameworkCore;
using InternetBanking.Core.Application.Interfaces.Repositories;
using InternetBanking.Core.Domain.Entities;
using InternetBanking.Infrastructure.Persistence.Contexts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InternetBanking.Infrastructure.Persistence.Repository
{
    public class TransactionRepository : GenericRepository<Transaction>, ITransactionRepository
    {
        private readonly ApplicationContext _dbContext;

        public TransactionRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }


    }
}

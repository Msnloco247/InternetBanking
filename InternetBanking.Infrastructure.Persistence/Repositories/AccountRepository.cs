using Microsoft.EntityFrameworkCore;
using InternetBanking.Core.Application.Interfaces.Repositories;
using InternetBanking.Core.Domain.Entities;
using InternetBanking.Infrastructure.Persistence.Contexts;

namespace InternetBanking.Infrastructure.Persistence.Repository
{
    public class AccountRepository : GenericRepository<Account>, IAccountRepository
    {
        private readonly ApplicationContext _dbContext;

        public AccountRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }


    }
}

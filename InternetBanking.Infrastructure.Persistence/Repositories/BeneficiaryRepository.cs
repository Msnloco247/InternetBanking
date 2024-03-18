using Microsoft.EntityFrameworkCore;
using InternetBanking.Core.Application.Interfaces.Repositories;
using InternetBanking.Core.Domain.Entities;
using InternetBanking.Infrastructure.Persistence.Contexts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InternetBanking.Infrastructure.Persistence.Repository
{
    public class BeneficiaryRepository : GenericRepository<Beneficiary>, IBeneficiaryRepository
    {
        private readonly ApplicationContext _dbContext;

        public BeneficiaryRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }


    }
}

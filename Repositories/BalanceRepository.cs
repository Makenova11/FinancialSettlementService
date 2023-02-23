using FinancialSettlementService.Interfaces;
using FinancialSettlementService.Models;

namespace FinancialSettlementService.Repositories
{
    /// <inheritdoc cref="IBalanceRepository"/>
    public class BalanceRepository : IBalanceRepository
    {
        private readonly BankDbContext _dbContext;
        public BalanceRepository(BankDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <inheritdoc/>
        public Task<decimal?> CheckBalanceAsync(Guid clientId)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task DepositIntoAsync(Guid clientId, decimal amount)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task WithDrawFromAsync(Guid clientId, decimal amount)
        {
            throw new NotImplementedException();
        }
    }
}

namespace FinancialSettlementService.Repositories
{
    using FinancialSettlementService.Helpers;
    using FinancialSettlementService.Interfaces;
    using FinancialSettlementService.Models;
    using Microsoft.EntityFrameworkCore;
    using Npgsql;
    using Z.EntityFramework.Plus;

    /// <inheritdoc cref="IBalanceRepository"/>
    public class BalanceRepository : IBalanceRepository
    {
        /// <inheritdoc cref="BankDbContext"/>
        private readonly BankDbContext _dbContext;
        public BalanceRepository(BankDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <inheritdoc/>
        public async Task<decimal?> CheckBalanceAsync(Guid clientId, CancellationToken cancellationToken)
        {
           return await _dbContext.BalanceAccounts
                .Where(client => client.ClientId == clientId)
                .Select(client => (decimal?)client.Balance).SingleOrDefaultAsync(cancellationToken);
        }

        /// <inheritdoc/>
        public async Task DepositIntoAsync(Guid clientId, decimal amount, CancellationToken cancellationToken)
        {
            using var transaction = await _dbContext.Database
                .BeginTransactionAsync(isolationLevel: System.Data.IsolationLevel.Serializable, cancellationToken);
            try
            {
                await _dbContext.BalanceAccounts
                .Where(x => x.ClientId == clientId)
                .UpdateAsync(x => new BalanceAccount { Balance = x.Balance + amount }, cancellationToken);

                await transaction.CommitAsync( cancellationToken);
            }
            catch (Exception)
            {
                await transaction.RollbackAsync(cancellationToken);
                throw new Exception("Не удалось пополнить баланс.");
            }
        }

        /// <inheritdoc/>
        public async Task WithdrawFromAsync(Guid clientId, decimal amount, CancellationToken cancellationToken)
        {
            using var transaction = await _dbContext.Database
                .BeginTransactionAsync(isolationLevel: System.Data.IsolationLevel.Serializable, cancellationToken);
            try
            {
                var affectedObjects = await _dbContext.BalanceAccounts
                .Where(x => x.ClientId == clientId)
                .UpdateAsync(x => new BalanceAccount { Balance = x.Balance - amount }, cancellationToken);

                await transaction.CommitAsync(cancellationToken);

            }
            catch (PostgresException ex) when (ex.ConstraintName == ValidationTypeConstants.NoNegativeBalanceConstraint)
            {
                await transaction.RollbackAsync(cancellationToken);
                throw new Exception("Ошибка! Недостаточно средств на счёте.");
            }
            catch (Exception)
            {
                await transaction.RollbackAsync(cancellationToken);
                throw new Exception("Не удалось снять деньги со счёта.");
            }
        }
    }
}

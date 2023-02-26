namespace FinancialSettlementService.Repositories
{
    using FinancialSettlementService.Interfaces;
    using FinancialSettlementService.Models;
    using Microsoft.EntityFrameworkCore;

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
                .BeginTransactionAsync(cancellationToken);
            try
            {
                await _dbContext.Database.ExecuteSqlRawAsync
                                (GetUpdateBalanceQuery(clientId, amount, '+'), cancellationToken);

                await transaction.CommitAsync(cancellationToken);
            }
            catch { transaction.Rollback(); }               
        }

        /// <inheritdoc/>
        public async Task WithdrawFromAsync(Guid clientId, decimal amount, CancellationToken cancellationToken)
        {
            using var transaction = await _dbContext.Database
                .BeginTransactionAsync(cancellationToken);
            try
            {
                await _dbContext.Database.ExecuteSqlRawAsync
                                (GetUpdateBalanceQuery(clientId, amount, '-'), cancellationToken);

                await transaction.CommitAsync(cancellationToken);
            }
            catch { transaction.Rollback(); }        
        }

        /// <summary>
        /// Формирует sql запрос для изменения баланса.
        /// </summary>
        /// <param name="clientId"> Идентификатор клиента. </param>
        /// <param name="amount"> Сумма, на которую изменяется баланс. </param>
        /// <param name="operation"> Арифметический символ операции. </param>
        /// <returns> Запрос на изменение баланса. </returns>
        private static string GetUpdateBalanceQuery(Guid clientId, decimal amount, char operation) => 
                "UPDATE \"BalanceAccounts\"" +
                $" SET \"Balance\" = \"Balance\" {operation} {amount} WHERE \"ClientId\" = '{clientId}';";
    }
}

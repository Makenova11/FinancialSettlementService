namespace FinancialSettlementService.Interfaces
{
    /// <summary>
    /// Репозиторий работы с балансом клиента.
    /// </summary>
    public interface IBalanceRepository
    {
        /// <summary>
        /// Проверить баланс счёта.
        /// </summary>
        /// <param name="clientId"> Идентификатор клиента. </param>
        /// <param name="cancellationToken"> Структура отмены операций между потоками. </param>
        /// <returns> Баланс счёта. </returns>
        Task<decimal?> CheckBalanceAsync(Guid clientId, CancellationToken cancellationToken);

        /// <summary>
        /// Пополнить баланс счёта.
        /// </summary>
        /// <param name="clientId"> Идентификатор клиента. </param>
        /// /// <param name="cancellationToken"> Структура отмены операций между потоками. </param>
        /// <param name="amount"> Сумма пополнения. </param>
        /// <returns></returns>
        Task DepositIntoAsync(Guid clientId, decimal amount, CancellationToken cancellationToken);

        /// <summary>
        /// Снять деньги со счёта.
        /// </summary>
        /// <param name="clientId"> Идентификатор клиента. </param>
        /// /// <param name="cancellationToken"> Структура отмены операций между потоками. </param>
        /// <param name="amount"> Сумма снятия. </param>
        /// <returns></returns>
        Task WithdrawFromAsync(Guid clientId, decimal amount, CancellationToken cancellationToken);
    }
}

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
        /// <returns> Баланс счёта. </returns>
        Task<decimal?> CheckBalanceAsync(Guid clientId);

        /// <summary>
        /// Пополнить баланс счёта.
        /// </summary>
        /// <param name="clientId"> Идентификатор клиента. </param>
        /// <param name="amount"> Сумма пополнения. </param>
        /// <returns></returns>
        Task DepositIntoAsync(Guid clientId, decimal amount);

        /// <summary>
        /// Снять деньги со счёта.
        /// </summary>
        /// <param name="clientId"> Идентификатор клиента. </param>
        /// <param name="amount"> Сумма снятия. </param>
        /// <returns></returns>
        Task WithDrawFromAsync(Guid clientId, decimal amount);
    }
}

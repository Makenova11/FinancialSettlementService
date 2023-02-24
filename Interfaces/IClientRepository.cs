namespace FinancialSettlementService.Interfaces
{
    using FinancialSettlementService.Dtos;
    using FinancialSettlementService.Models;

    /// <summary>
    /// Репозиторий действий с клиентом.
    /// </summary>
    public interface IClientRepository
    {
        /// <summary>
        /// Регистрация клиента
        /// </summary>
        /// <param name="clientDto"> Данные добавляемого пользователя. </param>
        /// <param name="cancellationToken"> Структура отмены операций между потоками. </param>
        /// <returns> Task. </returns>
        Task<Client> SignUpAsync(ClientDto clientDto, CancellationToken cancellationToken);

        /// <summary>
        /// Получить клиента по id.
        /// </summary>
        /// <param name="id"> Идентификатор клиента.</param>
        /// <returns> Информация о клиенте. </returns>
        Task<ClientInformationDto> GetByIdAsync(Guid id);
    }
}

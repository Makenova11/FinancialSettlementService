using FinancialSettlementService.Dtos;

namespace FinancialSettlementService.Interfaces
{
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
        Task SignUpAsync(ClientDto clientDto, CancellationToken cancellationToken);

        /// <summary>
        /// Получить клиента по id.
        /// </summary>
        /// <param name="id"> Идентификатор клиента.</param>
        /// <returns> Информация о клиенте. </returns>
        Task<ClientDto> GetByIdAsync(Guid id);
    }
}

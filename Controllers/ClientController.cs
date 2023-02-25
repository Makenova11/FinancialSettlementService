namespace FinancialSettlementService.Controllers
{
    using FinancialSettlementService.Dtos;
    using FinancialSettlementService.Interfaces;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Контроллер для работы с клиентами.
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        /// <inheritdoc cref="IClientRepository"/>
        private readonly IClientRepository _clientRepository;
        public ClientController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        /// <summary>
        /// Зарегистрировать клиента.
        /// </summary>
        /// <param name="clientDto"> Данные нового пользователя. </param>
        /// <param name="cancellationToken"> Структура для отмены операций между потоками. </param>
        /// <returns> Id нового клиента. </returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ClientDto))]
        public async Task<IActionResult> SignUpAsync([FromBody] ClientDto clientDto,
            CancellationToken cancellationToken)
        {
            var client = await _clientRepository.SignUpAsync(clientDto, cancellationToken);

            return CreatedAtAction("GetClient", new {guid = client.Id});
        }

        /// <summary>
        /// Провести поиск клиента по базе.
        /// </summary>
        /// <param name="Guid"> Идентификатор клиента. </param>
        /// <returns> Информация о клиенте. </returns>
        [HttpGet("Guid")]
        [ActionName("GetClient")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ClientInformationDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ClientInformationDto))]
        public async Task<IActionResult> GetById(Guid guid)
        {
            var client = await _clientRepository.GetByIdAsync(guid);

            if (client is null)
                return NotFound($"Клиент с индентификатором {guid} не найден.");
            return Ok(client);
        }
    }
}

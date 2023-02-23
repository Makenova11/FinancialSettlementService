using FinancialSettlementService.Dtos;
using FinancialSettlementService.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinancialSettlementService.Controllers
{
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
        /// Зарегистрировать нового пользователя.
        /// </summary>
        /// <param name="clientDto"> Данные нового пользователя. </param>
        /// <param name="cancellationToken"> Структура для отмены операций между потоками. </param>
        /// <returns> IActionResult. </returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ClientDto))]
        public async Task<IActionResult> SignUpAsync([FromBody] ClientDto clientDto,
            CancellationToken cancellationToken)
        {
            await _clientRepository.SignUpAsync(clientDto, cancellationToken);

            return CreatedAtAction("Sign Up", clientDto);
        }
    }
}

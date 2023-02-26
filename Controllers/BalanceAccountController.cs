namespace FinancialSettlementService.Controllers
{
    using FinancialSettlementService.Helpers;
    using FinancialSettlementService.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using Npgsql;

    /// <summary>
    /// Контроллер взаимодействия со счётом клиента.
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class BalanceAccountController : ControllerBase
    {
        /// <inheritdoc cref="IBalanceRepository"/>
        private readonly IBalanceRepository _balanceRepository;

        /// <inheritdoc cref="IClientRepository"/>
        private readonly IClientRepository _clientRepository;
        public BalanceAccountController(IBalanceRepository balanceRepository, IClientRepository clientRepository)
        {
            _balanceRepository = balanceRepository;
            _clientRepository = clientRepository;
        }

        /// <summary>
        /// Проверить баланс клиента.
        /// </summary>
        /// <param name="guid"> Идентификатор клиента. </param>
        /// <param name="cancellationToken"> Структура для отмены операций между потоками. </param>
        /// <returns> Информация о балансе клиента. </returns>
        [HttpGet("Guid")]
        [ActionName("Check")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetBalanceById(Guid guid, CancellationToken cancellationToken)
        {
            var balance = await _balanceRepository.CheckBalanceAsync(guid, cancellationToken);

            if (balance is null)
                return NotFound($"Клиент с индентификатором {guid} не найден.");
            return Ok(balance);
        }

        /// <summary>
        /// Внести деньги на счёт.
        /// </summary>
        /// <param name="guid"> Идентификатор клиента. </param>
        /// <param name="amount"> Сумма пополнения. </param>
        /// <param name="cancellationToken"> Структура для отмены операций между потоками. </param>
        /// <returns> IActionResult. </returns>
        [HttpPatch("deposit/{guid}/{amount}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DepositAsync(Guid guid, decimal amount, CancellationToken cancellationToken)
        {
            var client = await _clientRepository.GetByIdAsync(guid);

            try
            {
                if (client is null)
                    return NotFound($"Клиент с индентификатором {guid} не найден.");
                await _balanceRepository.DepositIntoAsync(client.Id, amount, cancellationToken);
            }
            catch
            {
                return BadRequest("Не удалось пополнить баланс.");
            }

            var balance = await _balanceRepository.CheckBalanceAsync(client.Id, cancellationToken);

            return Ok($"Текущий баланс:{balance}");
        }

        /// <summary>
        /// Снять деньги со счёта.
        /// </summary>
        /// <param name="guid"> Идентификатор клиента. </param>
        /// <param name="amount"> Сумма снятия. </param>
        /// <param name="cancellationToken"> Структура для отмены операций между потоками. </param>
        /// <returns> IActionResult. </returns>
        [HttpPatch("withdraw/{guid}/{amount}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> WithdrawAsync(Guid guid, decimal amount, CancellationToken cancellationToken)
        {
            var client = await _clientRepository.GetByIdAsync(guid);

            try
            {
                if (client is null)
                    return NotFound($"Клиент с индентификатором {guid} не найден.");
                await _balanceRepository.WithdrawFromAsync(client.Id, amount, cancellationToken);
            }
            catch (PostgresException ex) when (ex.ConstraintName == ValidationTypeConstants.NoNegativeBalanceConstraint)
            {
                return BadRequest("Ошибка! Недостаточно средств на счёте.");
            }
            catch (Exception)
            {
                return StatusCode(500, "Не удалось снять деньги со счёта.");
            }

            var balance = await _balanceRepository.CheckBalanceAsync(client.Id, cancellationToken);

            return Ok($"Баланс после снятия средств:{balance}");
        }
    }
}

using FinancialSettlementService.Dtos;
using FinancialSettlementService.Interfaces;
using FinancialSettlementService.Models;

namespace FinancialSettlementService.Repositories
{
    /// <inheritdoc cref="IClientRepository"/>
    public class ClientRepository : IClientRepository
    {
        /// <inheritdoc cref="BankDbContext"/>
        private readonly BankDbContext _dbContext;
        public ClientRepository(BankDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <inheritdoc/>
        public Task<ClientDto> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public async Task SignUpAsync (ClientDto clientDto, CancellationToken cancellationToken)
        {
            var client = new Client
            {
                FirstName = clientDto.FirstName,
                SecondName = clientDto.SecondName,
                BirthDay = DateTime.Parse(clientDto.BirthDay),
                Patronymic = clientDto.Patronymic,
            };
            var balanceAccount = new BalanceAccount
            {
                Balance = clientDto.Balance,
                Client = client
            };

            await _dbContext.AddAsync(client, cancellationToken);
            await _dbContext.AddAsync(balanceAccount, cancellationToken);

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}

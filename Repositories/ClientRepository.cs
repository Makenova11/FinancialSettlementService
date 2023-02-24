namespace FinancialSettlementService.Repositories
{
    using FinancialSettlementService.Dtos;
    using FinancialSettlementService.Interfaces;
    using FinancialSettlementService.Models;
    using FinancialSettlementService.MapsterConfiguration;
    using MapsterMapper;

    /// <inheritdoc cref="IClientRepository"/>
    public class ClientRepository : IClientRepository
    {
        /// <inheritdoc cref="BankDbContext"/>
        private readonly BankDbContext _dbContext;

        /// <inheritdoc cref="MappingConfiguration"/>
        private readonly IMapper _mapper;
        public ClientRepository(BankDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<ClientInformationDto> GetByIdAsync(Guid id)
        {
            var client = _dbContext.Clients.SingleOrDefault(client => client.Id == id);

            return _mapper.Map<ClientInformationDto>(client);
        }
            
        /// <inheritdoc/>
        public async Task<Client> SignUpAsync (ClientDto clientDto, CancellationToken cancellationToken)
        {
            var client = _mapper.Map<Client>(clientDto);
            var balanceAccount = new BalanceAccount
            {
                Balance = clientDto.Balance,
                Client = client
            };

            await _dbContext.AddAsync(client, cancellationToken);
            await _dbContext.AddAsync(balanceAccount, cancellationToken);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return client;
        }
    }
}

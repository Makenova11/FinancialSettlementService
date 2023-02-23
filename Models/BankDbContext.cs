using Microsoft.EntityFrameworkCore;

namespace FinancialSettlementService.Models
{
    /// <summary>
    /// Контекст базы данных.
    /// </summary>
    public class BankDbContext : DbContext
    {
        public BankDbContext(DbContextOptions<BankDbContext> options) : base(options)
        {
        }

        public DbSet<BalanceAccount> BalanceAccounts { get; set; }

        public DbSet<Client> Clients { get; set; }

    }
}

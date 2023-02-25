namespace FinancialSettlementService.Models
{
    using FinancialSettlementService.Helpers;
    using Microsoft.EntityFrameworkCore;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BalanceAccount>()
                .ToTable(x => x.HasCheckConstraint(ValidationTypeConstants.NoNegativeBalanceConstraint, "\"Balance\" >= 0"));
        }

    }
}

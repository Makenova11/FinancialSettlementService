namespace FinancialSettlementService.DI
{
    using FinancialSettlementService.Models;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Добавление зависимостей бд.
    /// </summary>
    public static class AddBankDbDependency
    {
        /// <summary>
        /// Добавление бд в сервисы.
        /// </summary>
        public static void AddBankDb(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<BankDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });
        }
    }
}

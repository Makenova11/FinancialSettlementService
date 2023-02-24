namespace FinancialSettlementService.DI
{
    using FinancialSettlementService.Helpers;
    using FinancialSettlementService.MapsterConfiguration;
    using Mapster;
    using MapsterMapper;
    using Microsoft.Extensions.DependencyInjection;
    using System.Reflection;

    /// <summary>
    /// Инжектим мапстер.
    /// </summary>
    public static class AddMapsterDependency
    {
        /// <summary>
        /// Добавление мапстера в сервисы.
        /// </summary>
        public static void AddMapster(this IServiceCollection services)
        {
            var config = new TypeAdapterConfig();
            config.Apply(new MappingConfiguration());

            services.AddSingleton(config);
            services.AddScoped<IMapper, ServiceMapper>();
        }
    }
}

using FinancialSettlementService.DI;
using FinancialSettlementService.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddBankDb(builder.Configuration.GetConnectionString("DefaultConnection"));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

await MigrateDatabaseAsync(app.Services, "Не удалось мигрировать базу данных.");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


async Task MigrateDatabaseAsync(IServiceProvider serviceProvider, string errorMessage)
{
    await using var scope = serviceProvider.CreateAsyncScope();
    using var dbContext = scope.ServiceProvider.GetService<BankDbContext>();
    if (dbContext is null)
        throw new ArgumentNullException(errorMessage);
    await dbContext.Database.MigrateAsync();
}
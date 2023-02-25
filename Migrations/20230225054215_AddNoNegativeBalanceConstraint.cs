using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinancialSettlementService.Migrations
{
    /// <inheritdoc />
    public partial class AddNoNegativeBalanceConstraint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddCheckConstraint(
                name: "NoNegativeBalanceConstraint",
                table: "BalanceAccounts",
                sql: "\"Balance\" >= 0");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "NoNegativeBalanceConstraint",
                table: "BalanceAccounts");
        }
    }
}

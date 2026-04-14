using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepairShop.Repository._data
{
    /// <inheritdoc />
    public partial class AddInvoicesAndFixRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubTotal",
                table: "Invoices");

            migrationBuilder.RenameColumn(
                name: "customerEmail",
                table: "RepairTickets",
                newName: "CustomerEmail");

            migrationBuilder.RenameColumn(
                name: "customerEmail",
                table: "Invoices",
                newName: "CustomerEmail");

            migrationBuilder.AddColumn<int>(
                name: "DeliverMethodId",
                table: "RepairTickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PaymentIntentId",
                table: "RepairTickets",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeliverMethodId",
                table: "RepairTickets");

            migrationBuilder.DropColumn(
                name: "PaymentIntentId",
                table: "RepairTickets");

            migrationBuilder.RenameColumn(
                name: "CustomerEmail",
                table: "RepairTickets",
                newName: "customerEmail");

            migrationBuilder.RenameColumn(
                name: "CustomerEmail",
                table: "Invoices",
                newName: "customerEmail");

            migrationBuilder.AddColumn<decimal>(
                name: "SubTotal",
                table: "Invoices",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}

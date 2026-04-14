using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepairShop.Repository._data
{
    /// <inheritdoc />
    public partial class CleanShadowKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RepairTickets_Customers_CustomerId1",
                table: "RepairTickets");

            migrationBuilder.DropForeignKey(
                name: "FK_RepairTickets_Engineers_EngineerId1",
                table: "RepairTickets");

            migrationBuilder.DropIndex(
                name: "IX_RepairTickets_CustomerId1",
                table: "RepairTickets");

            migrationBuilder.DropIndex(
                name: "IX_RepairTickets_EngineerId1",
                table: "RepairTickets");

            migrationBuilder.DropColumn(
                name: "CustomerId1",
                table: "RepairTickets");

            migrationBuilder.DropColumn(
                name: "EngineerId1",
                table: "RepairTickets");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerId1",
                table: "RepairTickets",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EngineerId1",
                table: "RepairTickets",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RepairTickets_CustomerId1",
                table: "RepairTickets",
                column: "CustomerId1");

            migrationBuilder.CreateIndex(
                name: "IX_RepairTickets_EngineerId1",
                table: "RepairTickets",
                column: "EngineerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_RepairTickets_Customers_CustomerId1",
                table: "RepairTickets",
                column: "CustomerId1",
                principalTable: "Customers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RepairTickets_Engineers_EngineerId1",
                table: "RepairTickets",
                column: "EngineerId1",
                principalTable: "Engineers",
                principalColumn: "Id");
        }
    }
}

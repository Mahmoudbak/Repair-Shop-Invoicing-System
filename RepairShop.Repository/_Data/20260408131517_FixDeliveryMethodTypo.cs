using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepairShop.Repository._data
{
    /// <inheritdoc />
    public partial class FixDeliveryMethodTypo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeliverMethodId",
                table: "RepairTickets");

            migrationBuilder.AlterColumn<int>(
                name: "DeliveryMethodId",
                table: "RepairTickets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "DeliveryMethodId",
                table: "RepairTickets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "DeliverMethodId",
                table: "RepairTickets",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

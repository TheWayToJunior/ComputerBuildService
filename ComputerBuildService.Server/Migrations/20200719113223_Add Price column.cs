using Microsoft.EntityFrameworkCore.Migrations;

namespace ComputerBuildService.Server.Migrations
{
    public partial class AddPricecolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "RandomAccessMemorys",
                type: "Money",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Processors",
                type: "Money",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "PowerSupplies",
                type: "Money",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Motherboards",
                type: "Money",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "HardDrives",
                type: "Money",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "GraphicsCards",
                type: "Money",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "CpuСoolers",
                type: "Money",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "RandomAccessMemorys");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "PowerSupplies");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Motherboards");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "HardDrives");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "CpuСoolers");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Processors",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "Money");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "GraphicsCards",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "Money");
        }
    }
}

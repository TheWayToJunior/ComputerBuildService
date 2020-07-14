using Microsoft.EntityFrameworkCore.Migrations;

namespace ComputerBuildService.Server.Migrations
{
    public partial class RenameProcessor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Processors",
                keyColumn: "Id",
                keyValue: 1,
                column: "Discriminator",
                value: "Processor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Processors",
                keyColumn: "Id",
                keyValue: 1,
                column: "Discriminator",
                value: "CentralProcessorUnit");
        }
    }
}

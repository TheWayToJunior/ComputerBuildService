using Microsoft.EntityFrameworkCore.Migrations;

namespace ComputerBuildService.DAL.Migrations
{
    public partial class RenamedTypeNameinName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_HardwareTypes_TypeName",
                table: "HardwareTypes");

            migrationBuilder.DropColumn(
                name: "TypeName",
                table: "HardwareTypes");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "HardwareTypes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HardwareTypes_Name",
                table: "HardwareTypes",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_HardwareTypes_Name",
                table: "HardwareTypes");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "HardwareTypes");

            migrationBuilder.AddColumn<string>(
                name: "TypeName",
                table: "HardwareTypes",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HardwareTypes_TypeName",
                table: "HardwareTypes",
                column: "TypeName",
                unique: true,
                filter: "[TypeName] IS NOT NULL");
        }
    }
}

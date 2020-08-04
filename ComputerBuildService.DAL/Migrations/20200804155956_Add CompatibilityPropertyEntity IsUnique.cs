using Microsoft.EntityFrameworkCore.Migrations;

namespace ComputerBuildService.DAL.Migrations
{
    public partial class AddCompatibilityPropertyEntityIsUnique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CompatibleProperties_PropertyName",
                table: "CompatibleProperties");

            migrationBuilder.CreateIndex(
                name: "IX_CompatibleProperties_PropertyName_PropertyType",
                table: "CompatibleProperties",
                columns: new[] { "PropertyName", "PropertyType" },
                unique: true,
                filter: "[PropertyName] IS NOT NULL AND [PropertyType] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CompatibleProperties_PropertyName_PropertyType",
                table: "CompatibleProperties");

            migrationBuilder.CreateIndex(
                name: "IX_CompatibleProperties_PropertyName",
                table: "CompatibleProperties",
                column: "PropertyName",
                unique: true,
                filter: "[PropertyName] IS NOT NULL");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace ComputerBuildService.DAL.Migrations
{
    public partial class InitDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompatibleProperties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropertyType = table.Column<string>(maxLength: 32, nullable: true),
                    PropertyName = table.Column<string>(maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompatibleProperties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HardwareTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HardwareTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Manufacturers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HardwareItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 64, nullable: true),
                    Price = table.Column<decimal>(type: "Money", nullable: false),
                    Description = table.Column<string>(maxLength: 255, nullable: true),
                    ManufacturerId = table.Column<int>(nullable: false),
                    HardwareTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HardwareItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HardwareItems_HardwareTypes_HardwareTypeId",
                        column: x => x.HardwareTypeId,
                        principalTable: "HardwareTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HardwareItems_Manufacturers_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompatibilityPropertyHardwareItem",
                columns: table => new
                {
                    PropertyId = table.Column<int>(nullable: false),
                    ItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompatibilityPropertyHardwareItem", x => new { x.ItemId, x.PropertyId });
                    table.ForeignKey(
                        name: "FK_CompatibilityPropertyHardwareItem_HardwareItems_ItemId",
                        column: x => x.ItemId,
                        principalTable: "HardwareItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompatibilityPropertyHardwareItem_CompatibleProperties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "CompatibleProperties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompatibilityPropertyHardwareItem_PropertyId",
                table: "CompatibilityPropertyHardwareItem",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompatibleProperties_PropertyName",
                table: "CompatibleProperties",
                column: "PropertyName",
                unique: true,
                filter: "[PropertyName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_HardwareItems_HardwareTypeId",
                table: "HardwareItems",
                column: "HardwareTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HardwareItems_ManufacturerId",
                table: "HardwareItems",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_HardwareItems_Name",
                table: "HardwareItems",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_HardwareTypes_TypeName",
                table: "HardwareTypes",
                column: "TypeName",
                unique: true,
                filter: "[TypeName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Manufacturers_Name",
                table: "Manufacturers",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompatibilityPropertyHardwareItem");

            migrationBuilder.DropTable(
                name: "HardwareItems");

            migrationBuilder.DropTable(
                name: "CompatibleProperties");

            migrationBuilder.DropTable(
                name: "HardwareTypes");

            migrationBuilder.DropTable(
                name: "Manufacturers");
        }
    }
}

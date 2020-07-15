using Microsoft.EntityFrameworkCore.Migrations;

namespace ComputerBuildService.Server.Migrations
{
    public partial class addProcessorBaseandGraphicsBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Motherboards_GraphicsCards_IntegratedGraphicsId",
                table: "Motherboards");

            migrationBuilder.DropForeignKey(
                name: "FK_Motherboards_Processors_IntegratedProcessorId",
                table: "Motherboards");

            migrationBuilder.DropForeignKey(
                name: "FK_Processors_GraphicsCards_IntegratedGraphicsId",
                table: "Processors");

            migrationBuilder.DeleteData(
                table: "GraphicsCards",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Processors");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "GraphicsCards");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Processors",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "GraphicsCards",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "IntegratedGraphics",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    FrequencyGraphicsProcessor = table.Column<int>(nullable: false),
                    VideoMemoryType = table.Column<string>(maxLength: 12, nullable: false),
                    FrequencyVideoMemory = table.Column<int>(nullable: false),
                    VideoMemoryAmount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntegratedGraphics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IntegratedProcessors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Maker = table.Column<string>(nullable: false),
                    RangeOf = table.Column<string>(nullable: false),
                    Model = table.Column<string>(maxLength: 32, nullable: false),
                    Socket = table.Column<string>(maxLength: 16, nullable: false),
                    FrequencyCore = table.Column<int>(nullable: false),
                    NumberOfCores = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntegratedProcessors", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "IntegratedGraphics",
                columns: new[] { "Id", "FrequencyGraphicsProcessor", "FrequencyVideoMemory", "Name", "VideoMemoryAmount", "VideoMemoryType" },
                values: new object[] { 1, 1600, 2048, "vega 8", 1250, "DDR4" });

            migrationBuilder.AddForeignKey(
                name: "FK_Motherboards_IntegratedGraphics_IntegratedGraphicsId",
                table: "Motherboards",
                column: "IntegratedGraphicsId",
                principalTable: "IntegratedGraphics",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Motherboards_IntegratedProcessors_IntegratedProcessorId",
                table: "Motherboards",
                column: "IntegratedProcessorId",
                principalTable: "IntegratedProcessors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Processors_IntegratedGraphics_IntegratedGraphicsId",
                table: "Processors",
                column: "IntegratedGraphicsId",
                principalTable: "IntegratedGraphics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Motherboards_IntegratedGraphics_IntegratedGraphicsId",
                table: "Motherboards");

            migrationBuilder.DropForeignKey(
                name: "FK_Motherboards_IntegratedProcessors_IntegratedProcessorId",
                table: "Motherboards");

            migrationBuilder.DropForeignKey(
                name: "FK_Processors_IntegratedGraphics_IntegratedGraphicsId",
                table: "Processors");

            migrationBuilder.DropTable(
                name: "IntegratedGraphics");

            migrationBuilder.DropTable(
                name: "IntegratedProcessors");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Processors");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "GraphicsCards");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Processors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "GraphicsCards",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "GraphicsCards",
                columns: new[] { "Id", "Discriminator", "FrequencyGraphicsProcessor", "FrequencyVideoMemory", "Name", "VideoMemoryAmount", "VideoMemoryType" },
                values: new object[] { 1, "IntegratedGraphics", 1600, 2048, "vega 8", 1250, "DDR4" });

            migrationBuilder.UpdateData(
                table: "Processors",
                keyColumn: "Id",
                keyValue: 1,
                column: "Discriminator",
                value: "Processor");

            migrationBuilder.AddForeignKey(
                name: "FK_Motherboards_GraphicsCards_IntegratedGraphicsId",
                table: "Motherboards",
                column: "IntegratedGraphicsId",
                principalTable: "GraphicsCards",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Motherboards_Processors_IntegratedProcessorId",
                table: "Motherboards",
                column: "IntegratedProcessorId",
                principalTable: "Processors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Processors_GraphicsCards_IntegratedGraphicsId",
                table: "Processors",
                column: "IntegratedGraphicsId",
                principalTable: "GraphicsCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

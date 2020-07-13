using Microsoft.EntityFrameworkCore.Migrations;

namespace ComputerBuildService.Server.Migrations
{
    public partial class Initdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CpuСoolers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    SizeBlower = table.Column<string>(maxLength: 12, nullable: true),
                    NumberBlower = table.Column<int>(nullable: false),
                    RotationSpeed = table.Column<string>(nullable: true),
                    NoiseLevel = table.Column<string>(nullable: true),
                    Sockets = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CpuСoolers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GraphicsCards",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    FrequencyGraphicsProcessor = table.Column<int>(nullable: false),
                    VideoMemoryType = table.Column<string>(maxLength: 12, nullable: false),
                    FrequencyVideoMemory = table.Column<int>(nullable: false),
                    VideoMemoryAmount = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GraphicsCards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HardDrives",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    ConnectionInterface = table.Column<string>(nullable: false),
                    RotationSpeed = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HardDrives", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PowerSupplies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Power = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PowerSupplies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RandomAccessMemorys",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Type = table.Column<string>(maxLength: 12, nullable: false),
                    Frequency = table.Column<int>(nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    Sockets = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RandomAccessMemorys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Processors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Maker = table.Column<string>(nullable: false),
                    RangeOf = table.Column<string>(nullable: false),
                    Model = table.Column<string>(maxLength: 32, nullable: false),
                    Socket = table.Column<string>(maxLength: 16, nullable: false),
                    FrequencyCore = table.Column<int>(nullable: false),
                    NumberOfCores = table.Column<int>(nullable: false),
                    IntegratedGraphicsId = table.Column<int>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Processors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Processors_GraphicsCards_IntegratedGraphicsId",
                        column: x => x.IntegratedGraphicsId,
                        principalTable: "GraphicsCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Motherboards",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Chipset = table.Column<string>(maxLength: 32, nullable: false),
                    Socket = table.Column<string>(maxLength: 16, nullable: false),
                    FormFactor = table.Column<string>(maxLength: 32, nullable: true),
                    MemoryType = table.Column<string>(maxLength: 12, nullable: false),
                    MemorySlots = table.Column<int>(nullable: false),
                    MaximumMemory = table.Column<int>(nullable: false),
                    SoundCard = table.Column<string>(nullable: true),
                    NetworkInterface = table.Column<string>(nullable: true),
                    Connectors = table.Column<string>(nullable: false),
                    IntegratedProcessorId = table.Column<int>(nullable: true),
                    IntegratedGraphicsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motherboards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Motherboards_GraphicsCards_IntegratedGraphicsId",
                        column: x => x.IntegratedGraphicsId,
                        principalTable: "GraphicsCards",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Motherboards_Processors_IntegratedProcessorId",
                        column: x => x.IntegratedProcessorId,
                        principalTable: "Processors",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "GraphicsCards",
                columns: new[] { "Id", "Discriminator", "FrequencyGraphicsProcessor", "FrequencyVideoMemory", "Name", "VideoMemoryAmount", "VideoMemoryType" },
                values: new object[] { 1, "IntegratedGraphics", 1600, 2048, "vega 8", 1250, "DDR4" });

            migrationBuilder.InsertData(
                table: "Processors",
                columns: new[] { "Id", "Discriminator", "FrequencyCore", "IntegratedGraphicsId", "Maker", "Model", "NumberOfCores", "RangeOf", "Socket" },
                values: new object[] { 1, "CentralProcessorUnit", 2500, 1, "AMD", "1600", 6, "Ryzen 5", "AM4" });

            migrationBuilder.CreateIndex(
                name: "IX_Motherboards_IntegratedGraphicsId",
                table: "Motherboards",
                column: "IntegratedGraphicsId");

            migrationBuilder.CreateIndex(
                name: "IX_Motherboards_IntegratedProcessorId",
                table: "Motherboards",
                column: "IntegratedProcessorId");

            migrationBuilder.CreateIndex(
                name: "IX_Processors_IntegratedGraphicsId",
                table: "Processors",
                column: "IntegratedGraphicsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CpuСoolers");

            migrationBuilder.DropTable(
                name: "HardDrives");

            migrationBuilder.DropTable(
                name: "Motherboards");

            migrationBuilder.DropTable(
                name: "PowerSupplies");

            migrationBuilder.DropTable(
                name: "RandomAccessMemorys");

            migrationBuilder.DropTable(
                name: "Processors");

            migrationBuilder.DropTable(
                name: "GraphicsCards");
        }
    }
}

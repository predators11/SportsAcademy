using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportsAcademy.Infrastructure.Migrations
{
    public partial class _9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Shops");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4a40a374-b427-4e10-aba6-8794db3136c0", "AQAAAAEAACcQAAAAEEJZfGixRUZDybCF9/dV3pizAVeJqLgNHmIOhL4k4sux6ArXIIRET/yVsarshiC7dA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "800798c6-4c87-4867-89b2-63aafbd65aa5", "AQAAAAEAACcQAAAAEPciODuillWM3i4T9xjUbIv95vK9wWBxEMXA8xz73YzImWFVBTqQB6A2AoMoD59oeA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Shops",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BallsPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ClothingPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RacketsPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RobotsPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shops", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "df9c49e9-5253-4a6f-a37e-06ea6023c6c7", "AQAAAAEAACcQAAAAEPbghXpxEjUjnUyRyqdBD82m/emBqMa4bgysDKewlESAJ2YtBOPifqFic8A5qkJshA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "30d41d00-d897-43bb-9110-145e929e6a9c", "AQAAAAEAACcQAAAAEJpbPJrKLuetW7cm51IIEP8nDr7A11s9L3lXfoEqzRN4K2Ngas6H6Dmx5L218lvfkA==" });

            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "Id", "BallsPrice", "ClothingPrice", "RacketsPrice", "RobotsPrice" },
                values: new object[] { 1, 5.00m, 100.00m, 50.00m, 300.00m });
        }
    }
}

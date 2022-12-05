using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportsAcademy.Infrastructure.Migrations
{
    public partial class _8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Trainers",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

            migrationBuilder.UpdateData(
                table: "Trainers",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Trainers",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Trainers",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsActive",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Trainers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9e9e90a7-8d80-4c1f-bc6c-2ebf31e7be7d", "AQAAAAEAACcQAAAAECe752WqtUv/1UM0Kna8hMKbPiHV1E/roG0Ud91StECxxNfGjQIN4jM+w1BjnixTTA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5647b7ed-76e5-4b9f-91d1-d92cc06e30e3", "AQAAAAEAACcQAAAAECdKUujdli5WT7wNSk/BDsuqfhjlzNJM1rpDPh6xmTe0XbYyQCJ4DxnfXw12CCSOlQ==" });
        }
    }
}

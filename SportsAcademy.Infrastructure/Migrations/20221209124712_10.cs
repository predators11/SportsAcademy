using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportsAcademy.Infrastructure.Migrations
{
    public partial class _10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "49f22077-bd6c-4ad3-b59a-86326cd984a9", "AQAAAAEAACcQAAAAEMVQyiYzPuqG+5W1im+lXm1LxFN21ks19dqmdavHvH6PpCgJwqAC4Kxzen2QX82ACg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5266714e-f612-42cc-9e99-3af61592a94d", "AQAAAAEAACcQAAAAELaax9CyyClpwQK/NdAmvb9DAhr7XeF0CcabZC5pSFnfDHKAFxgJhwznp9iwXPPReA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}

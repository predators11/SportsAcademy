using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportsAcademy.Infrastructure.Migrations
{
    public partial class _11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5730b422-db6c-4702-ba0f-d0ed9ef28b8b", "AQAAAAEAACcQAAAAEJ7DAZk03nTsXQdPhLH8VxS4bdzDZsFprJH+6cPJR6dPMeaGQitWdScOn8rC+f7y0w==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8d832911-3adb-45ea-8068-a64b62df5868", "AQAAAAEAACcQAAAAEC0/5r+G92iOk4JcrE7uSnSSKbtsOlA7svhjW8mbLvjLwLhi5PN1J5DLvy5D4qEryA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}

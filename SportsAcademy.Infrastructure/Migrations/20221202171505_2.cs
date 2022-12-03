using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportsAcademy.Infrastructure.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4db1aa1f-7d5e-44d0-9092-452cd30e0f63", "AQAAAAEAACcQAAAAEKKIEAVSGL2M6J3s5q++RLpBLJVteQdwVVZHiUWMGfpknng8K3+RWJXsZjy9K7Q0fA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c5081a56-8834-4510-84d2-58d03bc7599f", "AQAAAAEAACcQAAAAELVfS1bbkG1cZLyw1vkQtCFE7EITi6pU3ZKdDsQ7EDx0GNfYT9DPDmZoX+Ms4tiaoA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4b1d944a-9dec-47a2-b9ff-e6b0426cb512", "AQAAAAEAACcQAAAAEDlOnON2xF4ldN3ZLg8HllfPPD+qtx32eyYSTnsWZnfrJfcDiQFMFSFSYLay1EAbaA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "628c4873-d174-4e31-82fe-2f2181c9f73c", "AQAAAAEAACcQAAAAELSoE3BsIO7aSeyEvhbsJJQmkXujbhKo4AYUb2/V0Xt26yct2kbl4ilJSGWcn6dUgw==" });
        }
    }
}

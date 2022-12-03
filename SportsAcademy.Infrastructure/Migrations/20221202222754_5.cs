using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportsAcademy.Infrastructure.Migrations
{
    public partial class _5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "bc106e2c-a0b1-4210-b98f-2a13735b076c", "AQAAAAEAACcQAAAAEEvFyKhgte/pkzruUh7cWc0gC9lqKLocn6RDtkj4HbY72RpNEJUGri2Km0jyr8SdRw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b3bc89a3-9f17-412d-93aa-c3607dd18b31", "AQAAAAEAACcQAAAAEAzmbEX7E3iCekCUYaHFAH+EKFGAjL/wHHEB4/IHz43mrBNIzUKwLIhqrM3Btvwoww==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}

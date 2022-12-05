using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportsAcademy.Infrastructure.Migrations
{
    public partial class _7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Trainers",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.UpdateData(
                table: "Trainers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CategoryId", "TrainingExpirience" },
                values: new object[] { 1, "5 years" });

            migrationBuilder.UpdateData(
                table: "Trainers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CategoryId", "TrainingExpirience" },
                values: new object[] { 2, "7 years" });

            migrationBuilder.UpdateData(
                table: "Trainers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CategoryId",
                value: 3);

            migrationBuilder.CreateIndex(
                name: "IX_Trainers_CategoryId",
                table: "Trainers",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trainers_Categories_CategoryId",
                table: "Trainers",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trainers_Categories_CategoryId",
                table: "Trainers");

            migrationBuilder.DropIndex(
                name: "IX_Trainers_CategoryId",
                table: "Trainers");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Trainers");

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

            migrationBuilder.UpdateData(
                table: "Trainers",
                keyColumn: "Id",
                keyValue: 1,
                column: "TrainingExpirience",
                value: "2 years");

            migrationBuilder.UpdateData(
                table: "Trainers",
                keyColumn: "Id",
                keyValue: 2,
                column: "TrainingExpirience",
                value: "5 years");
        }
    }
}

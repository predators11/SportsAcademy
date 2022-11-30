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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "70a26a20-476d-47c4-8b36-8c6df415866a", "AQAAAAEAACcQAAAAELsPphc9/i07KM401v7F2Yu509eXs3im/wvwqMCWUjBHrYDQaXiEZBtNiqO9ZdYG3g==", "670b016b-0699-4852-b6b4-8dec08e34c99" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8e9afc44-947a-44e3-b2ab-e7a31e566b32", "AQAAAAEAACcQAAAAECACno1gXQ8kLmcineaQvxyqi0PAhalCHFnukQPIjyRpoQYRLQ5lsiaxklBcoesxnQ==", "bbcfe9b1-4d84-4cfa-9e3f-b804db5d8936" });

            migrationBuilder.UpdateData(
                table: "SportMemberships",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://uploads-ssl.webflow.com/5e71b829d37a8158f8643ac3/5e7e3d6fdf522d8b72159b02_rackets-merged.png");

            migrationBuilder.UpdateData(
                table: "SportMemberships",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://images.squarespace-cdn.com/content/v1/5fb46909e6fc155f519f8ee1/c0d2fe31-f621-470b-ad71-2a2813ef3e0d/DSCF0321.jpg");

            migrationBuilder.UpdateData(
                table: "SportMemberships",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQZGUej8azFt2SwL96yk2qblXY70diU3zEbOA&usqp=CAU");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b5fa9518-2c15-4dd3-9045-0c27eaabdf33", "AQAAAAEAACcQAAAAEOtduMato9WLfNNpyyUrAF13f8nI84UVJN8E3S3kwT9Qirun1oEOhL8A2b2j8NNDYg==", "b688dc96-ed61-4d0a-892e-bb368b5b0f97" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dfbbc47e-5e0d-43b1-bd13-598bb84e4588", "AQAAAAEAACcQAAAAEL3j0BUH+MWsFf3NpLsUxJ1fUOJUDOqEd/alF21UFF5CiavcRhx35HQwEhRm3jGi7g==", "2cec1878-9013-4c3a-a1ba-b313b15ed0bf" });

            migrationBuilder.UpdateData(
                table: "SportMemberships",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://app.anglo-link.com/uploads/monthly_2017_10/silver_store.png.740319ddc9e559ccb5dc1fc708ee2c1b.png");

            migrationBuilder.UpdateData(
                table: "SportMemberships",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://www.epsb.co.uk/wp-content/uploads/gold-membership1.png");

            migrationBuilder.UpdateData(
                table: "SportMemberships",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://cdn.shpy.in/79267/1632516965209_SKU-0049_0?");
        }
    }
}

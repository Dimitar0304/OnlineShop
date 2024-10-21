using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShop.Infrastructure.Migrations
{
    public partial class addUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6f46e3d8-3485-4044-8eda-ce18b707d63c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ca280558-67b1-4d9e-a388-b7f5038c0e15");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "24ed2e77-9b16-4ea1-becc-b00215d3a6e3", "ec7f42ac-3663-46fa-85fa-b495dd8e0799", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "edd92318-e9f0-4708-af00-1b3c844eebd6", "9c02f7c1-65ac-41bb-8b9d-8594d3975390", "User", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "24ed2e77-9b16-4ea1-becc-b00215d3a6e3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "edd92318-e9f0-4708-af00-1b3c844eebd6");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6f46e3d8-3485-4044-8eda-ce18b707d63c", "45a1ff55-fd12-46e3-80cc-cfa8c890da9c", "User", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ca280558-67b1-4d9e-a388-b7f5038c0e15", "9adb1e72-ab88-4801-8cc4-0d4d7e3693f6", "Admin", null });
        }
    }
}

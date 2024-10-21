using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShop.Infrastructure.Migrations
{
    public partial class addRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "322a7bf2-124a-4ce7-bdf8-43eba64446b5", "5d75c59a-213f-43b2-8884-851e61786a6f", "User", "User" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f05308b9-55ff-4b20-8e57-9a2b89573525", "b4bd58ca-f2f8-4c34-b784-1f1a4b229de5", "Admin", "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "322a7bf2-124a-4ce7-bdf8-43eba64446b5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f05308b9-55ff-4b20-8e57-9a2b89573525");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "24ed2e77-9b16-4ea1-becc-b00215d3a6e3", "ec7f42ac-3663-46fa-85fa-b495dd8e0799", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "edd92318-e9f0-4708-af00-1b3c844eebd6", "9c02f7c1-65ac-41bb-8b9d-8594d3975390", "User", null });
        }
    }
}

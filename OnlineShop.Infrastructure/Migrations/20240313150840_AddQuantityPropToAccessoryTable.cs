using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShop.Infrastructure.Migrations
{
    public partial class AddQuantityPropToAccessoryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "87746889-978a-4eb2-86fe-cf52a52bf51e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a873d09c-bf8c-4224-ada7-bd94c611a9dc");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Accessories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0077b0ec-8d84-4f9e-9c58-77aec6f51037", "88edc141-b039-4686-b460-348a2a2bdb2c", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fbabe2b2-9476-417a-b009-cf080ae0545d", "1f06f847-aa27-4582-a577-20b98f498c77", "User", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0077b0ec-8d84-4f9e-9c58-77aec6f51037");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fbabe2b2-9476-417a-b009-cf080ae0545d");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Accessories");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "87746889-978a-4eb2-86fe-cf52a52bf51e", "c90ef201-d388-40ac-ad37-d3adeaf70266", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a873d09c-bf8c-4224-ada7-bd94c611a9dc", "d96ee64f-f8b6-4a7d-aad7-d29b068c16cd", "User", null });
        }
    }
}

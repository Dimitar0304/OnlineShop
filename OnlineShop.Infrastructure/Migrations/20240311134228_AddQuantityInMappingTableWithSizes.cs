using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShop.Infrastructure.Migrations
{
    public partial class AddQuantityInMappingTableWithSizes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "362474ee-46c1-40ea-869c-82381550bf94");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a95f4c0d-3465-4e62-9f3c-a42f87e98d5f");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "ShoesSizes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "ShoeSize Quantity");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "GarmentsSizes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "GarmentSize Quantity");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "87746889-978a-4eb2-86fe-cf52a52bf51e", "c90ef201-d388-40ac-ad37-d3adeaf70266", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a873d09c-bf8c-4224-ada7-bd94c611a9dc", "d96ee64f-f8b6-4a7d-aad7-d29b068c16cd", "User", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "87746889-978a-4eb2-86fe-cf52a52bf51e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a873d09c-bf8c-4224-ada7-bd94c611a9dc");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "ShoesSizes");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "GarmentsSizes");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "362474ee-46c1-40ea-869c-82381550bf94", "3b224be4-da75-4843-a89f-6d65387ac4ce", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a95f4c0d-3465-4e62-9f3c-a42f87e98d5f", "953c56a9-c24d-4214-a4d3-09a8d52a21b0", "User", null });
        }
    }
}

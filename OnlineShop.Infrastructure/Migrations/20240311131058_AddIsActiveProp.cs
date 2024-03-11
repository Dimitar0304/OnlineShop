using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShop.Infrastructure.Migrations
{
    public partial class AddIsActiveProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bfeed789-77c2-49e1-9d3a-f183f3120839");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ce1c59bd-cebe-4aa4-a102-103c855728e6");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Shoes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Orders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Garments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Accessories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "362474ee-46c1-40ea-869c-82381550bf94", "3b224be4-da75-4843-a89f-6d65387ac4ce", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a95f4c0d-3465-4e62-9f3c-a42f87e98d5f", "953c56a9-c24d-4214-a4d3-09a8d52a21b0", "User", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "362474ee-46c1-40ea-869c-82381550bf94");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a95f4c0d-3465-4e62-9f3c-a42f87e98d5f");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Shoes");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Garments");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Accessories");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bfeed789-77c2-49e1-9d3a-f183f3120839", "33a14525-dce0-4ac5-941b-800f76608fc6", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ce1c59bd-cebe-4aa4-a102-103c855728e6", "c09d88c1-5dda-4404-b836-ca20d112dad2", "User", null });
        }
    }
}

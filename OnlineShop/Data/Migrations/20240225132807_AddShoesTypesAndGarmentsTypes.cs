using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShop.Data.Migrations
{
    public partial class AddShoesTypesAndGarmentsTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3915c2bf-3fa8-4ac9-8eb7-981071a2eb83");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94398963-b704-4af2-9245-43c3dd188b3f");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ShoesTypes",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Brands",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                comment: "Brand Name",
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25,
                oldComment: "Brand Name");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2c3de53b-1af4-4671-a2db-f2810168d2b1", "a459c7b1-d51b-4af4-9d9a-152258b39238", "Admin", null },
                    { "a7bb2cee-ce63-496c-871b-67e329f00a9f", "523d2ab7-2fcd-4325-9caf-c40cd5a67b62", "User", null }
                });

            migrationBuilder.InsertData(
                table: "GarmentsTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Tshirt" },
                    { 2, "Shirt" },
                    { 3, "Leggin" },
                    { 4, "Pant" },
                    { 5, "Jacket" },
                    { 6, "Coat" }
                });

            migrationBuilder.InsertData(
                table: "ShoesTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Sneakers" },
                    { 2, "Boots" },
                    { 3, "Basketball shoes" },
                    { 4, "Football shoes" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c3de53b-1af4-4671-a2db-f2810168d2b1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a7bb2cee-ce63-496c-871b-67e329f00a9f");

            migrationBuilder.DeleteData(
                table: "GarmentsTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "GarmentsTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "GarmentsTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "GarmentsTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "GarmentsTypes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "GarmentsTypes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ShoesTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ShoesTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ShoesTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ShoesTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ShoesTypes",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Brands",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                comment: "Brand Name",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "Brand Name");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3915c2bf-3fa8-4ac9-8eb7-981071a2eb83", "87b7687f-f708-453b-8a06-dedd363fd805", "User", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "94398963-b704-4af2-9245-43c3dd188b3f", "a08949b7-dda0-4310-bc18-65933e48c11d", "Admin", null });
        }
    }
}

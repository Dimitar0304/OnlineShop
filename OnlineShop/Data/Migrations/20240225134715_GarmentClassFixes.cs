using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShop.Data.Migrations
{
    public partial class GarmentClassFixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c3de53b-1af4-4671-a2db-f2810168d2b1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a7bb2cee-ce63-496c-871b-67e329f00a9f");

            migrationBuilder.AlterColumn<int>(
                name: "TypeId",
                table: "Garments",
                type: "int",
                nullable: false,
                comment: "Garment Type identifier",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0266ebf0-f16d-46df-a511-73d7dfcaf27a", "edf49ed8-0235-4816-aa03-7696dfd6bb92", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a9070229-a0b8-4fb0-a9fe-d9f95c13fbfa", "3fdda86f-6648-450e-b6fd-62ffd19345f2", "User", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0266ebf0-f16d-46df-a511-73d7dfcaf27a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a9070229-a0b8-4fb0-a9fe-d9f95c13fbfa");

            migrationBuilder.AlterColumn<int>(
                name: "TypeId",
                table: "Garments",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Garment Type identifier");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2c3de53b-1af4-4671-a2db-f2810168d2b1", "a459c7b1-d51b-4af4-9d9a-152258b39238", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a7bb2cee-ce63-496c-871b-67e329f00a9f", "523d2ab7-2fcd-4325-9caf-c40cd5a67b62", "User", null });
        }
    }
}

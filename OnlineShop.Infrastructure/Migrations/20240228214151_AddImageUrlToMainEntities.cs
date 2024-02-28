using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShop.Infrastructure.Migrations
{
    public partial class AddImageUrlToMainEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1bd49eb5-aac9-409d-ad62-030cd6f37000");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27cb7e06-5665-4a96-b895-91ba25f768bf");

            migrationBuilder.AlterTable(
                name: "Sizes",
                comment: "Size for clothes entities",
                oldComment: "Size for clothes in shop");

            migrationBuilder.AlterTable(
                name: "ShoesSizes",
                comment: "Shoe-size data entity",
                oldComment: "Shoe-size mapping entity");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ShoesTypes",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                comment: "Shoe type name",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Shoes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Garments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Accessories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6d1e3a92-c684-478c-adf1-baf5a370c6b2", "ad2296be-5c82-4ef9-a8a5-2c38610d591c", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ebc208b0-30cb-47ba-9749-6546972bfd85", "e8b733b8-00b9-4eb9-bb3f-950a687b6a0b", "User", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6d1e3a92-c684-478c-adf1-baf5a370c6b2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ebc208b0-30cb-47ba-9749-6546972bfd85");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Shoes");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Garments");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Accessories");

            migrationBuilder.AlterTable(
                name: "Sizes",
                comment: "Size for clothes in shop",
                oldComment: "Size for clothes entities");

            migrationBuilder.AlterTable(
                name: "ShoesSizes",
                comment: "Shoe-size mapping entity",
                oldComment: "Shoe-size data entity");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ShoesTypes",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "Shoe type name");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1bd49eb5-aac9-409d-ad62-030cd6f37000", "aa509727-1b99-4058-98c3-2a29234611e7", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "27cb7e06-5665-4a96-b895-91ba25f768bf", "7f94b59a-60ff-46d8-824c-7e32d432a70a", "User", null });
        }
    }
}

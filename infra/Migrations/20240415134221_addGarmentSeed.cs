using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShop.Infrastructure.Migrations
{
    public partial class addGarmentSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "322a7bf2-124a-4ce7-bdf8-43eba64446b5",
                column: "ConcurrencyStamp",
                value: "9ab17067-6c4a-4e01-a5a8-4c3a1a7e6b82");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f05308b9-55ff-4b20-8e57-9a2b89573525",
                column: "ConcurrencyStamp",
                value: "344409b6-2e9f-4738-88e0-60c46be1a042");

            migrationBuilder.InsertData(
                table: "Garments",
                columns: new[] { "Id", "BrandId", "Color", "ImageUrl", "IsActive", "Model", "Price", "TypeId" },
                values: new object[] { 1, 3, "DarkBlue", "https://i.pinimg.com/564x/93/d7/b2/93d7b28cfb66f9daa650559600a0abd1.jpg", true, "Zip Sweatshirts", 100.00m, 7 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Garments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "322a7bf2-124a-4ce7-bdf8-43eba64446b5",
                column: "ConcurrencyStamp",
                value: "5d75c59a-213f-43b2-8884-851e61786a6f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f05308b9-55ff-4b20-8e57-9a2b89573525",
                column: "ConcurrencyStamp",
                value: "b4bd58ca-f2f8-4c34-b784-1f1a4b229de5");
        }
    }
}

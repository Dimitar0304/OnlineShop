using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShop.Infrastructure.Migrations
{
    public partial class promotionsAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Promotions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Promotion identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PromoName = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Promotion name"),
                    PromoCode = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Promotion code"),
                    PromotionProcentage = table.Column<int>(type: "int", nullable: false, comment: "Promotion procentage")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promotions", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "322a7bf2-124a-4ce7-bdf8-43eba64446b5",
                column: "ConcurrencyStamp",
                value: "a2d4cdc7-6141-4b8a-b332-668a6c66b457");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f05308b9-55ff-4b20-8e57-9a2b89573525",
                column: "ConcurrencyStamp",
                value: "8289bf2d-d0bc-4937-a8a9-06fc5545f10b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "250f8800-ede3-4210-a8d0-8a0353a67e24",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegistrationDate", "SecurityStamp" },
                values: new object[] { "c4a05f10-189f-42c0-9d9b-0627ba41b1f9", "AQAAAAEAACcQAAAAEJdhVr1YhHUVKN4YHf5ivpIvBPI4hRUFgfoDRGRwGefWyBdZ/U2OCuBNVT+PXoqgiA==", new DateTime(2024, 5, 25, 18, 13, 21, 166, DateTimeKind.Local).AddTicks(4163), "a9c613fd-01a8-4448-a08b-806b2ffd2617" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bb77b48a-3afa-4050-8b2e-1847bbe5413b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegistrationDate", "SecurityStamp" },
                values: new object[] { "86abe4a4-0469-44f3-b83b-034376ed86d2", "AQAAAAEAACcQAAAAEPSU4GOx6cwVd6V65RtJrP8xBlVKfGkIAdt/9lv1k3w+Eh3ABw5M/ceZAKIjUQJXkg==", new DateTime(2024, 5, 25, 18, 13, 21, 164, DateTimeKind.Local).AddTicks(8759), "0ca2ded5-6a82-44ef-a363-58b547b4eb17" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Promotions");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "322a7bf2-124a-4ce7-bdf8-43eba64446b5",
                column: "ConcurrencyStamp",
                value: "b37886a6-2e7b-491d-92dd-bc409566a655");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f05308b9-55ff-4b20-8e57-9a2b89573525",
                column: "ConcurrencyStamp",
                value: "6d64c409-7334-43fc-93a0-3d8178a6666e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "250f8800-ede3-4210-a8d0-8a0353a67e24",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegistrationDate", "SecurityStamp" },
                values: new object[] { "273bcc51-958b-4261-81aa-6ed4b9c9e26c", "AQAAAAEAACcQAAAAEIYsrhi2VPfmbX+NnWTcZ+LQARJFVIYKMRiFqol86l7MxJ8C0dLq2RzIWFogW4YNnw==", new DateTime(2024, 4, 25, 0, 34, 18, 52, DateTimeKind.Local).AddTicks(3486), "5300dc8c-b22e-45a6-a823-2a772aadf1ea" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bb77b48a-3afa-4050-8b2e-1847bbe5413b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegistrationDate", "SecurityStamp" },
                values: new object[] { "a9a820d3-68d5-43b3-a438-44d66cf52d5c", "AQAAAAEAACcQAAAAEAw5U3w9GMCLIs+5U3ihiMHNkCanP/dq1EHezMH0CBBsmUeacqaOhZnmcujHRG5Xkw==", new DateTime(2024, 4, 25, 0, 34, 18, 50, DateTimeKind.Local).AddTicks(9792), "d3c81a33-36c2-491f-9ccc-11007ffaf383" });
        }
    }
}

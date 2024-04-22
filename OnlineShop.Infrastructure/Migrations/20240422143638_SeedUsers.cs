using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShop.Infrastructure.Migrations
{
    public partial class SeedUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "322a7bf2-124a-4ce7-bdf8-43eba64446b5",
                column: "ConcurrencyStamp",
                value: "6aee476c-07c6-4f89-a6f9-e4c604d25705");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f05308b9-55ff-4b20-8e57-9a2b89573525",
                column: "ConcurrencyStamp",
                value: "500c941c-5ff1-4c45-88eb-63c4e48c323c");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RegistrationDate", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "250f8800-ede3-4210-a8d0-8a0353a67e24", 0, "7632a229-2583-4765-ba6e-c445abb7e5f2", "JustAdmin@mail.com", true, "Just", "Admin4e", false, null, "JUSTADMIN@mail.com", "JUSTADMIN4E", "AQAAAAEAACcQAAAAEN0j7w0Uc/ZYYUnu4pvuGtq3snUS1JFXvyItMbGdZyBDQRnOFG/9i5ZPdAtft5wGzg==", null, false, new DateTime(2024, 4, 22, 17, 36, 37, 397, DateTimeKind.Local).AddTicks(1221), "172b9f4d-f4ee-4f42-a658-04e584742a0f", false, "JustAdmin4e" },
                    { "bb77b48a-3afa-4050-8b2e-1847bbe5413b", 0, "be409ee6-7ef8-4412-a652-d0b8b0671c0c", "JustUser@mail.com", true, "Just", "User4e", false, null, "JUSTUSER@mail.com", "JUSTUSER4E", "AQAAAAEAACcQAAAAEJCNYNJIybIiuphs/SOer0MMRS8kBy8sjZpnhmYic/KtZ90AfOH830hboLANHJOrqg==", null, false, new DateTime(2024, 4, 22, 17, 36, 37, 395, DateTimeKind.Local).AddTicks(4794), "92b53c6e-59a9-4da4-af23-f57efb80d4d4", false, "JustUser4e" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "250f8800-ede3-4210-a8d0-8a0353a67e24");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bb77b48a-3afa-4050-8b2e-1847bbe5413b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "322a7bf2-124a-4ce7-bdf8-43eba64446b5",
                column: "ConcurrencyStamp",
                value: "34c0fce0-db77-42b0-995e-7c3570889786");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f05308b9-55ff-4b20-8e57-9a2b89573525",
                column: "ConcurrencyStamp",
                value: "6a840e70-751f-44a2-bde7-1a9203bd2fbf");
        }
    }
}

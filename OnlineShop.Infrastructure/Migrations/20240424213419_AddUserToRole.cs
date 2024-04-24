using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShop.Infrastructure.Migrations
{
    public partial class AddUserToRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "f05308b9-55ff-4b20-8e57-9a2b89573525", "250f8800-ede3-4210-a8d0-8a0353a67e24" });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f05308b9-55ff-4b20-8e57-9a2b89573525", "250f8800-ede3-4210-a8d0-8a0353a67e24" });

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

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "250f8800-ede3-4210-a8d0-8a0353a67e24",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegistrationDate", "SecurityStamp" },
                values: new object[] { "7632a229-2583-4765-ba6e-c445abb7e5f2", "AQAAAAEAACcQAAAAEN0j7w0Uc/ZYYUnu4pvuGtq3snUS1JFXvyItMbGdZyBDQRnOFG/9i5ZPdAtft5wGzg==", new DateTime(2024, 4, 22, 17, 36, 37, 397, DateTimeKind.Local).AddTicks(1221), "172b9f4d-f4ee-4f42-a658-04e584742a0f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bb77b48a-3afa-4050-8b2e-1847bbe5413b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegistrationDate", "SecurityStamp" },
                values: new object[] { "be409ee6-7ef8-4412-a652-d0b8b0671c0c", "AQAAAAEAACcQAAAAEJCNYNJIybIiuphs/SOer0MMRS8kBy8sjZpnhmYic/KtZ90AfOH830hboLANHJOrqg==", new DateTime(2024, 4, 22, 17, 36, 37, 395, DateTimeKind.Local).AddTicks(4794), "92b53c6e-59a9-4da4-af23-f57efb80d4d4" });
        }
    }
}

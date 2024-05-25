using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShop.Infrastructure.Migrations
{
    public partial class promotionsAd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "322a7bf2-124a-4ce7-bdf8-43eba64446b5",
                column: "ConcurrencyStamp",
                value: "35b47de4-aee1-4bbb-a746-1dc1b5bf3335");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f05308b9-55ff-4b20-8e57-9a2b89573525",
                column: "ConcurrencyStamp",
                value: "588ba79e-b846-444c-916b-666ad26f54f6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "250f8800-ede3-4210-a8d0-8a0353a67e24",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegistrationDate", "SecurityStamp" },
                values: new object[] { "14c7df5d-40f6-4258-b742-8032e4fad1e7", "AQAAAAEAACcQAAAAEP95o5vx9glWgQENzvHxsCaMDZ0pdsvKMFDf9iVce5WjZOJz8g5PcbMW3Us4tKaXug==", new DateTime(2024, 5, 25, 18, 20, 53, 820, DateTimeKind.Local).AddTicks(4947), "4151ebd4-d5e6-4d83-82f5-df6393c60682" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bb77b48a-3afa-4050-8b2e-1847bbe5413b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegistrationDate", "SecurityStamp" },
                values: new object[] { "2a5276ad-b692-4ece-9228-317471318a52", "AQAAAAEAACcQAAAAEByIVmpWcP2yULjsSgDa+41ilupwXYVDrDMFpm/0UbLjgTl0gyhUieYb7EQ9Fx581w==", new DateTime(2024, 5, 25, 18, 20, 53, 818, DateTimeKind.Local).AddTicks(9509), "7c97e957-9afe-4316-a925-ec0eb686728c" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}

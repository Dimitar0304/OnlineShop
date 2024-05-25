using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShop.Infrastructure.Migrations
{
    public partial class promotions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "322a7bf2-124a-4ce7-bdf8-43eba64446b5",
                column: "ConcurrencyStamp",
                value: "b3788676-40de-4511-a51b-e4f40953ab60");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f05308b9-55ff-4b20-8e57-9a2b89573525",
                column: "ConcurrencyStamp",
                value: "962f860d-5335-4e59-83bd-58253f089322");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "250f8800-ede3-4210-a8d0-8a0353a67e24",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegistrationDate", "SecurityStamp" },
                values: new object[] { "5689d6b7-03e9-477d-952a-a45cc06aa38f", "AQAAAAEAACcQAAAAEJ4ctL8fY0zR0O4XMEPZZQSx3TD8kFJaCrnE6/dm6yubETE+nktXJY6ntoNlBQWhew==", new DateTime(2024, 5, 25, 18, 26, 38, 309, DateTimeKind.Local).AddTicks(9311), "b693cf9d-bd4a-4271-a270-fa56042a2a44" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bb77b48a-3afa-4050-8b2e-1847bbe5413b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegistrationDate", "SecurityStamp" },
                values: new object[] { "5728d4a6-d1be-4ca5-81e6-d3bcb846f7e2", "AQAAAAEAACcQAAAAELSOyDiMk4sJBHt49GQ+C40M0mQZ4ADPq7ARjnKVRZpMfCbPaF5GAT29Vufjh8+/aQ==", new DateTime(2024, 5, 25, 18, 26, 38, 308, DateTimeKind.Local).AddTicks(2985), "4e0f1cbc-cdc7-4dc7-ba58-f339d418efc8" });

            migrationBuilder.InsertData(
                table: "Promotions",
                columns: new[] { "Id", "PromoCode", "PromoName", "PromotionProcentage" },
                values: new object[,]
                {
                    { 1, "Christ", "Christmas Promotion", 15 },
                    { 2, "Spring", "Spring Promotion", 15 },
                    { 3, "summer", "Summer Promotion", 20 },
                    { 4, "winter", "Winter Promotion", 13 },
                    { 5, "25M", "25th of May", 15 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 5);

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
    }
}

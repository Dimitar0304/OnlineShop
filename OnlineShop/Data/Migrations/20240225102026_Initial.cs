using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShop.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Brand identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false, comment: "Brand Name")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                },
                comment: "Brand data entity");

            migrationBuilder.CreateTable(
                name: "GarmentsTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Garment type identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false, comment: "Garment type name")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GarmentsTypes", x => x.Id);
                },
                comment: "Garment type entity");

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Order identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pice = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Order Price"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Order user identifier"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false, comment: "Order phone number"),
                    Address = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Order Address")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Order data entity");

            migrationBuilder.CreateTable(
                name: "ShoesTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Shoe type identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoesTypes", x => x.Id);
                },
                comment: "Shoe type entity");

            migrationBuilder.CreateTable(
                name: "Sizes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Size identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false, comment: "Size Name")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.Id);
                },
                comment: "Size for clothes in shop");

            migrationBuilder.CreateTable(
                name: "Accessories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Accessory identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false, comment: "Accessory Name"),
                    Type = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false, comment: "Accessory Type"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Accessory Price"),
                    BrandId = table.Column<int>(type: "int", nullable: false, comment: "Accessory brand identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accessories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accessories_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Accessory data entity");

            migrationBuilder.CreateTable(
                name: "Garments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Garment identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false, comment: "Garment Name"),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: false, comment: "Garment Brand identifier"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Garment price"),
                    Color = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false, comment: "Color")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Garments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Garments_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Garments_GarmentsTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "GarmentsTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Garment data entity");

            migrationBuilder.CreateTable(
                name: "UsersOrders",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "User identifier"),
                    OrderId = table.Column<int>(type: "int", nullable: false, comment: "Order identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersOrders", x => new { x.OrderId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UsersOrders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersOrders_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "User order entity");

            migrationBuilder.CreateTable(
                name: "Shoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Shoe identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false, comment: "Shoe Model"),
                    TypeId = table.Column<int>(type: "int", nullable: false, comment: "Shoe type identifier"),
                    BrandId = table.Column<int>(type: "int", nullable: false, comment: "Shoe brand identifier"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Shoe price"),
                    Color = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false, comment: "Shoe color")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shoes_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shoes_ShoesTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "ShoesTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Shoe data entity");

            migrationBuilder.CreateTable(
                name: "GarmentsSizes",
                columns: table => new
                {
                    GarmentId = table.Column<int>(type: "int", nullable: false, comment: "Garment identifier"),
                    SizeId = table.Column<int>(type: "int", nullable: false, comment: "Size identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GarmentsSizes", x => new { x.GarmentId, x.SizeId });
                    table.ForeignKey(
                        name: "FK_GarmentsSizes_Garments_GarmentId",
                        column: x => x.GarmentId,
                        principalTable: "Garments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GarmentsSizes_Sizes_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Sizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Garment-size entity");

            migrationBuilder.CreateTable(
                name: "ShoesSizes",
                columns: table => new
                {
                    ShoeId = table.Column<int>(type: "int", nullable: false, comment: "Shoe identifier"),
                    Size = table.Column<int>(type: "int", nullable: false, comment: "Shoe size")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoesSizes", x => new { x.ShoeId, x.Size });
                    table.ForeignKey(
                        name: "FK_ShoesSizes_Shoes_ShoeId",
                        column: x => x.ShoeId,
                        principalTable: "Shoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Shoe-size mapping entity");

            migrationBuilder.CreateIndex(
                name: "IX_Accessories_BrandId",
                table: "Accessories",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Garments_BrandId",
                table: "Garments",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Garments_TypeId",
                table: "Garments",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_GarmentsSizes_SizeId",
                table: "GarmentsSizes",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Shoes_BrandId",
                table: "Shoes",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Shoes_TypeId",
                table: "Shoes",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersOrders_UserId",
                table: "UsersOrders",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accessories");

            migrationBuilder.DropTable(
                name: "GarmentsSizes");

            migrationBuilder.DropTable(
                name: "ShoesSizes");

            migrationBuilder.DropTable(
                name: "UsersOrders");

            migrationBuilder.DropTable(
                name: "Garments");

            migrationBuilder.DropTable(
                name: "Sizes");

            migrationBuilder.DropTable(
                name: "Shoes");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "GarmentsTypes");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "ShoesTypes");
        }
    }
}

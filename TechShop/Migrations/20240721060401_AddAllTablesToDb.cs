using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TechShop.Migrations
{
    /// <inheritdoc />
    public partial class AddAllTablesToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    BrandId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.BrandId);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethods",
                columns: table => new
                {
                    PaymentMethodId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MethodName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethods", x => x.PaymentMethodId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    role = table.Column<bool>(type: "bit", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StockQuantity = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 10000, nullable: false),
                    Img = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    BrandOfProductsBrandId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Branches_BrandOfProductsBrandId",
                        column: x => x.BrandOfProductsBrandId,
                        principalTable: "Branches",
                        principalColumn: "BrandId");
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentMethodId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_PaymentMethods_PaymentMethodId",
                        column: x => x.PaymentMethodId,
                        principalTable: "PaymentMethods",
                        principalColumn: "PaymentMethodId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetailsOrders",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailsOrders", x => new { x.ProductId, x.OrderId });
                    table.ForeignKey(
                        name: "FK_DetailsOrders_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetailsOrders_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "BrandId", "BrandName" },
                values: new object[,]
                {
                    { 1, "Lenovo" },
                    { 2, "Samsung" },
                    { 3, "MSI" },
                    { 4, "Apple" },
                    { 5, "Intel" },
                    { 6, "Dell" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName", "Description" },
                values: new object[,]
                {
                    { 1, "Laptop văn phòng", "Là sản phẩm bán chạy nhất của chúng tôi" },
                    { 2, "Laptop Gaming", "Máy có cấu hình mạnh đáp ứng nhu cầu chơi game" },
                    { 3, "Laptop đồ họa", "Máy có cấu hình mạnh đáp ứng nhu cầu thiết kế đồ họa" },
                    { 4, "Laptop cao cấp", "Máy có cấu thiết kế mỏng nhẹ" },
                    { 5, "Surface", "Surface phụ vụ cho công việc, học tập" }
                });

            migrationBuilder.InsertData(
                table: "PaymentMethods",
                columns: new[] { "PaymentMethodId", "MethodName" },
                values: new object[,]
                {
                    { 1, "Thanh toán tại cửa hàng" },
                    { 2, "Thanh toán khi nhận hàng" },
                    { 3, "Thanh toán bằng chuyển khoản ngân hàng" },
                    { 4, "Thanh toán trả góp" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "OrderDate", "PaymentMethodId", "Status", "TotalAmount" },
                values: new object[] { 1, new DateTime(2024, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Đã xác nhận", 1m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "BrandId", "BrandOfProductsBrandId", "CategoryId", "Description", "Img", "Price", "ProductName", "StockQuantity" },
                values: new object[] { 1, 1, null, 1, "Legion Y7000P 2024 là một chiếc Laptop hứa hẹn là một trong những sự lựa chọn tuyệt vời bởi thiết kế độc đáo, cá tính cùng với hiệu năng và những thông số kĩ thuật ấn tượng. Vậy nên đừng ngần ngại lựa chọn mua Legion Y7000P 2024 tại hệ thống của hàng của LaptopAZ.vn để được trải nghiệm sự tuyệt vời của chiếc Laptop này đem lại.", "https://laptopaz.vn/media/product/3174_", 21490000m, "Lenovo Thinkbook 16 G6+ 2024", 100 });

            migrationBuilder.InsertData(
                table: "DetailsOrders",
                columns: new[] { "OrderId", "ProductId", "Quantity" },
                values: new object[] { 1, 1, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_DetailsOrders_OrderId",
                table: "DetailsOrders",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PaymentMethodId",
                table: "Orders",
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandOfProductsBrandId",
                table: "Products",
                column: "BrandOfProductsBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetailsOrders");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "PaymentMethods");

            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}

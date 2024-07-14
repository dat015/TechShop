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
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
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
                    Branch = table.Column<string>(type: "nvarchar(max)", maxLength: 10000, nullable: false),
                    StockQuantity = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 10000, nullable: false),
                    Img = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
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
                columns: new[] { "ProductId", "Branch", "CategoryId", "Description", "Img", "Price", "ProductName", "StockQuantity" },
                values: new object[,]
                {
                    { 1, "Lenovo", 1, "Legion Y7000P 2024 là một chiếc Laptop hứa hẹn là một trong những sự lựa chọn tuyệt vời bởi thiết kế độc đáo, cá tính cùng với hiệu năng và những thông số kĩ thuật ấn tượng. Vậy nên đừng ngần ngại lựa chọn mua Legion Y7000P 2024 tại hệ thống của hàng của LaptopAZ.vn để được trải nghiệm sự tuyệt vời của chiếc Laptop này đem lại.", "https://laptopaz.vn/media/product/3174_", 21490000m, "Lenovo Thinkbook 16 G6+ 2024", 100 },
                    { 2, "Lenovo", 2, "Laptop Lenovo ThinkBook 16 G6+ với hiệu năng mạnh mẽ cùng thiết kế thanh lịch, là sự lựa chọn phù hợp cho hầu hết tất cả mọi người", "https://laptopaz.vn/media/product/3174_", 29890000m, "Lenovo Legion Y7000P ", 100 },
                    { 3, "Lenovo", 2, "mẫu laptop cao cấp của nhà Acer đã và đem lại những trải nghiệm tuyệt vời, cùng với những ưu điểm vượt trội", "https://laptopaz.vn/media/product/2947_helios_neo_2023.jpg", 29890000m, "Lenovo Legion 5 R7000 APH9", 100 },
                    { 4, "Dell", 4, " Laptop Dell Inspiron 14 5430 là một chiếc laptop thiết kế sang trọng, gọn nhẹ, màn hình chất lượng đi kèm hiệu năng mạnh mẽ", "https://laptopaz.vn/media/product/2757_laptopaz_5430_chinh.png", 15990000m, "Dell Inspiron 14 5430", 100 },
                    { 5, "Lenovo", 4, "Legion Y7000P 2024 là một chiếc Laptop hứa hẹn là một trong những sự lựa chọn tuyệt vời bởi thiết kế độc đáo, cá tính cùng với hiệu năng và những thông số kĩ thuật ấn tượng. Vậy nên đừng ngần ngại lựa chọn mua Legion Y7000P 2024 tại hệ thống của hàng của LaptopAZ.vn để được trải nghiệm sự tuyệt vời của chiếc Laptop này đem lại.", "https://laptopaz.vn/media/product/3239_lenovo_thinkbook_16_g7_2024.jpg", 21890000m, " Lenovo Thinkbook 16 G7 2024", 100 },
                    { 6, "Surface", 5, "hiệu năng mạnh mẽ cùng thiết kế thanh lịch, là sự lựa chọn phù hợp", "https://laptopaz.vn/media/product/2556_surface_book_3_core_i7_32gb_1tb_15_inch_newseal_1601018373.jpg", 29890000m, "Surface Book 3", 100 }
                });

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
                name: "Categories");
        }
    }
}

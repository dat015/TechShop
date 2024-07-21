using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TechShop.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBrand : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Branches_BrandOfProductsBrandId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropIndex(
                name: "IX_Products_BrandOfProductsBrandId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "BrandOfProductsBrandId",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    BrandId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.BrandId);
                });

            migrationBuilder.InsertData(
                table: "Brands",
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

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                column: "BrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Brands_BrandId",
                table: "Products",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "BrandId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Brands_BrandId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropIndex(
                name: "IX_Products_BrandId",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "BrandOfProductsBrandId",
                table: "Products",
                type: "int",
                nullable: true);

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

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "BrandOfProductsBrandId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandOfProductsBrandId",
                table: "Products",
                column: "BrandOfProductsBrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Branches_BrandOfProductsBrandId",
                table: "Products",
                column: "BrandOfProductsBrandId",
                principalTable: "Branches",
                principalColumn: "BrandId");
        }
    }
}

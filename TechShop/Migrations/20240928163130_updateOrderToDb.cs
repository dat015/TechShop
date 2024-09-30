using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechShop.Migrations
{
    /// <inheritdoc />
    public partial class updateOrderToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Orders",
                newName: "StatusShipping");

            migrationBuilder.AddColumn<string>(
                name: "StatusPayment",
                table: "Orders",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatusPayment",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "StatusShipping",
                table: "Orders",
                newName: "Status");
        }
    }
}

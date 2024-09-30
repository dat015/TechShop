using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechShop.Migrations
{
    /// <inheritdoc />
    public partial class addOrderToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "PaymentDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 1
                );

            migrationBuilder.AddColumn<string>(
                name: "address",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue : ""

                );

            migrationBuilder.AddColumn<string>(
                name: "distrcit",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue : ""
                );

            migrationBuilder.AddColumn<string>(
                name: "phoneNumber",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "provice",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ward",
                table: "Orders",
                type: "nvarchar(max)",
                 nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "UnitPrice",
                table: "DetailsOrders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "DetailsOrders",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 1, 1 },
                column: "UnitPrice",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1,
                columns: new[] { "Name", "PaymentDate", "UserId", "address", "distrcit", "phoneNumber", "provice", "ward" },
                values: new object[] { null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, null, null, null });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_User_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_User_UserId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_UserId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PaymentDate",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "address",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "distrcit",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "phoneNumber",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "provice",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ward",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "UnitPrice",
                table: "DetailsOrders");

        
        }
    }
}

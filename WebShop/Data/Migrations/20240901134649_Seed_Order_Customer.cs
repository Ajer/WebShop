using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebShop.Data.Migrations
{
    /// <inheritdoc />
    public partial class Seed_Order_Customer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "City", "Country", "Email", "FirstName", "LastName", "Zip" },
                values: new object[] { 1, "Stadsborgaregatan 97", "Örebro", "Sweden", "gunnar@example.com", "Gunnar", "Appelkvist", "21192" });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CustomerId", "FreightCost", "OrderDate", "PaymentOption", "TotOrderCost" },
                values: new object[] { 1, 1, 49.0, new DateTime(2024, 9, 1, 15, 46, 48, 459, DateTimeKind.Local).AddTicks(6694), "Invoice 30 days", 10549.0 });

            migrationBuilder.InsertData(
                table: "OrderCartLines",
                columns: new[] { "Id", "OrderId", "ProdId", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 2, 1 },
                    { 2, 1, 15, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrderCartLines",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrderCartLines",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}

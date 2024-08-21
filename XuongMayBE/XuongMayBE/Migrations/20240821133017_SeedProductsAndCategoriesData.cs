using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XuongMayBE.Migrations
{
    public partial class SeedProductsAndCategoriesData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {          
            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Clothing" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Accessories" });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "CategoryID", "Description", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, "Cotton T-Shirt", "T-Shirt", 19.989999999999998, 50 },
                    { 2, 1, "Denim Jeans", "Jeans", 49.990000000000002, 30 },
                    { 3, 2, "Baseball Cap", "Hat", 15.99, 100 },
                    { 4, 1, "Leather Jacket", "Jacket", 89.989999999999995, 20 },
                    { 5, 1, "Woolen Socks", "Socks", 5.9900000000000002, 150 },
                    { 6, 2, "Silk Scarf", "Scarf", 25.989999999999998, 80 },
                    { 7, 2, "Winter Gloves", "Gloves", 12.99, 70 },
                    { 8, 1, "Woolen Sweater", "Sweater", 35.990000000000002, 40 },
                    { 9, 2, "Leather Belt", "Belt", 29.989999999999998, 60 },
                    { 10, 2, "Running Shoes", "Shoes", 59.990000000000002, 25 },
                    { 11, 1, "Casual Shorts", "Shorts", 19.989999999999998, 90 },
                    { 12, 2, "Snapback Cap", "Cap", 15.99, 110 },
                    { 13, 1, "Evening Dress", "Dress", 99.989999999999995, 15 },
                    { 14, 1, "Silk Blouse", "Blouse", 39.990000000000002, 50 },
                    { 15, 2, "Analog Watch", "Watch", 199.99000000000001, 10 },
                    { 16, 2, "Polarized Sunglasses", "Sunglasses", 49.990000000000002, 60 },
                    { 17, 2, "Silk Tie", "Tie", 25.989999999999998, 100 },
                    { 18, 2, "Travel Backpack", "Backpack", 79.989999999999995, 20 },
                    { 19, 1, "Business Suit", "Suit", 249.99000000000001, 15 },
                    { 20, 1, "Cotton Polo Shirt", "Polo Shirt", 29.989999999999998, 40 },
                    { 21, 2, "Casual Sneakers", "Sneakers", 69.989999999999995, 30 },
                    { 22, 1, "Cotton Joggers", "Joggers", 39.990000000000002, 70 },
                    { 23, 2, "Leather Wallet", "Wallet", 39.990000000000002, 80 },
                    { 24, 2, "Beach Sandals", "Sandals", 19.989999999999998, 50 },
                    { 25, 2, "Winter Beanie", "Beanie", 12.99, 100 }
                });

           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2);

           
        }
    }
}

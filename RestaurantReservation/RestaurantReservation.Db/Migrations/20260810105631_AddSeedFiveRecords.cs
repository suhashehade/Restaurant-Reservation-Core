using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedFiveRecords : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "tariq@example.com", "Tariq", "Ziyad", "0569111111" },
                    { 2, "yara@example.com", "Yara", "Ali", "0569222222" },
                    { 3, "fadi@example.com", "Fadi", "Saleh", "0569333333" },
                    { 4, "mona@example.com", "Mona", "Ibrahim", "0569444444" },
                    { 5, "zaid@example.com", "Zaid", "Qasim", "0569555555" }
                });

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "RestaurantId", "Address", "Name", "OpeningHours", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Downtown St 10", "La Bella Italia", "08:00 AM - 11:00 PM", "0599111111" },
                    { 2, "Main Street 45", "Sultan Shawarma", "10:00 AM - 02:00 AM", "0599222222" },
                    { 3, "University Rd 12", "Burger Factory", "11:00 AM - 12:00 AM", "0599333333" },
                    { 4, "Beach Avenue 5", "Seafood Haven", "01:00 PM - 11:30 PM", "0599444444" },
                    { 5, "Old City 88", "Al-Quds Traditional", "07:00 AM - 10:00 PM", "0599555555" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "FirstName", "LastName", "Position", "RestaurantId" },
                values: new object[,]
                {
                    { 1, "Ahmad", "Al-Sayed", "Manager", 1 },
                    { 2, "Sami", "Shadi", "Waiter", 1 },
                    { 3, "Omar", "Nasser", "Manager", 2 },
                    { 4, "Laila", "Hassan", "Chef", 3 },
                    { 5, "Khaled", "Mansour", "Waiter", 4 }
                });

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "MenuItemId", "Description", "Name", "Price", "RestaurantId" },
                values: new object[,]
                {
                    { 1, "Classic cheese pizza", "Margherita Pizza", 12.50m, 1 },
                    { 2, "Creamy sauce pasta", "Pasta Carbonara", 15.00m, 1 },
                    { 3, "Beef shawarma with fries", "Super Shawarma Plate", 10.00m, 2 },
                    { 4, "Beef burger with extra cheese", "Double Cheese Burger", 11.00m, 3 },
                    { 5, "Fresh salmon with lemon butter", "Grilled Salmon", 25.00m, 4 }
                });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "TableId", "Capacity", "RestaurantId" },
                values: new object[,]
                {
                    { 1, 4, 1 },
                    { 2, 6, 1 },
                    { 3, 2, 2 },
                    { 4, 8, 3 },
                    { 5, 4, 4 }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "ReservationId", "CustomerId", "PartySize", "ReservationDate", "RestaurantId", "TableId" },
                values: new object[,]
                {
                    { 1, 1, 4, new DateTime(2026, 8, 15, 19, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 2, 1, 6, new DateTime(2026, 8, 20, 20, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { 3, 2, 2, new DateTime(2026, 8, 16, 13, 0, 0, 0, DateTimeKind.Unspecified), 2, 3 },
                    { 4, 3, 8, new DateTime(2026, 8, 18, 18, 30, 0, 0, DateTimeKind.Unspecified), 3, 4 },
                    { 5, 4, 3, new DateTime(2026, 8, 19, 21, 0, 0, 0, DateTimeKind.Unspecified), 4, 5 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "EmployeeId", "OrderDate", "ReservationId", "TotalAmount" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2026, 8, 15, 19, 15, 0, 0, DateTimeKind.Unspecified), 1, 40.00m },
                    { 2, 1, new DateTime(2026, 8, 15, 20, 0, 0, 0, DateTimeKind.Unspecified), 1, 15.00m },
                    { 3, 2, new DateTime(2026, 8, 20, 20, 15, 0, 0, DateTimeKind.Unspecified), 2, 60.00m },
                    { 4, 3, new DateTime(2026, 8, 16, 13, 20, 0, 0, DateTimeKind.Unspecified), 3, 20.00m },
                    { 5, 4, new DateTime(2026, 8, 18, 19, 0, 0, 0, DateTimeKind.Unspecified), 4, 88.00m }
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "OrderItemId", "ItemId", "OrderId", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 1, 2 },
                    { 2, 2, 1, 1 },
                    { 3, 2, 2, 1 },
                    { 4, 3, 3, 2 },
                    { 5, 4, 5, 8 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "RestaurantId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "RestaurantId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "RestaurantId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "RestaurantId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "RestaurantId",
                keyValue: 3);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RailwayProject.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Fares",
                columns: new[] { "Id", "DistanceRange", "Price", "RouteId", "TypeOfClass", "TypeOfTrain" },
                values: new object[,]
                {
                    { 1, 12000, 500000, 1, "AC1", "SF" },
                    { 2, 12000, 300000, 1, "AC2", "SF" },
                    { 3, 12000, 200000, 1, "AC3", "SF" },
                    { 4, 12000, 100000, 1, "SL", "SF" },
                    { 5, 12000, 50000, 1, "GE", "SF" },
                    { 6, 12000, 400000, 1, "AC1", "F" },
                    { 7, 12000, 200000, 1, "AC2", "F" },
                    { 8, 12000, 150000, 1, "AC3", "F" },
                    { 9, 12000, 80000, 1, "SL", "F" },
                    { 10, 12000, 40000, 1, "GE", "F" },
                    { 11, 12000, 360000, 1, "AC1", "S" },
                    { 12, 12000, 180000, 1, "AC2", "S" },
                    { 13, 12000, 120000, 1, "AC3", "S" },
                    { 14, 12000, 60000, 1, "SL", "S" },
                    { 15, 12000, 30000, 1, "GE", "S" },
                    { 16, 18000, 550000, 2, "AC1", "SF" },
                    { 17, 18000, 350000, 2, "AC2", "SF" },
                    { 18, 18000, 250000, 2, "AC3", "SF" },
                    { 19, 18000, 150000, 2, "SL", "SF" },
                    { 20, 18000, 55000, 2, "GE", "SF" },
                    { 21, 18000, 450000, 2, "AC1", "F" },
                    { 22, 18000, 250000, 2, "AC2", "F" },
                    { 23, 18000, 200000, 2, "AC3", "F" },
                    { 24, 18000, 85000, 2, "SL", "F" },
                    { 25, 18000, 45000, 2, "GE", "F" },
                    { 26, 18000, 390000, 2, "AC1", "S" },
                    { 27, 18000, 200000, 2, "AC2", "S" },
                    { 28, 18000, 160000, 2, "AC3", "S" },
                    { 29, 18000, 65000, 2, "SL", "S" },
                    { 30, 18000, 35000, 2, "GE", "S" },
                    { 31, 12000, 500000, 3, "AC1", "SF" },
                    { 32, 12000, 300000, 3, "AC2", "SF" },
                    { 33, 12000, 200000, 3, "AC3", "SF" },
                    { 34, 12000, 100000, 3, "SL", "SF" },
                    { 35, 12000, 50000, 3, "GE", "SF" },
                    { 36, 12000, 400000, 3, "AC1", "F" },
                    { 37, 12000, 200000, 3, "AC2", "F" },
                    { 38, 12000, 150000, 3, "AC3", "F" },
                    { 39, 12000, 80000, 3, "SL", "F" },
                    { 40, 12000, 40000, 3, "GE", "F" },
                    { 41, 12000, 360000, 3, "AC1", "S" },
                    { 42, 12000, 180000, 3, "AC2", "S" },
                    { 43, 12000, 120000, 3, "AC3", "S" },
                    { 44, 12000, 60000, 3, "SL", "S" },
                    { 45, 12000, 30000, 3, "GE", "S" },
                    { 46, 18000, 550000, 4, "AC1", "SF" },
                    { 47, 18000, 350000, 4, "AC2", "SF" },
                    { 48, 18000, 250000, 4, "AC3", "SF" },
                    { 49, 18000, 150000, 4, "SL", "SF" },
                    { 50, 18000, 55000, 4, "GE", "SF" },
                    { 51, 18000, 450000, 4, "AC1", "F" },
                    { 52, 18000, 250000, 4, "AC2", "F" },
                    { 53, 18000, 200000, 4, "AC3", "F" },
                    { 54, 18000, 85000, 4, "SL", "F" },
                    { 55, 18000, 45000, 4, "GE", "F" },
                    { 56, 18000, 390000, 4, "AC1", "S" },
                    { 57, 18000, 200000, 4, "AC2", "S" },
                    { 58, 18000, 160000, 4, "AC3", "S" },
                    { 59, 18000, 65000, 4, "SL", "S" },
                    { 60, 18000, 35000, 4, "GE", "S" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Fares",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Fares",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Fares",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Fares",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Fares",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Fares",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Fares",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Fares",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Fares",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Fares",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Fares",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Fares",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Fares",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Fares",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Fares",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Fares",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Fares",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Fares",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Fares",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Fares",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Fares",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Fares",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Fares",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Fares",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Fares",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Fares",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Fares",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Fares",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Fares",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Fares",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Fares",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Fares",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Fares",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Fares",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Fares",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Fares",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Fares",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Fares",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Fares",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Fares",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Fares",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Fares",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Fares",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Fares",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Fares",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Fares",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Fares",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Fares",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Fares",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Fares",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Fares",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Fares",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Fares",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Fares",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Fares",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Fares",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Fares",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Fares",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Fares",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Fares",
                keyColumn: "Id",
                keyValue: 60);
        }
    }
}

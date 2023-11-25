using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RailwayProject.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StationCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameOfDivision = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Zone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCode = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trains",
                columns: table => new
                {
                    TrainCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsRunning = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trains", x => x.TrainCode);
                });

            migrationBuilder.CreateTable(
                name: "Routes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartStationId = table.Column<int>(type: "int", nullable: false),
                    EndStationId = table.Column<int>(type: "int", nullable: false),
                    Distance = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Routes_Stations_EndStationId",
                        column: x => x.EndStationId,
                        principalTable: "Stations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Routes_Stations_StartStationId",
                        column: x => x.StartStationId,
                        principalTable: "Stations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoOfCompartment = table.Column<int>(type: "int", nullable: false),
                    NoOfSeat = table.Column<int>(type: "int", nullable: false),
                    SeatAvailable = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Classes_Trains_TrainCode",
                        column: x => x.TrainCode,
                        principalTable: "Trains",
                        principalColumn: "TrainCode",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Fares",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RouteId = table.Column<int>(type: "int", nullable: false),
                    DistanceRange = table.Column<int>(type: "int", nullable: false),
                    TypeOfClass = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeOfTrain = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fares", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fares_Routes_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Routes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "RouteDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartureStationId = table.Column<int>(type: "int", nullable: false),
                    ArrivalStationId = table.Column<int>(type: "int", nullable: false),
                    RouteId = table.Column<int>(type: "int", nullable: false),
                    Distance = table.Column<int>(type: "int", nullable: false),
                    TravelTime = table.Column<double>(type: "float", nullable: false),
                    DelayTime = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RouteDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RouteDetails_Routes_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Routes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_RouteDetails_Stations_ArrivalStationId",
                        column: x => x.ArrivalStationId,
                        principalTable: "Stations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_RouteDetails_Stations_DepartureStationId",
                        column: x => x.DepartureStationId,
                        principalTable: "Stations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RouteId = table.Column<int>(type: "int", nullable: false),
                    StartAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ScheduleCompleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schedules_Routes_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Routes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Schedules_Trains_TrainCode",
                        column: x => x.TrainCode,
                        principalTable: "Trains",
                        principalColumn: "TrainCode",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "NameOfDivision", "StationCode", "StationName", "ZipCode", "Zone" },
                values: new object[,]
                {
                    { 1, "Ho Chi Minh City", "SGO", "Sai Gon", 700000, "Southern" },
                    { 2, "Khanh Hoa Province", "NTR", "Nha Trang", 650000, "Central" },
                    { 3, "Thua Thien Hue Province", "HUE", "Hue", 530000, "Central" },
                    { 4, "Hanoi Capital", "HNO", "Ha Noi", 700000, "North" }
                });

            migrationBuilder.InsertData(
                table: "Trains",
                columns: new[] { "TrainCode", "Description", "IsRunning", "Name", "TypeCode" },
                values: new object[,]
                {
                    { "SE101", "Train SE1 is a fast train running on the North-South unified train route. The Railway industry is trying to improve service quality and train speed to increasingly meet the travel needs of customers.", true, "SE1", "F" },
                    { "SE102", "Train SE1 is a fast train running on the North-South unified train route. The Railway industry is trying to improve service quality and train speed to increasingly meet the travel needs of customers.", true, "SE1", "F" },
                    { "SE201", "Train SE2 is a fast train running on the unified North-South train route. The Railway industry is trying to improve service quality and train speed to increasingly meet the travel needs of customers.", true, "SE2", "F" },
                    { "SE202", "Train SE2 is a fast train running on the unified North-South train route. The Railway industry is trying to improve service quality and train speed to increasingly meet the travel needs of customers.", true, "SE2", "F" },
                    { "SE301", "The SE3 train is the fastest and most beautiful train running on the unified North-South train route. The Railway industry is trying to improve service quality and train speed to increasingly meet the travel needs of customers.", true, "SE3", "SF" },
                    { "SE302", "The SE3 train is the fastest and most beautiful train running on the unified North-South train route. The Railway industry is trying to improve service quality and train speed to increasingly meet the travel needs of customers.", true, "SE3", "SF" },
                    { "SE401", "Train SE4 is the fastest and most beautiful train running on the North-South unified train route. The Railway industry is trying to improve service quality and train speed to increasingly meet the travel needs of customers.", true, "SE4", "SF" },
                    { "SE402", "Train SE4 is the fastest and most beautiful train running on the North-South unified train route. The Railway industry is trying to improve service quality and train speed to increasingly meet the travel needs of customers.", true, "SE4", "SF" },
                    { "SE501", "Train SE5 is a slow train running on the unified North-South train route. The Railway industry is trying to improve service quality and train speed to increasingly meet the travel needs of customers.", true, "SE5", "S" },
                    { "SE502", "Train SE5 is a slow train running on the unified North-South train route. The Railway industry is trying to improve service quality and train speed to increasingly meet the travel needs of customers.", true, "SE5", "S" },
                    { "SE601", "Train SE6 is a slow train running on the unified North-South train route. The Railway industry is trying to improve service quality and train speed to increasingly meet the travel needs of customers.", true, "SE6", "S" },
                    { "SE602", "Train SE6 is a slow train running on the unified North-South train route. The Railway industry is trying to improve service quality and train speed to increasingly meet the travel needs of customers.", true, "SE6", "S" },
                    { "SE701", "Train SE7 is a fast train running on the North-South unified train route. The Railway industry is trying to improve service quality and train speed to increasingly meet the travel needs of customers.", true, "SE7", "F" },
                    { "SE702", "Train SE7 is a fast train running on the North-South unified train route. The Railway industry is trying to improve service quality and train speed to increasingly meet the travel needs of customers.", true, "SE7", "F" },
                    { "SE801", "Train SE8 is a fast train running on the North-South unified train route. The Railway industry is trying to improve service quality and train speed to increasingly meet the travel needs of customers.", true, "SE8", "F" },
                    { "SE802", "Train SE8 is a fast train running on the North-South unified train route. The Railway industry is trying to improve service quality and train speed to increasingly meet the travel needs of customers.", true, "SE8", "F" }
                });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "Id", "Description", "Name", "NoOfCompartment", "NoOfSeat", "SeatAvailable", "TrainCode", "TypeCode" },
                values: new object[,]
                {
                    { 1, "Personal cabin(4)or coupe(2seat)\nPrivacy\nHigh fare\nComfortable Seat\nU can carry your Dog", "Class S", 4, 2, 8, "SE101", "AC1" },
                    { 2, "Personal cabin(4)or coupe(2seat)\nPrivacy\nHigh fare\nComfortable Seat\nU can carry your Dog", "Class S", 4, 2, 2, "SE101", "AC1" },
                    { 3, "No privacy\nComparatively Comfortable\nAverage fare\nNo dogs allowed\nluggage spaceious", "Class A", 4, 2, 4, "SE101", "AC2" },
                    { 4, "Average Rush\nCooling worth comfort\nLess Lagague space\nAgain No Dogs", "Class B", 6, 2, 12, "SE101", "AC3" },
                    { 5, "more comfor and amenities\nhigher fare", "Class C", 6, 6, 20, "SE101", "SL" },
                    { 6, "basic amenities\nbudget-friendly\nbench-type seats\nmore people", "Class D", 4, 16, 64, "SE101", "GE" },
                    { 7, "Personal cabin(4)or coupe(2seat)\nPrivacy\nHigh fare\nComfortable Seat\nU can carry your Dog", "Class S", 4, 2, 8, "SE201", "AC1" },
                    { 8, "Personal cabin(4)or coupe(2seat)\nPrivacy\nHigh fare\nComfortable Seat\nU can carry your Dog", "Class S", 4, 2, 10, "SE201", "AC2" },
                    { 9, "more comfor and amenities\\nhigher fare", "Class C", 6, 6, 12, "SE201", "SL" },
                    { 10, "basic amenities\nbudget-friendly\nbench-type seats\nmore people", "Class D", 4, 16, 3, "SE201", "GE" },
                    { 11, "basic amenities\nbudget-friendly\nbench-type seats\nmore people", "Class D", 4, 16, 2, "SE201", "GE" },
                    { 12, "Personal cabin(4)or coupe(2seat)\nPrivacy\nHigh fare\nComfortable Seat\nU can carry your Dog", "Class S", 4, 2, 8, "SE301", "AC1" },
                    { 13, "No privacy\nComparatively Comfortable\nAverage fare\nNo dogs allowed\nluggage spaceious", "Class A", 4, 2, 8, "SE301", "AC2" },
                    { 14, "Average Rush\nCooling worth comfort\nLess Lagague space\nAgain No Dogs", "Class B", 6, 2, 12, "SE301", "AC3" },
                    { 15, "more comfor and amenities\\nhigher fare", "Class C", 6, 6, 22, "SE301", "SL" },
                    { 16, "basic amenities\nbudget-friendly\nbench-type seats\nmore people", "Class D", 4, 16, 22, "SE301", "GE" },
                    { 17, "Personal cabin(4)or coupe(2seat)\nPrivacy\nHigh fare\nComfortable Seat\nU can carry your Dog", "Class S", 4, 2, 8, "SE401", "AC1" },
                    { 18, "No privacy\nComparatively Comfortable\nAverage fare\nNo dogs allowed\nluggage spaceious", "Class A", 4, 2, 8, "SE401", "AC2" },
                    { 19, "Average Rush\nCooling worth comfort\nLess Lagague space\nAgain No Dogs", "Class B", 6, 2, 12, "SE401", "AC3" },
                    { 20, "more comfor and amenities\\nhigher fare", "Class C", 6, 6, 20, "SE401", "SL" },
                    { 21, "basic amenities\nbudget-friendly\nbench-type seats\nmore people", "Class D", 4, 16, 24, "SE401", "GE" },
                    { 22, "Personal cabin(4)or coupe(2seat)\nPrivacy\nHigh fare\nComfortable Seat\nU can carry your Dog", "Class S", 4, 2, 2, "SE501", "AC1" },
                    { 23, "No privacy\nComparatively Comfortable\nAverage fare\nNo dogs allowed\nluggage spaceious", "Class A", 4, 2, 3, "SE501", "AC2" },
                    { 24, "Average Rush\nCooling worth comfort\nLess Lagague space\nAgain No Dogs", "Class B", 6, 2, 10, "SE501", "AC3" },
                    { 25, "more comfor and amenities\\nhigher fare", "Class C", 6, 6, 17, "SE501", "SL" },
                    { 26, "basic amenities\nbudget-friendly\nbench-type seats\nmore people", "Class D", 4, 16, 13, "SE501", "GE" },
                    { 27, "Personal cabin(4)or coupe(2seat)\nPrivacy\nHigh fare\nComfortable Seat\nU can carry your Dog", "Class S", 4, 2, 7, "SE601", "AC1" },
                    { 28, "No privacy\nComparatively Comfortable\nAverage fare\nNo dogs allowed\nluggage spaceious", "Class A", 4, 2, 6, "SE601", "AC2" },
                    { 29, "Average Rush\nCooling worth comfort\nLess Lagague space\nAgain No Dogs", "Class B", 6, 2, 10, "SE601", "AC3" },
                    { 30, "more comfor and amenities\\nhigher fare", "Class C", 6, 6, 20, "SE601", "SL" },
                    { 31, "basic amenities\nbudget-friendly\nbench-type seats\nmore people", "Class D", 4, 16, 12, "SE601", "GE" },
                    { 32, "basic amenities\nbudget-friendly\nbench-type seats\nmore people", "Class D", 4, 16, 13, "SE601", "GE" },
                    { 33, "Personal cabin(4)or coupe(2seat)\nPrivacy\nHigh fare\nComfortable Seat\nU can carry your Dog", "Class S", 4, 2, 8, "SE701", "AC1" },
                    { 34, "No privacy\nComparatively Comfortable\nAverage fare\nNo dogs allowed\nluggage spaceious", "Class A", 4, 2, 8, "SE701", "AC2" },
                    { 35, "Average Rush\nCooling worth comfort\nLess Lagague space\nAgain No Dogs", "Class B", 6, 2, 11, "SE701", "AC3" },
                    { 36, "more comfor and amenities\\nhigher fare", "Class C", 6, 6, 22, "SE701", "SL" },
                    { 37, "basic amenities\nbudget-friendly\nbench-type seats\nmore people", "Class D", 4, 16, 16, "SE701", "GE" },
                    { 38, "basic amenities\nbudget-friendly\nbench-type seats\nmore people", "Class D", 4, 16, 28, "SE701", "GE" },
                    { 39, "Personal cabin(4)or coupe(2seat)\nPrivacy\nHigh fare\nComfortable Seat\nU can carry your Dog", "Class S", 4, 2, 8, "SE801", "AC1" },
                    { 40, "No privacy\nComparatively Comfortable\nAverage fare\nNo dogs allowed\nluggage spaceious", "Class A", 4, 2, 8, "SE801", "AC2" },
                    { 41, "Average Rush\nCooling worth comfort\nLess Lagague space\nAgain No Dogs", "Class B", 6, 2, 11, "SE801", "AC3" },
                    { 42, "more comfor and amenities\\nhigher fare", "Class C", 6, 6, 10, "SE801", "SL" },
                    { 43, "basic amenities\nbudget-friendly\nbench-type seats\nmore people", "Class D", 4, 16, 16, "SE801", "GE" },
                    { 44, "basic amenities\nbudget-friendly\nbench-type seats\nmore people", "Class D", 4, 16, 22, "SE801", "GE" }
                });

            migrationBuilder.InsertData(
                table: "Routes",
                columns: new[] { "Id", "Distance", "EndStationId", "StartStationId" },
                values: new object[,]
                {
                    { 1, 1726, 4, 1 },
                    { 2, 1726, 4, 1 },
                    { 3, 1726, 1, 4 },
                    { 4, 1726, 1, 4 }
                });

            migrationBuilder.InsertData(
                table: "RouteDetails",
                columns: new[] { "Id", "ArrivalStationId", "DelayTime", "DepartureStationId", "Distance", "RouteId", "TravelTime" },
                values: new object[,]
                {
                    { 1, 2, 13, 1, 411, 1, 8.0 },
                    { 2, 3, 13, 2, 627, 1, 12.4 },
                    { 3, 4, 12, 3, 688, 1, 15.6 },
                    { 4, 3, 10, 1, 1038, 2, 21.399999999999999 },
                    { 5, 4, 12, 3, 688, 2, 10.6 },
                    { 6, 3, 10, 4, 688, 3, 12.6 },
                    { 7, 2, 12, 3, 627, 3, 13.6 },
                    { 8, 1, 12, 2, 411, 3, 8.5999999999999996 },
                    { 9, 2, 12, 4, 1315, 4, 22.600000000000001 },
                    { 10, 1, 12, 2, 411, 4, 7.5999999999999996 }
                });

            migrationBuilder.InsertData(
                table: "Schedules",
                columns: new[] { "Id", "EndAt", "RouteId", "ScheduleCompleted", "StartAt", "TrainCode" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 11, 27, 19, 12, 0, 0, DateTimeKind.Unspecified), 1, false, new DateTime(2023, 11, 26, 6, 0, 0, 0, DateTimeKind.Unspecified), "SE801" },
                    { 2, new DateTime(2023, 11, 28, 2, 30, 0, 0, DateTimeKind.Unspecified), 1, false, new DateTime(2023, 11, 26, 16, 0, 0, 0, DateTimeKind.Unspecified), "SE601" },
                    { 3, new DateTime(2023, 11, 28, 7, 10, 0, 0, DateTimeKind.Unspecified), 1, false, new DateTime(2023, 11, 26, 19, 20, 0, 0, DateTimeKind.Unspecified), "SE201" },
                    { 4, new DateTime(2023, 11, 27, 13, 0, 0, 0, DateTimeKind.Unspecified), 2, false, new DateTime(2023, 11, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), "SE401" },
                    { 5, new DateTime(2023, 11, 27, 20, 32, 0, 0, DateTimeKind.Unspecified), 3, false, new DateTime(2023, 11, 26, 9, 30, 0, 0, DateTimeKind.Unspecified), "SE701" },
                    { 6, new DateTime(2023, 11, 29, 3, 12, 0, 0, DateTimeKind.Unspecified), 3, false, new DateTime(2023, 11, 26, 11, 30, 0, 0, DateTimeKind.Unspecified), "SE501" },
                    { 7, new DateTime(2023, 11, 27, 13, 30, 0, 0, DateTimeKind.Unspecified), 3, false, new DateTime(2023, 11, 26, 6, 30, 0, 0, DateTimeKind.Unspecified), "SE101" },
                    { 8, new DateTime(2023, 11, 27, 8, 25, 0, 0, DateTimeKind.Unspecified), 4, false, new DateTime(2023, 11, 26, 7, 30, 0, 0, DateTimeKind.Unspecified), "SE301" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Classes_TrainCode",
                table: "Classes",
                column: "TrainCode");

            migrationBuilder.CreateIndex(
                name: "IX_Fares_RouteId",
                table: "Fares",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_RouteDetails_ArrivalStationId",
                table: "RouteDetails",
                column: "ArrivalStationId");

            migrationBuilder.CreateIndex(
                name: "IX_RouteDetails_DepartureStationId",
                table: "RouteDetails",
                column: "DepartureStationId");

            migrationBuilder.CreateIndex(
                name: "IX_RouteDetails_RouteId",
                table: "RouteDetails",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_Routes_EndStationId",
                table: "Routes",
                column: "EndStationId");

            migrationBuilder.CreateIndex(
                name: "IX_Routes_StartStationId",
                table: "Routes",
                column: "StartStationId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_RouteId",
                table: "Schedules",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_TrainCode",
                table: "Schedules",
                column: "TrainCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Fares");

            migrationBuilder.DropTable(
                name: "RouteDetails");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "Routes");

            migrationBuilder.DropTable(
                name: "Trains");

            migrationBuilder.DropTable(
                name: "Stations");
        }
    }
}

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
                        onDelete: ReferentialAction.Cascade);
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
                        onDelete: ReferentialAction.Cascade);
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
                    TravelTime = table.Column<int>(type: "int", nullable: false),
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Schedules_Trains_TrainCode",
                        column: x => x.TrainCode,
                        principalTable: "Trains",
                        principalColumn: "TrainCode",
                        onDelete: ReferentialAction.Cascade);
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
                    { "SE1", "Train SE1 is a fast train running on the North-South unified train route. The Railway industry is trying to improve service quality and train speed to increasingly meet the travel needs of customers.", true, "Fast train HN-SG", "F" },
                    { "SE2", "Train SE2 is a fast train running on the unified North-South train route. The Railway industry is trying to improve service quality and train speed to increasingly meet the travel needs of customers.", true, "Fast train SG-HN", "F" },
                    { "SE3", "The SE3 train is the fastest and most beautiful train running on the unified North-South train route. The Railway industry is trying to improve service quality and train speed to increasingly meet the travel needs of customers.", true, "Super Fast train HN-SG", "SF" },
                    { "SE4", "Train SE4 is the fastest and most beautiful train running on the North-South unified train route. The Railway industry is trying to improve service quality and train speed to increasingly meet the travel needs of customers.", true, "Super Fast train SG-HN", "SF" },
                    { "SP1", "The SP1 train is a fast train running the Hanoi - Lao Cai (Sapa) train route serving tourists, business travelers and other needs. This is a type of tourist train, the quality of the carriages and the service are quite good.", true, "Fast train HN-LC", "F" },
                    { "SP2", "The SP2 train is a fast train running the Hanoi - Lao Cai (Sapa) train route to serve tourists, business travelers and other needs. This is a type of tourist train, the quality of the carriages and the service are quite good.", true, "Fast train LC-HN", "F" }
                });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "Id", "Description", "Name", "NoOfCompartment", "NoOfSeat", "SeatAvailable", "TrainCode", "TypeCode" },
                values: new object[,]
                {
                    { 1, "Personal cabin(4)or coupe(2seat)\nPrivacy\nHigh fare\nComfortable Seat\nU can carry your Dog", "Class S", 4, 2, 8, "SE1", "AC1" },
                    { 2, "Personal cabin(4)or coupe(2seat)\nPrivacy\nHigh fare\nComfortable Seat\nU can carry your Dog", "Class S", 4, 2, 8, "SE1", "AC1" },
                    { 3, "No privacy\nComparatively Comfortable\nAverage fare\nNo dogs allowed\nluggage spaceious", "Class A", 4, 2, 8, "SE1", "AC2" },
                    { 4, "Average Rush\nCooling worth comfort\nLess Lagague space\nAgain No Dogs", "Class B", 6, 2, 8, "SE1", "AC3" },
                    { 5, "more comfor and amenities\nhigher fare", "Class C", 6, 6, 8, "SE1", "SL" },
                    { 6, "basic amenities\nbudget-friendly\nbench-type seats\nmore people", "Class D", 4, 16, 64, "SE1", "GE" },
                    { 7, "Personal cabin(4)or coupe(2seat)\nPrivacy\nHigh fare\nComfortable Seat\nU can carry your Dog", "Class S", 6, 2, 8, "SE2", "AC1" },
                    { 8, "Personal cabin(4)or coupe(2seat)\nPrivacy\nHigh fare\nComfortable Seat\nU can carry your Dog", "Class C", 6, 2, 8, "SE2", "SL" }
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

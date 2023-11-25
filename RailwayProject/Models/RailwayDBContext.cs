using Microsoft.EntityFrameworkCore;
using System.Security.Policy;

namespace RailwayProject.Models
{
    public class RailwayDBContext : DbContext
    {
        public RailwayDBContext(DbContextOptions options) : base(options) { }
        public DbSet<Station>? Stations { get; set; }
        public DbSet<Class>? Classes { get; set; }
        public DbSet<Train>? Trains { get; set; }    
        public DbSet<Route>? Routes { get; set; }
        public DbSet<RouteDetail>? RouteDetails { get; set; }
        public DbSet<Schedule>? Schedules { get; set; }
        public DbSet<Fare>? Fares { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Station>().HasMany(p => p.StartRoutes).WithOne(p => p.StartStation);
            modelBuilder.Entity<Station>().HasMany(p => p.EndRoutes).WithOne(p => p.EndStation);
            modelBuilder.Entity<Station>().HasMany(p => p.DepartureRouteDetails).WithOne(p => p.DepartureStation);
            modelBuilder.Entity<Station>().HasMany(p => p.ArrivalRouteDetails).WithOne(p => p.ArrivalStation);
            modelBuilder.Entity<Station>().HasData(
                new Station {Id=1, StationCode="SGO", StationName = "Sai Gon",ZipCode= 700000,NameOfDivision= "Ho Chi Minh City", Zone= "Southern" },
                new Station {Id=2, StationCode="NTR", StationName = "Nha Trang",ZipCode= 650000,NameOfDivision= "Khanh Hoa Province", Zone= "Central" },
                new Station {Id=3, StationCode="HUE", StationName = "Hue", ZipCode= 530000,NameOfDivision= "Thua Thien Hue Province", Zone= "Central" },
                new Station {Id=4, StationCode="HNO", StationName = "Ha Noi",ZipCode= 700000,NameOfDivision= "Hanoi Capital", Zone= "North" }
                );
            modelBuilder.Entity<Train>().HasData(
                new Train { TrainCode="SE101", Name= "SE1", TypeCode="F",IsRunning=true,Description= "Train SE1 is a fast train running on the North-South unified train route. The Railway industry is trying to improve service quality and train speed to increasingly meet the travel needs of customers." },
                new Train { TrainCode="SE102", Name= "SE1", TypeCode="F", IsRunning=true,Description= "Train SE1 is a fast train running on the North-South unified train route. The Railway industry is trying to improve service quality and train speed to increasingly meet the travel needs of customers." },
                new Train { TrainCode="SE201", Name= "SE2", TypeCode="F",IsRunning=true,Description= "Train SE2 is a fast train running on the unified North-South train route. The Railway industry is trying to improve service quality and train speed to increasingly meet the travel needs of customers." },
                new Train { TrainCode="SE202", Name= "SE2", TypeCode="F",IsRunning=true,Description= "Train SE2 is a fast train running on the unified North-South train route. The Railway industry is trying to improve service quality and train speed to increasingly meet the travel needs of customers." },
                new Train { TrainCode="SE301", Name= "SE3", TypeCode="SF",IsRunning=true,Description= "The SE3 train is the fastest and most beautiful train running on the unified North-South train route. The Railway industry is trying to improve service quality and train speed to increasingly meet the travel needs of customers." },
                new Train { TrainCode= "SE302", Name= "SE3", TypeCode="SF",IsRunning=true,Description= "The SE3 train is the fastest and most beautiful train running on the unified North-South train route. The Railway industry is trying to improve service quality and train speed to increasingly meet the travel needs of customers." },
                new Train { TrainCode="SE401", Name= "SE4", TypeCode="SF",IsRunning=true,Description= "Train SE4 is the fastest and most beautiful train running on the North-South unified train route. The Railway industry is trying to improve service quality and train speed to increasingly meet the travel needs of customers." },
                new Train { TrainCode="SE402", Name= "SE4", TypeCode="SF",IsRunning=true,Description= "Train SE4 is the fastest and most beautiful train running on the North-South unified train route. The Railway industry is trying to improve service quality and train speed to increasingly meet the travel needs of customers." },
                new Train { TrainCode="SE501", Name= "SE5", TypeCode="S",IsRunning=true,Description= "Train SE5 is a slow train running on the unified North-South train route. The Railway industry is trying to improve service quality and train speed to increasingly meet the travel needs of customers." },
                new Train { TrainCode= "SE502", Name= "SE5", TypeCode="S",IsRunning=true,Description= "Train SE5 is a slow train running on the unified North-South train route. The Railway industry is trying to improve service quality and train speed to increasingly meet the travel needs of customers." },
                new Train { TrainCode="SE601", Name= "SE6", TypeCode="S",IsRunning=true,Description= "Train SE6 is a slow train running on the unified North-South train route. The Railway industry is trying to improve service quality and train speed to increasingly meet the travel needs of customers." },
                new Train { TrainCode="SE602", Name= "SE6", TypeCode="S",IsRunning=true,Description= "Train SE6 is a slow train running on the unified North-South train route. The Railway industry is trying to improve service quality and train speed to increasingly meet the travel needs of customers." },
                new Train { TrainCode="SE701", Name = "SE7", TypeCode="F",IsRunning=true,Description= "Train SE7 is a fast train running on the North-South unified train route. The Railway industry is trying to improve service quality and train speed to increasingly meet the travel needs of customers." },
                new Train { TrainCode= "SE702", Name = "SE7", TypeCode="F",IsRunning=true,Description= "Train SE7 is a fast train running on the North-South unified train route. The Railway industry is trying to improve service quality and train speed to increasingly meet the travel needs of customers." },
                new Train { TrainCode="SE801", Name = "SE8", TypeCode="F",IsRunning=true,Description= "Train SE8 is a fast train running on the North-South unified train route. The Railway industry is trying to improve service quality and train speed to increasingly meet the travel needs of customers." },
                new Train { TrainCode= "SE802", Name = "SE8", TypeCode="F",IsRunning=true,Description= "Train SE8 is a fast train running on the North-South unified train route. The Railway industry is trying to improve service quality and train speed to increasingly meet the travel needs of customers." }
                );
            modelBuilder.Entity<Class>().HasData(
                //SE101
                new Class {Id=1, TypeCode= "AC1",Name="Class S", NoOfCompartment=4, NoOfSeat=2, TrainCode="SE101",SeatAvailable=8,Description= "Personal cabin(4)or coupe(2seat)\nPrivacy\nHigh fare\nComfortable Seat\nU can carry your Dog" },
                new Class {Id=2, TypeCode= "AC1",Name="Class S", NoOfCompartment=4, NoOfSeat=2, TrainCode="SE101",SeatAvailable=2,Description= "Personal cabin(4)or coupe(2seat)\nPrivacy\nHigh fare\nComfortable Seat\nU can carry your Dog" },
                new Class {Id=3, TypeCode= "AC2",Name="Class A", NoOfCompartment=4, NoOfSeat=2, TrainCode="SE101",SeatAvailable=4,Description= "No privacy\nComparatively Comfortable\nAverage fare\nNo dogs allowed\nluggage spaceious" },
                new Class {Id=4, TypeCode= "AC3",Name="Class B", NoOfCompartment=6, NoOfSeat=2, TrainCode="SE101",SeatAvailable=12,Description= "Average Rush\nCooling worth comfort\nLess Lagague space\nAgain No Dogs" },
                new Class {Id=5, TypeCode= "SL",Name="Class C", NoOfCompartment=6, NoOfSeat=6, TrainCode="SE101",SeatAvailable=20,Description= "more comfor and amenities\nhigher fare" },
                new Class {Id=6, TypeCode= "GE",Name="Class D", NoOfCompartment=4, NoOfSeat=16, TrainCode="SE101",SeatAvailable=64,Description= "basic amenities\nbudget-friendly\nbench-type seats\nmore people" },
                //SE201
                new Class {Id=7, TypeCode= "AC1",Name="Class S", NoOfCompartment=4, NoOfSeat=2, TrainCode="SE201",SeatAvailable=8,Description= "Personal cabin(4)or coupe(2seat)\nPrivacy\nHigh fare\nComfortable Seat\nU can carry your Dog" },
                new Class {Id=8, TypeCode= "AC2",Name="Class S", NoOfCompartment=4, NoOfSeat=2, TrainCode="SE201",SeatAvailable=10,Description= "Personal cabin(4)or coupe(2seat)\nPrivacy\nHigh fare\nComfortable Seat\nU can carry your Dog" },
                new Class {Id=9, TypeCode= "SL",Name="Class C", NoOfCompartment=6, NoOfSeat=6, TrainCode= "SE201", SeatAvailable=12,Description= "more comfor and amenities\\nhigher fare" },
                new Class {Id=10, TypeCode= "GE",Name="Class D", NoOfCompartment=4, NoOfSeat=16, TrainCode= "SE201", SeatAvailable=3,Description= "basic amenities\nbudget-friendly\nbench-type seats\nmore people" },
                new Class {Id=11, TypeCode= "GE",Name="Class D", NoOfCompartment=4, NoOfSeat=16, TrainCode= "SE201", SeatAvailable=2,Description= "basic amenities\nbudget-friendly\nbench-type seats\nmore people" },
                //SE301
                new Class { Id = 12, TypeCode = "AC1", Name = "Class S", NoOfCompartment = 4, NoOfSeat = 2, TrainCode = "SE301", SeatAvailable = 8, Description = "Personal cabin(4)or coupe(2seat)\nPrivacy\nHigh fare\nComfortable Seat\nU can carry your Dog" },
                new Class { Id = 13, TypeCode = "AC2", Name = "Class A", NoOfCompartment = 4, NoOfSeat = 2, TrainCode = "SE301", SeatAvailable = 8, Description = "No privacy\nComparatively Comfortable\nAverage fare\nNo dogs allowed\nluggage spaceious" },
                new Class { Id = 14, TypeCode = "AC3", Name = "Class B", NoOfCompartment = 6, NoOfSeat = 2, TrainCode = "SE301", SeatAvailable = 12, Description = "Average Rush\nCooling worth comfort\nLess Lagague space\nAgain No Dogs" },
                new Class { Id = 15, TypeCode = "SL", Name = "Class C", NoOfCompartment = 6, NoOfSeat = 6, TrainCode = "SE301", SeatAvailable = 22, Description = "more comfor and amenities\\nhigher fare" },
                new Class { Id = 16, TypeCode = "GE", Name = "Class D", NoOfCompartment =4, NoOfSeat = 16, TrainCode = "SE301", SeatAvailable = 22, Description = "basic amenities\nbudget-friendly\nbench-type seats\nmore people" },
                //SE401
                new Class { Id = 17, TypeCode = "AC1", Name = "Class S", NoOfCompartment = 4, NoOfSeat = 2, TrainCode = "SE401", SeatAvailable = 8, Description = "Personal cabin(4)or coupe(2seat)\nPrivacy\nHigh fare\nComfortable Seat\nU can carry your Dog" },
                new Class { Id = 18, TypeCode = "AC2", Name = "Class A", NoOfCompartment = 4, NoOfSeat = 2, TrainCode = "SE401", SeatAvailable = 8, Description = "No privacy\nComparatively Comfortable\nAverage fare\nNo dogs allowed\nluggage spaceious" },
                new Class { Id = 19, TypeCode = "AC3", Name = "Class B", NoOfCompartment = 6, NoOfSeat = 2, TrainCode = "SE401", SeatAvailable = 12, Description = "Average Rush\nCooling worth comfort\nLess Lagague space\nAgain No Dogs" },
                new Class { Id = 20, TypeCode = "SL", Name = "Class C", NoOfCompartment = 6, NoOfSeat = 6, TrainCode = "SE401", SeatAvailable = 20, Description = "more comfor and amenities\\nhigher fare" },
                new Class { Id = 21, TypeCode = "GE", Name = "Class D", NoOfCompartment = 4, NoOfSeat = 16, TrainCode = "SE401", SeatAvailable = 24, Description = "basic amenities\nbudget-friendly\nbench-type seats\nmore people" },
                //SE501
                new Class { Id = 22, TypeCode = "AC1", Name = "Class S", NoOfCompartment = 4, NoOfSeat = 2, TrainCode = "SE501", SeatAvailable = 2, Description = "Personal cabin(4)or coupe(2seat)\nPrivacy\nHigh fare\nComfortable Seat\nU can carry your Dog" },
                new Class { Id = 23, TypeCode = "AC2", Name = "Class A", NoOfCompartment = 4, NoOfSeat = 2, TrainCode = "SE501", SeatAvailable = 3, Description = "No privacy\nComparatively Comfortable\nAverage fare\nNo dogs allowed\nluggage spaceious" },
                new Class { Id = 24, TypeCode = "AC3", Name = "Class B", NoOfCompartment = 6, NoOfSeat = 2, TrainCode = "SE501", SeatAvailable = 10, Description = "Average Rush\nCooling worth comfort\nLess Lagague space\nAgain No Dogs" },
                new Class { Id = 25, TypeCode = "SL", Name = "Class C", NoOfCompartment = 6, NoOfSeat = 6, TrainCode = "SE501", SeatAvailable = 17, Description = "more comfor and amenities\\nhigher fare" },
                new Class { Id = 26, TypeCode = "GE", Name = "Class D", NoOfCompartment = 4, NoOfSeat = 16, TrainCode = "SE501", SeatAvailable = 13, Description = "basic amenities\nbudget-friendly\nbench-type seats\nmore people" },
                //SE601
                new Class { Id = 27, TypeCode = "AC1", Name = "Class S", NoOfCompartment = 4, NoOfSeat = 2, TrainCode = "SE601", SeatAvailable = 7, Description = "Personal cabin(4)or coupe(2seat)\nPrivacy\nHigh fare\nComfortable Seat\nU can carry your Dog" },
                new Class { Id = 28, TypeCode = "AC2", Name = "Class A", NoOfCompartment = 4, NoOfSeat = 2, TrainCode = "SE601", SeatAvailable = 6, Description = "No privacy\nComparatively Comfortable\nAverage fare\nNo dogs allowed\nluggage spaceious" },
                new Class { Id = 29, TypeCode = "AC3", Name = "Class B", NoOfCompartment = 6, NoOfSeat = 2, TrainCode = "SE601", SeatAvailable = 10, Description = "Average Rush\nCooling worth comfort\nLess Lagague space\nAgain No Dogs" },
                new Class { Id = 30, TypeCode = "SL", Name = "Class C", NoOfCompartment = 6, NoOfSeat = 6, TrainCode = "SE601", SeatAvailable = 20, Description = "more comfor and amenities\\nhigher fare" },
                new Class { Id = 31, TypeCode = "GE", Name = "Class D", NoOfCompartment = 4, NoOfSeat = 16, TrainCode = "SE601", SeatAvailable = 12, Description = "basic amenities\nbudget-friendly\nbench-type seats\nmore people" },
                new Class { Id = 32, TypeCode = "GE", Name = "Class D", NoOfCompartment = 4, NoOfSeat = 16, TrainCode = "SE601", SeatAvailable = 13, Description = "basic amenities\nbudget-friendly\nbench-type seats\nmore people" },
                //SE701
                new Class { Id = 33, TypeCode = "AC1", Name = "Class S", NoOfCompartment = 4, NoOfSeat = 2, TrainCode = "SE701", SeatAvailable = 8, Description = "Personal cabin(4)or coupe(2seat)\nPrivacy\nHigh fare\nComfortable Seat\nU can carry your Dog" },
                new Class { Id = 34, TypeCode = "AC2", Name = "Class A", NoOfCompartment = 4, NoOfSeat = 2, TrainCode = "SE701", SeatAvailable = 8, Description = "No privacy\nComparatively Comfortable\nAverage fare\nNo dogs allowed\nluggage spaceious" },
                new Class { Id = 35, TypeCode = "AC3", Name = "Class B", NoOfCompartment = 6, NoOfSeat = 2, TrainCode = "SE701", SeatAvailable = 11, Description = "Average Rush\nCooling worth comfort\nLess Lagague space\nAgain No Dogs" },
                new Class { Id = 36, TypeCode = "SL", Name = "Class C", NoOfCompartment = 6, NoOfSeat = 6, TrainCode = "SE701", SeatAvailable = 22, Description = "more comfor and amenities\\nhigher fare" },
                new Class { Id = 37, TypeCode = "GE", Name = "Class D", NoOfCompartment = 4, NoOfSeat = 16, TrainCode = "SE701", SeatAvailable = 16, Description = "basic amenities\nbudget-friendly\nbench-type seats\nmore people" },
                new Class { Id = 38, TypeCode = "GE", Name = "Class D", NoOfCompartment = 4, NoOfSeat = 16, TrainCode = "SE701", SeatAvailable = 28, Description = "basic amenities\nbudget-friendly\nbench-type seats\nmore people" },
                //SE801
                new Class { Id = 39, TypeCode = "AC1", Name = "Class S", NoOfCompartment = 4, NoOfSeat = 2, TrainCode = "SE801", SeatAvailable = 8, Description = "Personal cabin(4)or coupe(2seat)\nPrivacy\nHigh fare\nComfortable Seat\nU can carry your Dog" },
                new Class { Id = 40, TypeCode = "AC2", Name = "Class A", NoOfCompartment = 4, NoOfSeat = 2, TrainCode = "SE801", SeatAvailable = 8, Description = "No privacy\nComparatively Comfortable\nAverage fare\nNo dogs allowed\nluggage spaceious" },
                new Class { Id = 41, TypeCode = "AC3", Name = "Class B", NoOfCompartment = 6, NoOfSeat = 2, TrainCode = "SE801", SeatAvailable = 11, Description = "Average Rush\nCooling worth comfort\nLess Lagague space\nAgain No Dogs" },
                new Class { Id = 42, TypeCode = "SL", Name = "Class C", NoOfCompartment = 6, NoOfSeat = 6, TrainCode = "SE801", SeatAvailable = 10, Description = "more comfor and amenities\\nhigher fare" },
                new Class { Id = 43, TypeCode = "GE", Name = "Class D", NoOfCompartment = 4, NoOfSeat = 16, TrainCode = "SE801", SeatAvailable = 16, Description = "basic amenities\nbudget-friendly\nbench-type seats\nmore people" },
                new Class { Id = 44, TypeCode = "GE", Name = "Class D", NoOfCompartment = 4, NoOfSeat = 16, TrainCode = "SE801", SeatAvailable = 22, Description = "basic amenities\nbudget-friendly\nbench-type seats\nmore people" }
                );
            modelBuilder.Entity<Route>().HasData(
                new Route { Id=1,StartStationId=1,EndStationId=4,Distance=1726},
                new Route { Id=2,StartStationId=1,EndStationId=4,Distance= 1726 },
                new Route { Id=3, StartStationId=4,EndStationId=1, Distance = 1726 },
                new Route { Id=4,StartStationId=4,EndStationId=1,Distance=1726}
                );
            modelBuilder.Entity<RouteDetail>().HasData(
                new RouteDetail { Id = 1,DepartureStationId=1,ArrivalStationId=2,DelayTime=13,Distance=411,TravelTime=8,RouteId=1}, //Sai Gon - Nha Trang
                new RouteDetail { Id = 2,DepartureStationId=2,ArrivalStationId=3,DelayTime=13,Distance=627,TravelTime=12.4,RouteId=1}, //Nha Trang - Hue
                new RouteDetail { Id = 3,DepartureStationId=3,ArrivalStationId=4,DelayTime=12,Distance=688, TravelTime=15.6,RouteId=1}, // Hue - HN
                new RouteDetail { Id = 4,DepartureStationId=1,ArrivalStationId=3,DelayTime=10,Distance= 1038, TravelTime=21.4,RouteId=2}, // SG - Hue
                new RouteDetail { Id = 5,DepartureStationId=3,ArrivalStationId=4,DelayTime=12,Distance= 688, TravelTime=10.6,RouteId=2}, // Hue - HN
                new RouteDetail { Id = 6,DepartureStationId=4,ArrivalStationId=3,DelayTime=10,Distance= 688, TravelTime=12.6,RouteId=3}, // HN - Hue
                new RouteDetail { Id = 7, DepartureStationId=3,ArrivalStationId=2,DelayTime=12,Distance= 627, TravelTime=13.6,RouteId=3}, // Hue - NT
                new RouteDetail { Id = 8, DepartureStationId=2,ArrivalStationId=1, DelayTime=12,Distance= 411, TravelTime=8.6,RouteId=3}, // NT - SG
                new RouteDetail { Id = 9, DepartureStationId=4,ArrivalStationId=2, DelayTime=12,Distance= 1315, TravelTime=22.6,RouteId=4}, // HN - NT
                new RouteDetail { Id = 10, DepartureStationId=2,ArrivalStationId=1, DelayTime=12,Distance= 411, TravelTime=7.6,RouteId=4 } // NT - SG
                );
            modelBuilder.Entity<Schedule>().HasData(
                new Schedule { Id=1,RouteId=1,ScheduleCompleted=false,StartAt= new DateTime(2023,11,26, 6, 0, 0),EndAt= new DateTime(2023, 11, 27, 19, 12, 0),TrainCode= "SE801" },
                new Schedule { Id=2,RouteId=1,ScheduleCompleted=false,StartAt= new DateTime(2023,11,26, 16, 0, 0),EndAt= new DateTime(2023, 11, 28, 2, 30, 0),TrainCode= "SE601" },
                new Schedule { Id=3,RouteId=1, ScheduleCompleted = false,StartAt= new DateTime(2023,11,26, 19, 20, 0),EndAt= new DateTime(2023, 11, 28, 7, 10, 0),TrainCode= "SE201" },
                new Schedule { Id=4,RouteId=2, ScheduleCompleted = false,StartAt= new DateTime(2023,11,26, 8, 0, 0),EndAt= new DateTime(2023, 11, 27, 13, 0, 0),TrainCode= "SE401" },
                new Schedule { Id=5,RouteId=3, ScheduleCompleted = false,StartAt= new DateTime(2023,11,26, 9, 30, 0),EndAt= new DateTime(2023, 11, 27, 20, 32, 0),TrainCode= "SE701" },
                new Schedule { Id=6,RouteId=3, ScheduleCompleted = false,StartAt= new DateTime(2023,11,26, 11, 30, 0),EndAt= new DateTime(2023, 11, 29, 3, 12, 0),TrainCode= "SE501" },
                new Schedule { Id=7,RouteId=3, ScheduleCompleted = false,StartAt= new DateTime(2023,11,26, 6, 30, 0),EndAt= new DateTime(2023, 11, 27, 13, 30, 0),TrainCode= "SE101" },
                new Schedule { Id=8,RouteId=4, ScheduleCompleted = false,StartAt= new DateTime(2023,11,26, 7, 30, 0),EndAt= new DateTime(2023, 11, 27, 8, 25, 0),TrainCode= "SE301" }
                );
            modelBuilder.Entity<Fare>().HasData(
                new Fare { Id = 1, RouteId=1,DistanceRange=12000,TypeOfClass= "AC1", TypeOfTrain="SF",Price=500000},
                new Fare { Id = 2, RouteId=1,DistanceRange=12000,TypeOfClass= "AC2", TypeOfTrain="SF",Price=300000},
                new Fare { Id = 3, RouteId=1,DistanceRange=12000,TypeOfClass= "AC3", TypeOfTrain="SF",Price=200000},
                new Fare { Id = 4, RouteId=1,DistanceRange=12000,TypeOfClass= "SL", TypeOfTrain="SF",Price=100000},
                new Fare { Id = 5, RouteId=1,DistanceRange=12000,TypeOfClass= "GE", TypeOfTrain="SF",Price=50000},

                new Fare { Id = 6, RouteId=1,DistanceRange=12000,TypeOfClass= "AC1", TypeOfTrain= "F",Price=400000},
                new Fare { Id = 7, RouteId=1,DistanceRange=12000,TypeOfClass= "AC2", TypeOfTrain= "F",Price=200000},
                new Fare { Id = 8, RouteId=1,DistanceRange=12000,TypeOfClass= "AC3", TypeOfTrain= "F",Price=150000},
                new Fare { Id = 9, RouteId=1,DistanceRange=12000,TypeOfClass= "SL", TypeOfTrain= "F",Price=80000},
                new Fare { Id = 10, RouteId=1,DistanceRange=12000,TypeOfClass= "GE", TypeOfTrain= "F",Price=40000},

                new Fare { Id = 11, RouteId = 1, DistanceRange = 12000, TypeOfClass = "AC1", TypeOfTrain = "S", Price = 360000 },
                new Fare { Id = 12, RouteId = 1, DistanceRange = 12000, TypeOfClass = "AC2", TypeOfTrain = "S", Price = 180000 },
                new Fare { Id = 13, RouteId = 1, DistanceRange = 12000, TypeOfClass = "AC3", TypeOfTrain = "S", Price = 120000 },
                new Fare { Id = 14, RouteId = 1, DistanceRange = 12000, TypeOfClass = "SL", TypeOfTrain = "S", Price = 60000 },
                new Fare { Id = 15, RouteId = 1, DistanceRange = 12000, TypeOfClass = "GE", TypeOfTrain = "S", Price = 30000 },

                new Fare { Id = 16, RouteId = 2, DistanceRange = 18000, TypeOfClass = "AC1", TypeOfTrain = "SF", Price = 550000 },
                new Fare { Id = 17, RouteId = 2, DistanceRange = 18000, TypeOfClass = "AC2", TypeOfTrain = "SF", Price = 350000 },
                new Fare { Id = 18, RouteId = 2, DistanceRange = 18000, TypeOfClass = "AC3", TypeOfTrain = "SF", Price = 250000 },
                new Fare { Id = 19, RouteId = 2, DistanceRange = 18000, TypeOfClass = "SL", TypeOfTrain = "SF", Price = 150000 },
                new Fare { Id = 20, RouteId = 2, DistanceRange = 18000, TypeOfClass = "GE", TypeOfTrain = "SF", Price = 55000 },

                new Fare { Id = 21, RouteId = 2, DistanceRange = 18000, TypeOfClass = "AC1", TypeOfTrain = "F", Price = 450000 },
                new Fare { Id = 22, RouteId = 2, DistanceRange = 18000, TypeOfClass = "AC2", TypeOfTrain = "F", Price = 250000 },
                new Fare { Id = 23, RouteId = 2, DistanceRange = 18000, TypeOfClass = "AC3", TypeOfTrain = "F", Price = 200000 },
                new Fare { Id = 24, RouteId = 2, DistanceRange = 18000, TypeOfClass = "SL", TypeOfTrain = "F", Price = 85000 },
                new Fare { Id = 25, RouteId = 2, DistanceRange = 18000, TypeOfClass = "GE", TypeOfTrain = "F", Price = 45000 },

                new Fare { Id = 26, RouteId = 2, DistanceRange = 18000, TypeOfClass = "AC1", TypeOfTrain = "S", Price = 390000 },
                new Fare { Id = 27, RouteId = 2, DistanceRange = 18000, TypeOfClass = "AC2", TypeOfTrain = "S", Price = 200000 },
                new Fare { Id = 28, RouteId = 2, DistanceRange = 18000, TypeOfClass = "AC3", TypeOfTrain = "S", Price = 160000 },
                new Fare { Id = 29, RouteId = 2, DistanceRange = 18000, TypeOfClass = "SL", TypeOfTrain = "S", Price = 65000 },
                new Fare { Id = 30, RouteId = 2, DistanceRange = 18000, TypeOfClass = "GE", TypeOfTrain = "S", Price = 35000 },

                new Fare { Id = 31, RouteId = 3, DistanceRange = 12000, TypeOfClass = "AC1", TypeOfTrain = "SF", Price = 500000 },
                new Fare { Id = 32, RouteId = 3, DistanceRange = 12000, TypeOfClass = "AC2", TypeOfTrain = "SF", Price = 300000 },
                new Fare { Id = 33, RouteId = 3, DistanceRange = 12000, TypeOfClass = "AC3", TypeOfTrain = "SF", Price = 200000 },
                new Fare { Id = 34, RouteId = 3, DistanceRange = 12000, TypeOfClass = "SL", TypeOfTrain = "SF", Price = 100000 },
                new Fare { Id = 35, RouteId = 3, DistanceRange = 12000, TypeOfClass = "GE", TypeOfTrain = "SF", Price = 50000 },

                new Fare { Id = 36, RouteId = 3, DistanceRange = 12000, TypeOfClass = "AC1", TypeOfTrain = "F", Price = 400000 },
                new Fare { Id = 37, RouteId = 3, DistanceRange = 12000, TypeOfClass = "AC2", TypeOfTrain = "F", Price = 200000 },
                new Fare { Id = 38, RouteId = 3, DistanceRange = 12000, TypeOfClass = "AC3", TypeOfTrain = "F", Price = 150000 },
                new Fare { Id = 39, RouteId = 3, DistanceRange = 12000, TypeOfClass = "SL", TypeOfTrain = "F", Price = 80000 },
                new Fare { Id = 40, RouteId = 3, DistanceRange = 12000, TypeOfClass = "GE", TypeOfTrain = "F", Price = 40000 },

                new Fare { Id = 41, RouteId = 3, DistanceRange = 12000, TypeOfClass = "AC1", TypeOfTrain = "S", Price = 360000 },
                new Fare { Id = 42, RouteId = 3, DistanceRange = 12000, TypeOfClass = "AC2", TypeOfTrain = "S", Price = 180000 },
                new Fare { Id = 43, RouteId = 3, DistanceRange = 12000, TypeOfClass = "AC3", TypeOfTrain = "S", Price = 120000 },
                new Fare { Id = 44, RouteId = 3, DistanceRange = 12000, TypeOfClass = "SL", TypeOfTrain = "S", Price = 60000 },
                new Fare { Id = 45, RouteId = 3, DistanceRange = 12000, TypeOfClass = "GE", TypeOfTrain = "S", Price = 30000 },

                new Fare { Id = 46, RouteId = 4, DistanceRange = 18000, TypeOfClass = "AC1", TypeOfTrain = "SF", Price = 550000 },
                new Fare { Id = 47, RouteId = 4, DistanceRange = 18000, TypeOfClass = "AC2", TypeOfTrain = "SF", Price = 350000 },
                new Fare { Id = 48, RouteId = 4, DistanceRange = 18000, TypeOfClass = "AC3", TypeOfTrain = "SF", Price = 250000 },
                new Fare { Id = 49, RouteId = 4, DistanceRange = 18000, TypeOfClass = "SL", TypeOfTrain = "SF", Price = 150000 },
                new Fare { Id = 50, RouteId = 4, DistanceRange = 18000, TypeOfClass = "GE", TypeOfTrain = "SF", Price = 55000 },

                new Fare { Id = 51, RouteId = 4, DistanceRange = 18000, TypeOfClass = "AC1", TypeOfTrain = "F", Price = 450000 },
                new Fare { Id =52, RouteId = 4, DistanceRange = 18000, TypeOfClass = "AC2", TypeOfTrain = "F", Price = 250000 },
                new Fare { Id =53, RouteId = 4, DistanceRange = 18000, TypeOfClass = "AC3", TypeOfTrain = "F", Price = 200000 },
                new Fare { Id = 54, RouteId = 4, DistanceRange = 18000, TypeOfClass = "SL", TypeOfTrain = "F", Price = 85000 },
                new Fare { Id = 55, RouteId = 4, DistanceRange = 18000, TypeOfClass = "GE", TypeOfTrain = "F", Price = 45000 },

                new Fare { Id = 56, RouteId = 4, DistanceRange = 18000, TypeOfClass = "AC1", TypeOfTrain = "S", Price = 390000 },
                new Fare { Id = 57, RouteId = 4, DistanceRange = 18000, TypeOfClass = "AC2", TypeOfTrain = "S", Price = 200000 },
                new Fare { Id = 58, RouteId = 4, DistanceRange = 18000, TypeOfClass = "AC3", TypeOfTrain = "S", Price = 160000 },
                new Fare { Id = 59, RouteId = 4, DistanceRange = 18000, TypeOfClass = "SL", TypeOfTrain = "S", Price = 65000 },
                new Fare { Id = 60, RouteId = 4, DistanceRange = 18000, TypeOfClass = "GE", TypeOfTrain = "S", Price = 35000 }
                );
        }
    }
}

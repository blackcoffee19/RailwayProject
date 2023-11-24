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
                new Train { TrainCode="SE1", Name= "Fast train HN-SG", TypeCode="F",IsRunning=true,Description= "Train SE1 is a fast train running on the North-South unified train route. The Railway industry is trying to improve service quality and train speed to increasingly meet the travel needs of customers." },
                new Train { TrainCode="SE2", Name= "Fast train SG-HN", TypeCode="F",IsRunning=true,Description= "Train SE2 is a fast train running on the unified North-South train route. The Railway industry is trying to improve service quality and train speed to increasingly meet the travel needs of customers." },
                new Train { TrainCode="SE3", Name= "Super Fast train HN-SG", TypeCode="SF",IsRunning=true,Description= "The SE3 train is the fastest and most beautiful train running on the unified North-South train route. The Railway industry is trying to improve service quality and train speed to increasingly meet the travel needs of customers." },
                new Train { TrainCode="SE4", Name= "Super Fast train SG-HN", TypeCode="SF",IsRunning=true,Description= "Train SE4 is the fastest and most beautiful train running on the North-South unified train route. The Railway industry is trying to improve service quality and train speed to increasingly meet the travel needs of customers." },
                new Train { TrainCode="SP1", Name= "Fast train HN-LC", TypeCode="F",IsRunning=true,Description= "The SP1 train is a fast train running the Hanoi - Lao Cai (Sapa) train route serving tourists, business travelers and other needs. This is a type of tourist train, the quality of the carriages and the service are quite good." },
                new Train { TrainCode="SP2", Name= "Fast train LC-HN", TypeCode="F", IsRunning = true,Description= "The SP2 train is a fast train running the Hanoi - Lao Cai (Sapa) train route to serve tourists, business travelers and other needs. This is a type of tourist train, the quality of the carriages and the service are quite good." }
                );
            modelBuilder.Entity<Class>().HasData(
                new Class {Id=1, TypeCode= "AC1",Name="Class S", NoOfCompartment=4, NoOfSeat=2, TrainCode="SE1",SeatAvailable=8,Description= "Personal cabin(4)or coupe(2seat)\nPrivacy\nHigh fare\nComfortable Seat\nU can carry your Dog" },
                new Class {Id=2, TypeCode= "AC1",Name="Class S", NoOfCompartment=4, NoOfSeat=2, TrainCode="SE1",SeatAvailable=8,Description= "Personal cabin(4)or coupe(2seat)\nPrivacy\nHigh fare\nComfortable Seat\nU can carry your Dog" },
                new Class {Id=3, TypeCode= "AC2",Name="Class A", NoOfCompartment=4, NoOfSeat=2, TrainCode="SE1",SeatAvailable=8,Description= "No privacy\nComparatively Comfortable\nAverage fare\nNo dogs allowed\nluggage spaceious" },
                new Class {Id=4, TypeCode= "AC3",Name="Class B", NoOfCompartment=6, NoOfSeat=2, TrainCode="SE1",SeatAvailable=8,Description= "Average Rush\nCooling worth comfort\nLess Lagague space\nAgain No Dogs" },
                new Class {Id=5, TypeCode= "SL",Name="Class C", NoOfCompartment=6, NoOfSeat=6, TrainCode="SE1",SeatAvailable=8,Description= "more comfor and amenities\nhigher fare" },
                new Class {Id=6, TypeCode= "GE",Name="Class D", NoOfCompartment=4, NoOfSeat=16, TrainCode="SE1",SeatAvailable=64,Description= "basic amenities\nbudget-friendly\nbench-type seats\nmore people" },
                new Class {Id=7, TypeCode= "AC1",Name="Class S", NoOfCompartment=6, NoOfSeat=2, TrainCode="SE2",SeatAvailable=8,Description= "Personal cabin(4)or coupe(2seat)\nPrivacy\nHigh fare\nComfortable Seat\nU can carry your Dog" },
                new Class {Id=8, TypeCode= "SL",Name="Class C", NoOfCompartment=6, NoOfSeat=2, TrainCode="SE2",SeatAvailable=8,Description= "Personal cabin(4)or coupe(2seat)\nPrivacy\nHigh fare\nComfortable Seat\nU can carry your Dog" }
                );

        }
    }
}

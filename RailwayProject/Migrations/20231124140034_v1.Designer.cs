﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RailwayProject.Models;

#nullable disable

namespace RailwayProject.Migrations
{
    [DbContext(typeof(RailwayDBContext))]
    [Migration("20231124140034_v1")]
    partial class v1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RailwayProject.Models.Class", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NoOfCompartment")
                        .HasColumnType("int");

                    b.Property<int>("NoOfSeat")
                        .HasColumnType("int");

                    b.Property<int>("SeatAvailable")
                        .HasColumnType("int");

                    b.Property<string>("TrainCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TypeCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("TrainCode");

                    b.ToTable("Classes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Personal cabin(4)or coupe(2seat)\nPrivacy\nHigh fare\nComfortable Seat\nU can carry your Dog",
                            Name = "Class S",
                            NoOfCompartment = 4,
                            NoOfSeat = 2,
                            SeatAvailable = 8,
                            TrainCode = "SE1",
                            TypeCode = "AC1"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Personal cabin(4)or coupe(2seat)\nPrivacy\nHigh fare\nComfortable Seat\nU can carry your Dog",
                            Name = "Class S",
                            NoOfCompartment = 4,
                            NoOfSeat = 2,
                            SeatAvailable = 8,
                            TrainCode = "SE1",
                            TypeCode = "AC1"
                        },
                        new
                        {
                            Id = 3,
                            Description = "No privacy\nComparatively Comfortable\nAverage fare\nNo dogs allowed\nluggage spaceious",
                            Name = "Class A",
                            NoOfCompartment = 4,
                            NoOfSeat = 2,
                            SeatAvailable = 8,
                            TrainCode = "SE1",
                            TypeCode = "AC2"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Average Rush\nCooling worth comfort\nLess Lagague space\nAgain No Dogs",
                            Name = "Class B",
                            NoOfCompartment = 6,
                            NoOfSeat = 2,
                            SeatAvailable = 8,
                            TrainCode = "SE1",
                            TypeCode = "AC3"
                        },
                        new
                        {
                            Id = 5,
                            Description = "more comfor and amenities\nhigher fare",
                            Name = "Class C",
                            NoOfCompartment = 6,
                            NoOfSeat = 6,
                            SeatAvailable = 8,
                            TrainCode = "SE1",
                            TypeCode = "SL"
                        },
                        new
                        {
                            Id = 6,
                            Description = "basic amenities\nbudget-friendly\nbench-type seats\nmore people",
                            Name = "Class D",
                            NoOfCompartment = 4,
                            NoOfSeat = 16,
                            SeatAvailable = 64,
                            TrainCode = "SE1",
                            TypeCode = "GE"
                        },
                        new
                        {
                            Id = 7,
                            Description = "Personal cabin(4)or coupe(2seat)\nPrivacy\nHigh fare\nComfortable Seat\nU can carry your Dog",
                            Name = "Class S",
                            NoOfCompartment = 6,
                            NoOfSeat = 2,
                            SeatAvailable = 8,
                            TrainCode = "SE2",
                            TypeCode = "AC1"
                        },
                        new
                        {
                            Id = 8,
                            Description = "Personal cabin(4)or coupe(2seat)\nPrivacy\nHigh fare\nComfortable Seat\nU can carry your Dog",
                            Name = "Class C",
                            NoOfCompartment = 6,
                            NoOfSeat = 2,
                            SeatAvailable = 8,
                            TrainCode = "SE2",
                            TypeCode = "SL"
                        });
                });

            modelBuilder.Entity("RailwayProject.Models.Fare", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DistanceRange")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("RouteId")
                        .HasColumnType("int");

                    b.Property<string>("TypeOfClass")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeOfTrain")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RouteId");

                    b.ToTable("Fares");
                });

            modelBuilder.Entity("RailwayProject.Models.Route", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Distance")
                        .HasColumnType("int");

                    b.Property<int>("EndStationId")
                        .HasColumnType("int");

                    b.Property<int>("StartStationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EndStationId");

                    b.HasIndex("StartStationId");

                    b.ToTable("Routes");
                });

            modelBuilder.Entity("RailwayProject.Models.RouteDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ArrivalStationId")
                        .HasColumnType("int");

                    b.Property<int>("DelayTime")
                        .HasColumnType("int");

                    b.Property<int>("DepartureStationId")
                        .HasColumnType("int");

                    b.Property<int>("Distance")
                        .HasColumnType("int");

                    b.Property<int>("RouteId")
                        .HasColumnType("int");

                    b.Property<int>("TravelTime")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ArrivalStationId");

                    b.HasIndex("DepartureStationId");

                    b.HasIndex("RouteId");

                    b.ToTable("RouteDetails");
                });

            modelBuilder.Entity("RailwayProject.Models.Schedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("EndAt")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<int?>("RouteId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<bool>("ScheduleCompleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("StartAt")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("TrainCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RouteId");

                    b.HasIndex("TrainCode");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("RailwayProject.Models.Station", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("NameOfDivision")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StationCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ZipCode")
                        .HasColumnType("int");

                    b.Property<string>("Zone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Stations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            NameOfDivision = "Ho Chi Minh City",
                            StationCode = "SGO",
                            StationName = "Sai Gon",
                            ZipCode = 700000,
                            Zone = "Southern"
                        },
                        new
                        {
                            Id = 2,
                            NameOfDivision = "Khanh Hoa Province",
                            StationCode = "NTR",
                            StationName = "Nha Trang",
                            ZipCode = 650000,
                            Zone = "Central"
                        },
                        new
                        {
                            Id = 3,
                            NameOfDivision = "Thua Thien Hue Province",
                            StationCode = "HUE",
                            StationName = "Hue",
                            ZipCode = 530000,
                            Zone = "Central"
                        },
                        new
                        {
                            Id = 4,
                            NameOfDivision = "Hanoi Capital",
                            StationCode = "HNO",
                            StationName = "Ha Noi",
                            ZipCode = 700000,
                            Zone = "North"
                        });
                });

            modelBuilder.Entity("RailwayProject.Models.Train", b =>
                {
                    b.Property<string>("TrainCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsRunning")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TrainCode");

                    b.ToTable("Trains");

                    b.HasData(
                        new
                        {
                            TrainCode = "SE1",
                            Description = "Train SE1 is a fast train running on the North-South unified train route. The Railway industry is trying to improve service quality and train speed to increasingly meet the travel needs of customers.",
                            IsRunning = true,
                            Name = "Fast train HN-SG",
                            TypeCode = "F"
                        },
                        new
                        {
                            TrainCode = "SE2",
                            Description = "Train SE2 is a fast train running on the unified North-South train route. The Railway industry is trying to improve service quality and train speed to increasingly meet the travel needs of customers.",
                            IsRunning = true,
                            Name = "Fast train SG-HN",
                            TypeCode = "F"
                        },
                        new
                        {
                            TrainCode = "SE3",
                            Description = "The SE3 train is the fastest and most beautiful train running on the unified North-South train route. The Railway industry is trying to improve service quality and train speed to increasingly meet the travel needs of customers.",
                            IsRunning = true,
                            Name = "Super Fast train HN-SG",
                            TypeCode = "SF"
                        },
                        new
                        {
                            TrainCode = "SE4",
                            Description = "Train SE4 is the fastest and most beautiful train running on the North-South unified train route. The Railway industry is trying to improve service quality and train speed to increasingly meet the travel needs of customers.",
                            IsRunning = true,
                            Name = "Super Fast train SG-HN",
                            TypeCode = "SF"
                        },
                        new
                        {
                            TrainCode = "SP1",
                            Description = "The SP1 train is a fast train running the Hanoi - Lao Cai (Sapa) train route serving tourists, business travelers and other needs. This is a type of tourist train, the quality of the carriages and the service are quite good.",
                            IsRunning = true,
                            Name = "Fast train HN-LC",
                            TypeCode = "F"
                        },
                        new
                        {
                            TrainCode = "SP2",
                            Description = "The SP2 train is a fast train running the Hanoi - Lao Cai (Sapa) train route to serve tourists, business travelers and other needs. This is a type of tourist train, the quality of the carriages and the service are quite good.",
                            IsRunning = true,
                            Name = "Fast train LC-HN",
                            TypeCode = "F"
                        });
                });

            modelBuilder.Entity("RailwayProject.Models.Class", b =>
                {
                    b.HasOne("RailwayProject.Models.Train", "Trains")
                        .WithMany("Classes")
                        .HasForeignKey("TrainCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Trains");
                });

            modelBuilder.Entity("RailwayProject.Models.Fare", b =>
                {
                    b.HasOne("RailwayProject.Models.Route", "Route")
                        .WithMany("Fares")
                        .HasForeignKey("RouteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Route");
                });

            modelBuilder.Entity("RailwayProject.Models.Route", b =>
                {
                    b.HasOne("RailwayProject.Models.Station", "EndStation")
                        .WithMany("EndRoutes")
                        .HasForeignKey("EndStationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RailwayProject.Models.Station", "StartStation")
                        .WithMany("StartRoutes")
                        .HasForeignKey("StartStationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EndStation");

                    b.Navigation("StartStation");
                });

            modelBuilder.Entity("RailwayProject.Models.RouteDetail", b =>
                {
                    b.HasOne("RailwayProject.Models.Station", "ArrivalStation")
                        .WithMany("ArrivalRouteDetails")
                        .HasForeignKey("ArrivalStationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RailwayProject.Models.Station", "DepartureStation")
                        .WithMany("DepartureRouteDetails")
                        .HasForeignKey("DepartureStationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RailwayProject.Models.Route", "Route")
                        .WithMany("RouteDetails")
                        .HasForeignKey("RouteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ArrivalStation");

                    b.Navigation("DepartureStation");

                    b.Navigation("Route");
                });

            modelBuilder.Entity("RailwayProject.Models.Schedule", b =>
                {
                    b.HasOne("RailwayProject.Models.Route", "Route")
                        .WithMany()
                        .HasForeignKey("RouteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RailwayProject.Models.Train", "Train")
                        .WithMany("Schedules")
                        .HasForeignKey("TrainCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Route");

                    b.Navigation("Train");
                });

            modelBuilder.Entity("RailwayProject.Models.Route", b =>
                {
                    b.Navigation("Fares");

                    b.Navigation("RouteDetails");
                });

            modelBuilder.Entity("RailwayProject.Models.Station", b =>
                {
                    b.Navigation("ArrivalRouteDetails");

                    b.Navigation("DepartureRouteDetails");

                    b.Navigation("EndRoutes");

                    b.Navigation("StartRoutes");
                });

            modelBuilder.Entity("RailwayProject.Models.Train", b =>
                {
                    b.Navigation("Classes");

                    b.Navigation("Schedules");
                });
#pragma warning restore 612, 618
        }
    }
}

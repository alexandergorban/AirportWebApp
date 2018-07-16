﻿// <auto-generated />
using System;
using AirportWebAPI.DataAccessLayer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AirportWebAPI.DataAccessLayer.Migrations
{
    [DbContext(typeof(AirportDbContext))]
    partial class AirportDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AirportWebAPI.DataAccessLayer.Entities.Airplane", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AirplaneTypeId");

                    b.Property<DateTime>("DateOfIssue");

                    b.Property<bool>("IsOwnAirplane");

                    b.Property<TimeSpan>("LifeTime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.HasIndex("AirplaneTypeId");

                    b.ToTable("Airplanes");
                });

            modelBuilder.Entity("AirportWebAPI.DataAccessLayer.Entities.AirplaneType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("LoadCapacity");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<int>("NumberOfSeats");

                    b.HasKey("Id");

                    b.ToTable("AirplaneTypes");
                });

            modelBuilder.Entity("AirportWebAPI.DataAccessLayer.Entities.AirportLocation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AirportName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.ToTable("AirportLocations");
                });

            modelBuilder.Entity("AirportWebAPI.DataAccessLayer.Entities.Crew", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("PilotId");

                    b.HasKey("Id");

                    b.HasIndex("PilotId");

                    b.ToTable("Crews");
                });

            modelBuilder.Entity("AirportWebAPI.DataAccessLayer.Entities.Departure", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AirplaneId");

                    b.Property<Guid>("CrewId");

                    b.Property<DateTime>("DepartureTime");

                    b.Property<DateTime>("DepartureTimeChanged");

                    b.Property<Guid>("FlightId");

                    b.Property<bool>("IsFlightDelay");

                    b.HasKey("Id");

                    b.HasIndex("AirplaneId");

                    b.HasIndex("CrewId");

                    b.HasIndex("FlightId");

                    b.ToTable("Departures");
                });

            modelBuilder.Entity("AirportWebAPI.DataAccessLayer.Entities.Flight", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("ArrivalTime");

                    b.Property<Guid?>("DeparturePointId");

                    b.Property<DateTime>("DepartureTime");

                    b.Property<Guid?>("DestinationPointId");

                    b.Property<string>("FlightNumber")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.HasIndex("DeparturePointId");

                    b.HasIndex("DestinationPointId");

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("AirportWebAPI.DataAccessLayer.Entities.Pilot", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<TimeSpan>("Experience");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Pilots");
                });

            modelBuilder.Entity("AirportWebAPI.DataAccessLayer.Entities.Stewardess", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CrewId");

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("CrewId");

                    b.ToTable("Stewardesses");
                });

            modelBuilder.Entity("AirportWebAPI.DataAccessLayer.Entities.Ticket", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("FlightId");

                    b.Property<long>("Number");

                    b.Property<float>("Price");

                    b.HasKey("Id");

                    b.HasIndex("FlightId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("AirportWebAPI.DataAccessLayer.Entities.Airplane", b =>
                {
                    b.HasOne("AirportWebAPI.DataAccessLayer.Entities.AirplaneType", "AirplaneType")
                        .WithMany()
                        .HasForeignKey("AirplaneTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AirportWebAPI.DataAccessLayer.Entities.Crew", b =>
                {
                    b.HasOne("AirportWebAPI.DataAccessLayer.Entities.Pilot", "Pilot")
                        .WithMany()
                        .HasForeignKey("PilotId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AirportWebAPI.DataAccessLayer.Entities.Departure", b =>
                {
                    b.HasOne("AirportWebAPI.DataAccessLayer.Entities.Airplane", "Airplane")
                        .WithMany()
                        .HasForeignKey("AirplaneId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AirportWebAPI.DataAccessLayer.Entities.Crew", "Crew")
                        .WithMany()
                        .HasForeignKey("CrewId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AirportWebAPI.DataAccessLayer.Entities.Flight", "Flight")
                        .WithMany()
                        .HasForeignKey("FlightId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AirportWebAPI.DataAccessLayer.Entities.Flight", b =>
                {
                    b.HasOne("AirportWebAPI.DataAccessLayer.Entities.AirportLocation", "DeparturePoint")
                        .WithMany()
                        .HasForeignKey("DeparturePointId");

                    b.HasOne("AirportWebAPI.DataAccessLayer.Entities.AirportLocation", "DestinationPoint")
                        .WithMany()
                        .HasForeignKey("DestinationPointId");
                });

            modelBuilder.Entity("AirportWebAPI.DataAccessLayer.Entities.Stewardess", b =>
                {
                    b.HasOne("AirportWebAPI.DataAccessLayer.Entities.Crew")
                        .WithMany("Stewardesses")
                        .HasForeignKey("CrewId");
                });

            modelBuilder.Entity("AirportWebAPI.DataAccessLayer.Entities.Ticket", b =>
                {
                    b.HasOne("AirportWebAPI.DataAccessLayer.Entities.Flight", "Flight")
                        .WithMany("Tickets")
                        .HasForeignKey("FlightId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using AirportWebAPI.DataAccessLayer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AirportWebAPI.DataAccessLayer.Migrations
{
    [DbContext(typeof(AirportDbContext))]
    [Migration("20180715131309_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<Guid>("DepartureId");

                    b.Property<bool>("IsOwnAirplane");

                    b.Property<TimeSpan>("LifeTime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.HasIndex("AirplaneTypeId");

                    b.HasIndex("DepartureId")
                        .IsUnique();

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

                    b.Property<Guid>("DepartureId");

                    b.Property<Guid>("PilotId");

                    b.HasKey("Id");

                    b.HasIndex("DepartureId")
                        .IsUnique();

                    b.HasIndex("PilotId")
                        .IsUnique();

                    b.ToTable("Crews");
                });

            modelBuilder.Entity("AirportWebAPI.DataAccessLayer.Entities.Departure", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DepartureTime");

                    b.Property<DateTime>("DepartureTimeChanged");

                    b.Property<bool>("IsFlightDelay");

                    b.HasKey("Id");

                    b.ToTable("Departures");
                });

            modelBuilder.Entity("AirportWebAPI.DataAccessLayer.Entities.Flight", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AirportLocationId");

                    b.Property<DateTime>("ArrivalTime");

                    b.Property<Guid>("DepartureId");

                    b.Property<DateTime>("DepartureTime");

                    b.Property<Guid>("DestinationPointId");

                    b.Property<string>("FlightNumber")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("AirportLocationId");

                    b.HasIndex("DepartureId")
                        .IsUnique();

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

                    b.Property<Guid>("CrewId");

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

                    b.Property<Guid>("OwnerId");

                    b.Property<float>("Price");

                    b.HasKey("Id");

                    b.HasIndex("FlightId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("AirportWebAPI.DataAccessLayer.Entities.Airplane", b =>
                {
                    b.HasOne("AirportWebAPI.DataAccessLayer.Entities.AirplaneType", "AirplaneType")
                        .WithMany("Airplanes")
                        .HasForeignKey("AirplaneTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AirportWebAPI.DataAccessLayer.Entities.Departure", "Departure")
                        .WithOne("Airplane")
                        .HasForeignKey("AirportWebAPI.DataAccessLayer.Entities.Airplane", "DepartureId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AirportWebAPI.DataAccessLayer.Entities.Crew", b =>
                {
                    b.HasOne("AirportWebAPI.DataAccessLayer.Entities.Departure", "Departure")
                        .WithOne("Crew")
                        .HasForeignKey("AirportWebAPI.DataAccessLayer.Entities.Crew", "DepartureId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AirportWebAPI.DataAccessLayer.Entities.Pilot", "Pilot")
                        .WithOne("Crew")
                        .HasForeignKey("AirportWebAPI.DataAccessLayer.Entities.Crew", "PilotId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AirportWebAPI.DataAccessLayer.Entities.Flight", b =>
                {
                    b.HasOne("AirportWebAPI.DataAccessLayer.Entities.AirportLocation", "DeparturePoint")
                        .WithMany("Flights")
                        .HasForeignKey("AirportLocationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AirportWebAPI.DataAccessLayer.Entities.Departure", "Departure")
                        .WithOne("Flight")
                        .HasForeignKey("AirportWebAPI.DataAccessLayer.Entities.Flight", "DepartureId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AirportWebAPI.DataAccessLayer.Entities.AirportLocation", "DestinationPoint")
                        .WithMany()
                        .HasForeignKey("DestinationPointId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AirportWebAPI.DataAccessLayer.Entities.Stewardess", b =>
                {
                    b.HasOne("AirportWebAPI.DataAccessLayer.Entities.Crew", "Crew")
                        .WithMany("Stewardesseses")
                        .HasForeignKey("CrewId")
                        .OnDelete(DeleteBehavior.Cascade);
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

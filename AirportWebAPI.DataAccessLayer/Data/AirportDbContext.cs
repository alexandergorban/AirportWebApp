﻿using System;
using System.Collections.Generic;
using System.Text;
using AirportWebAPI.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace AirportWebAPI.DataAccessLayer.Data
{
    public class AirportDbContext : DbContext
    {
        public DbSet<Airplane> Airplanes { get; set; }
        public DbSet<AirplaneType> AirplaneTypes { get; set; }
        public DbSet<AirportLocation> AirportLocations { get; set; }
        public DbSet<Crew> Crews { get; set; }
        public DbSet<Departure> Departures { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Pilot> Pilots { get; set; }
        public DbSet<Stewardess> Stewardesses { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        public AirportDbContext()
        {
            if (Database.EnsureCreated())
            {
                this.EnsureSeedDataForContext();
            }
        }

        public AirportDbContext(DbContextOptions<AirportDbContext> options)
            : base(options)
        {
            if (Database.EnsureCreated())
            {
                this.EnsureSeedDataForContext();
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=(localdb)\mssqllocaldb;database=AirportWebAppDB;integrated security=yes;connectretrycount=0;AttachDBFileName=c:\users\alexander\airportwebappdb.mdf");
            base.OnConfiguring(optionsBuilder);
        }
    }
}

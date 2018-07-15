using System;
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
            : base()
        {
            //Database.Migrate();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(LocalDb)\\MSSQLLocalDB;Database=AirportDB;Trusted_Connection=True;");
            base.OnConfiguring(optionsBuilder);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Ticket => Flight
            modelBuilder.Entity<Ticket>()
                .HasOne<Flight>(t => t.Flight)
                .WithMany(f => f.Tickets)
                .HasForeignKey(t => t.FlightId)
                .OnDelete(DeleteBehavior.Cascade);

            // Airplane => AirplaneType
            modelBuilder.Entity<Airplane>()
                .HasOne<AirplaneType>(at => at.AirplaneType)
                .WithMany(a => a.Airplanes)
                .HasForeignKey(at => at.AirplaneTypeId)
                .OnDelete(DeleteBehavior.Cascade);

            // Departure => 1.Flight 2.Crew 3.Airplane
            modelBuilder.Entity<Departure>()
                .HasOne<Flight>(d => d.Flight)
                .WithOne(f => f.Departure)
                .HasForeignKey<Flight>(d => d.DepartureId);

            modelBuilder.Entity<Departure>()
                .HasOne<Crew>(d => d.Crew)
                .WithOne(c => c.Departure)
                .HasForeignKey<Crew>(d => d.DepartureId);

            modelBuilder.Entity<Departure>()
                .HasOne<Airplane>(d => d.Airplane)
                .WithOne(a => a.Departure)
                .HasForeignKey<Airplane>(a => a.DepartureId);

            // Pilot => Crew
            modelBuilder.Entity<Pilot>()
                .HasOne<Crew>(p => p.Crew)
                .WithOne(c => c.Pilot)
                .HasForeignKey<Crew>(c => c.PilotId);

            // Stewardess  => Crew
            modelBuilder.Entity<Stewardess>()
                .HasOne<Crew>(s => s.Crew)
                .WithMany(c => c.Stewardesseses)
                .HasForeignKey(s => s.CrewId)
                .OnDelete(DeleteBehavior.Cascade);

            // AirportLocation => Flight
            modelBuilder.Entity<Flight>()
                .HasOne<AirportLocation>(f => f.DeparturePoint)
                .WithMany(a => a.Flights)
                .HasForeignKey(f => f.AirportLocationId);
        }
    }
}

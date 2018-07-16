using System;
using System.Collections.Generic;
using System.Text;

namespace AirportWebAPI.DataAccessLayer.Data
{
    public static class AirportDbContextExtensions
    {
        public static void EnsureSeedDataForContext(this AirportDbContext context)
        {
            DataSource dataSource = new DataSource();

            context.Airplanes.AddRange(dataSource.Airplanes);
            context.AirplaneTypes.AddRange(dataSource.AirplaneTypes);
            context.AirportLocations.AddRange(dataSource.AirportLocations);
            context.Crews.AddRange(dataSource.Crews);
            context.Departures.AddRange(dataSource.Departures);
            context.Flights.AddRange(dataSource.Flights);
            context.Pilots.AddRange(dataSource.Pilots);
            context.Stewardesses.AddRange(dataSource.Stewardesses);
            context.Tickets.AddRange(dataSource.Tickets);
            context.SaveChanges();
        }
    }
}

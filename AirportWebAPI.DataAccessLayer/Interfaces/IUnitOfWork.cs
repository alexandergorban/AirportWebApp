using System;
using System.Collections.Generic;
using System.Text;
using AirportWebAPI.DataAccessLayer.Models;

namespace AirportWebAPI.DataAccessLayer.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<AirplaneType> AirplaneTypes { get; }
        IRepository<Airplane> Airplanes { get; }
        IRepository<Pilot> Pilots { get; }
        IRepository<Stewardess> Stewardesses { get; }
        IRepository<Crew> Crews { get; }
        IRepository<AirportLocation> AirportLocations { get; }
        IRepository<Flight> Flights { get; }
        IRepository<Ticket> Tickets { get; }
        IRepository<Departure> Departures { get; }
    }
}

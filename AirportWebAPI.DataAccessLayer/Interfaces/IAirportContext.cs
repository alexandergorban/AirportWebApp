using System;
using System.Collections.Generic;
using System.Text;
using AirportWebAPI.DataAccessLayer.Models;

namespace AirportWebAPI.DataAccessLayer.Interfaces
{
    interface IAirportContext
    {
        List<AirplaneType> AirplaneTypes { get; set; }
        List<Airplane> Airplanes { get; set; }
        List<Pilot> Pilots { get; set; }
        List<Stewardess> Stewardesses { get; set; }
        List<Crew> Crews { get; set; }
        List<AirportLocation> AirportLocations { get; set; }
        List<Flight> Flights { get; set; }
        List<Ticket> Tickets { get; set; }
        List<Departure> Departures { get; set; }

        int SaveChanges();
    }
}

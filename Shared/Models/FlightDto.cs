using System;
using System.Collections.Generic;
using System.Text;

namespace AirportWebAPI.DataAccessLayer.Models
{
    class FlightDto
    {
        public Guid Id { get; set; }
        public uint FlightNumber { get; set; }
        public AirportLocationDto DeparturePoint { get; set; }
        public DateTime DepartureTime { get; set; }
        public AirportLocationDto DestinationPoint { get; set; }
        public DateTime ArrivalTime { get; set; }
        public List<TicketDto> Tickets { get; set; }
    }
}

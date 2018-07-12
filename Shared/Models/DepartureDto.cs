using System;
using System.Collections.Generic;
using System.Text;

namespace AirportWebAPI.DataAccessLayer.Models
{
    class DepartureDto
    {
        public uint Id { get; set; }
        public DateTime DepartureTime { get; set; }
        public bool IsFlightDelay { get; set; }
        public DateTime DepartureTimeChanged { get; set; }
        public FlightDto Flight { get; set; }
        public CrewDto Crew { get; set; }
        public AirplaneDto Airplane { get; set; }
    }
}

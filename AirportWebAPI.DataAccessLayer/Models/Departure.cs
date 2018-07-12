using System;
using System.Collections.Generic;
using System.Text;

namespace AirportWebAPI.DataAccessLayer.Models
{
    public class Departure
    {
        public Guid Id { get; set; }
        public DateTime DepartureTime { get; set; }
        public bool IsFlightDelay { get; set; }
        public DateTime DepartureTimeChanged { get; set; }
        public Flight Flight { get; set; }
        public Crew Crew { get; set; }
        public Airplane Airplane { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace AirportWebAPI.DataAccessLayer.Models
{
    class TicketDto
    {
        public Guid Id { get; set; }
        public uint Number { get; set; }
        public float Price { get; set; }
        public string FlightId { get; set; }
    }
}

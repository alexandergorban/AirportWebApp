using System;
using System.Collections.Generic;
using System.Text;

namespace AirportWebAPI.DataAccessLayer.Models
{
    class Ticket
    {
        public uint Id { get; set; }
        public uint  Number { get; set; }
        public float Price { get; set; }
        public uint FlightNumber { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace AirportWebAPI.DataAccessLayer.Models
{
    class TicketDto
    {
        public int Id { get; set; }
        public int  Number { get; set; }
        public float Price { get; set; }
        public int FlightNumber { get; set; }
    }
}

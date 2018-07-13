using System;
using System.Collections.Generic;
using System.Text;
using Shared.Interfaces;

namespace AirportWebAPI.DataAccessLayer.Models
{
    public class TicketDto : IModelDto
    {
        public Guid Id { get; set; }
        public uint Number { get; set; }
        public float Price { get; set; }
        public string FlightId { get; set; }
    }
}

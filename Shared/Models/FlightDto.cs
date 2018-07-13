﻿using System;
using System.Collections.Generic;
using System.Text;
using Shared.Interfaces;

namespace AirportWebAPI.DataAccessLayer.Models
{
    public class FlightDto : IModelDto
    {
        public Guid Id { get; set; }
        public string FlightNumber { get; set; }
        public AirportLocationDto DeparturePoint { get; set; }
        public DateTime DepartureTime { get; set; }
        public AirportLocationDto DestinationPoint { get; set; }
        public DateTime ArrivalTime { get; set; }
        public List<TicketDto> Tickets { get; set; }
    }
}

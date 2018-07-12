﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AirportWebAPI.DataAccessLayer.Models
{
    public class Flight
    {
        public Guid Id { get; set; }
        public string FlightNumber { get; set; }
        public AirportLocation DeparturePoint { get; set; }
        public DateTime DepartureTime { get; set; }
        public AirportLocation DestinationPoint { get; set; }
        public DateTime ArrivalTime { get; set; }
        public List<Ticket> Tickets { get; set; }
    }
}

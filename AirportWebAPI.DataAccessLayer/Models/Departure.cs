﻿using System;
using System.Collections.Generic;
using System.Text;
using AirportWebAPI.DataAccessLayer.Interfaces;

namespace AirportWebAPI.DataAccessLayer.Models
{
    public class Departure : IEntity
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

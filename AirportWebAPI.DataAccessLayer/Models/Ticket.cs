﻿using System;
using System.Collections.Generic;
using System.Text;
using AirportWebAPI.DataAccessLayer.Interfaces;

namespace AirportWebAPI.DataAccessLayer.Models
{
    public class Ticket : IEntity
    {
        public Guid Id { get; set; }
        public uint  Number { get; set; }
        public float Price { get; set; }
        public string FlightId { get; set; }
    }
}

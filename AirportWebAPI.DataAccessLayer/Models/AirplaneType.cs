using System;
using System.Collections.Generic;
using System.Text;
using AirportWebAPI.DataAccessLayer.Interfaces;

namespace AirportWebAPI.DataAccessLayer.Models
{
    public class AirplaneType : IEntity
    {
        public Guid Id { get; set; }
        public string Model { get; set; }
        public int NumberOfSeats { get; set; }
        public int LoadCapacity { get; set; }
    }
}

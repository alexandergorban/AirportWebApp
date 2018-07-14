using System;
using System.Collections.Generic;
using System.Text;
using AirportWebAPI.DataAccessLayer.Interfaces;

namespace AirportWebAPI.DataAccessLayer.Entities
{
    public class Airplane : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public AirplaneType AirplaneType { get; set; }
        public DateTime DateOfIssue { get; set; }
        public TimeSpan LifeTime { get; set; }
        public bool IsOwnAirplane { get; set; }
    }
}

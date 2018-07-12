using System;
using System.Collections.Generic;
using System.Text;

namespace AirportWebAPI.DataAccessLayer.Models
{
    class Airplane
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public AirplaneType AirplaneType { get; set; }
        public DateTime DateOfIssue { get; set; }
        public TimeSpan LifeTime { get; set; }
        public bool IsOwnAirplane { get; set; }
    }
}

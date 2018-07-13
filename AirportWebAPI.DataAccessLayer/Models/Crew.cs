using System;
using System.Collections.Generic;
using System.Text;
using AirportWebAPI.DataAccessLayer.Interfaces;

namespace AirportWebAPI.DataAccessLayer.Models
{
    public class Crew : IEntity
    {
        public Guid Id { get; set; }
        public Pilot Pilot { get; set; }
        public List<Stewardess> Stewardesseses { get; set; }
    }
}

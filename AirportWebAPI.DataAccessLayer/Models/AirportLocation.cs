using System;
using System.Collections.Generic;
using System.Text;
using AirportWebAPI.DataAccessLayer.Interfaces;

namespace AirportWebAPI.DataAccessLayer.Models
{
    public class AirportLocation : IEntity
    {
        public Guid Id { get; set; }
        public string AirportName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
    }
}

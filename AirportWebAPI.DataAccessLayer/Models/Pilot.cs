using System;
using System.Collections.Generic;
using System.Text;

namespace AirportWebAPI.DataAccessLayer.Models
{
    public class Pilot
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public TimeSpan Experience { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace AirportWebAPI.DataAccessLayer.Models
{
    public class Crew
    {
        public Guid Id { get; set; }
        public Pilot Pilot { get; set; }
        public List<Stewardess> Stewardesseses { get; set; }
    }
}

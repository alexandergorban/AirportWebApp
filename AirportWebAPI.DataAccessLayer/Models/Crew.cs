using System;
using System.Collections.Generic;
using System.Text;

namespace AirportWebAPI.DataAccessLayer.Models
{
    class Crew
    {
        public uint Id { get; set; }
        public Pilot Pilot { get; set; }
        public List<Stewardesses> Stewardesseses { get; set; }
    }
}

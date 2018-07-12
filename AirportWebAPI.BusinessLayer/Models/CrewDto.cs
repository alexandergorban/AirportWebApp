using System;
using System.Collections.Generic;
using System.Text;

namespace AirportWebAPI.DataAccessLayer.Models
{
    class CrewDto
    {
        public uint Id { get; set; }
        public PilotDto Pilot { get; set; }
        public List<StewardessesDto> Stewardesseses { get; set; }
    }
}

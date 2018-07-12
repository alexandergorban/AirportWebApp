using System;
using System.Collections.Generic;
using System.Text;

namespace AirportWebAPI.DataAccessLayer.Models
{
    class CrewDto
    {
        public Guid Id { get; set; }
        public PilotDto Pilot { get; set; }
        public List<StewardessDto> Stewardesseses { get; set; }
    }
}

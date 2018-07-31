using System;
using System.Collections.Generic;
using System.Text;
using AirportWebAPI.DataAccessLayer.Entities;

namespace Shared.Models.Json
{
    public class JsonCrewDto
    {
        public int Id { get; set; }
        public List<JsonPilotDto> Pilot { get; set; }
        public List<JsonStewardessDto> Stewardess { get; set; }
    }
}

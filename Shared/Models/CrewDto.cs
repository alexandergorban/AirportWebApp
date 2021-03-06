﻿using System;
using System.Collections.Generic;
using System.Text;
using Shared.Interfaces;

namespace AirportWebAPI.DataAccessLayer.Entities
{
    public class CrewDto : IModelDto
    {
        public Guid Id { get; set; }
        public PilotDto Pilot { get; set; }
        public List<StewardessDto> Stewardesses { get; set; }
    }
}

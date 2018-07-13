using System;
using System.Collections.Generic;
using System.Text;
using Shared.Interfaces;

namespace AirportWebAPI.DataAccessLayer.Models
{
    class AirplaneTypeDto : IModelDto
    {
        public Guid Id { get; set; }
        public string Model { get; set; }
        public int NumberOfSeats { get; set; }
        public int LoadCapacity { get; set; }
    }
}

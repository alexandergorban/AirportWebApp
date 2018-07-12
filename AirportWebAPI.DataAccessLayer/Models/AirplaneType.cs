using System;
using System.Collections.Generic;
using System.Text;

namespace AirportWebAPI.DataAccessLayer.Models
{
    class AirplaneType
    {
        public uint Id { get; set; }
        public string Model { get; set; }
        public int NumberOfSeats { get; set; }
        public int LoadCapacity { get; set; }
    }
}

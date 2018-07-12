using System;
using System.Collections.Generic;
using System.Text;

namespace AirportWebAPI.DataAccessLayer.Models
{
    class AirportLocation
    {
        public Guid Id { get; set; }
        public string AirportName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
    }
}

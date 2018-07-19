using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Models.Json
{
    public class JsonPilotDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public int Exp { get; set; }
        public Guid CrewId { get; set; }
    }
}

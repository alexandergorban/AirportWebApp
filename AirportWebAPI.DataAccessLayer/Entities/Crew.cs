using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using AirportWebAPI.DataAccessLayer.Interfaces;

namespace AirportWebAPI.DataAccessLayer.Entities
{
    public class Crew : IEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Pilot Pilot { get; set; }
        public Guid PilotId { get; set; }

        [Required]
        public List<Stewardess> Stewardesseses { get; set; } = new List<Stewardess>();

        public Departure Departure { get; set; }
        public Guid DepartureId { get; set; }
    }
}

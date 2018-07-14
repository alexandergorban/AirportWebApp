using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Required]
        public List<Stewardess> Stewardesseses { get; set; }
    }
}

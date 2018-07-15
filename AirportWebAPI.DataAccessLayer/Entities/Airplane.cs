using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using AirportWebAPI.DataAccessLayer.Interfaces;

namespace AirportWebAPI.DataAccessLayer.Entities
{
    public class Airplane : IEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        public AirplaneType AirplaneType { get; set; }
        public Guid AirplaneTypeId { get; set; }

        [Required]
        public DateTime DateOfIssue { get; set; }

        [Required]
        public TimeSpan LifeTime { get; set; }

        [Required]
        public bool IsOwnAirplane { get; set; }

        public Departure Departure { get; set; }
        public Guid DepartureId { get; set; }
    }
}

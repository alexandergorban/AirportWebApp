using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Required]
        public DateTime DateOfIssue { get; set; }

        [Required]
        public TimeSpan LifeTime { get; set; }

        [Required]
        public bool IsOwnAirplane { get; set; }
    }
}

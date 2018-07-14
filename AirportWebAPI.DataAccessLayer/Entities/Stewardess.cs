using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using AirportWebAPI.DataAccessLayer.Interfaces;

namespace AirportWebAPI.DataAccessLayer.Entities
{
    public class Stewardess : IEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Surname { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }
    }
}

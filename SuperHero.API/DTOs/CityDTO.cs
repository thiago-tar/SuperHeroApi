﻿using SuperHero.Dominio.Models;
using System.ComponentModel.DataAnnotations;

namespace SuperHero.API.DTOs
{
    public class CityDTO
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public IEnumerable<Hero> Heros { get; set; }
    }
}

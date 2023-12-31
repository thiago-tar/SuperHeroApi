﻿using AutoMapper.Configuration.Annotations;
using SuperHero.Dominio.Models;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Runtime.InteropServices;
using System.Text.Json.Serialization;

namespace SuperHero.API.DTOs
{
    public class HeroDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public int CityId { get; set; }

        public City? City { get; set; }
    }
}

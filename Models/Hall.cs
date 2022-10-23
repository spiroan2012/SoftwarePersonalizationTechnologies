﻿using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Hall
    {
        [Key]
        public int Id { get; init; }
        [Required]
        [MaxLength(60)]
        public string? Title { get; set; }
        [Required]
        [MaxLength(500)]
        public string? Description { get; set; }
        [Required]
        public string? Address { get; set; }
        [Required]
        [Range(0, 60)]
        public int Capacity { get; set; }
        [Required]
        [Phone]
        public string? Phone { get; set; }
        [Required]
        [EmailAddress]
        public string? EmailAddress { get; set; }
        public string? Area { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public ICollection<Show>? Shows { get; set; }
    }
}

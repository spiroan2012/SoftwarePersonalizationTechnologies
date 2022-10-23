﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Show
    {
        [Key]
        public int Id { get; init; }
        [Required]
        [MaxLength(60)]
        public string? Title { get; init; }
        [Required]
        [MaxLength(600)]
        public string? Description { get; init; }
        [Required]
        public string? Actors { get; set; }
        [Required]
        public string? Directors { get; set; }
        [Required]
        [Column(TypeName = "date")]
        public DateTime DateStart { get; set; }
        [Required]
        [Column(TypeName = "date")]
        public DateTime DateEnd { get; set; }
        [Required]
        public DateTime TimeStart { get; set; }
        [Required]
        public int Duration { get; init; } = 90;
        [Required]
        public Hall? Hall { get; set; }
        [Required]
        public Genre? Genre { get; set; }
    }
}

﻿using Dtos.Responses;

namespace Dtos.Requests
{
    public class CreateShowDto
    {
        public string? Title { get; init; }
        public string? Description { get; init; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public DateTime TimeStart { get; set; }
        public string[]? Actors { get; set; }
        public string[]? Directors { get; set; }
        public int Duration { get; init; }
        public int HallId { get; set; }
        public int GenreId { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Dtos.Responses
{
    public class HallDto
    {
        public int Id { get; init; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public string? Address { get; set; }
        [Required]
        public int Capacity { get; set; }
        [Required]
        public string? Phone { get; set; }
        [Required]
        public string? EmailAddress { get; set; }
        [Required]
        [Range(-90.0, 90.0)]
        public double Latitude { get; set; }
        [Required]
        [Range(-90.0, 90.0)]
        public double Longitude { get; set; }
        public ICollection<ShowDto>? Shows { get; set; }
    }
}

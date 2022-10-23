using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Booking
    {
        [Key]
        public int Id { get; init; }
        [Required]
        public Show? Show { get; init; }
        [Required]
        public DateTime BookingTimestamp { get; init; } = DateTime.Now;
        [Required]
        public DateTime DateOfShow { get; set; }
        [Required]
        public AppUser? User { get; set; }
        [Required]
        public int NumOfSeats { get; init; } = 50;
        public bool Appeared { get; set; }
        public ICollection<Seat>? Seats { get; set; }
    }
}

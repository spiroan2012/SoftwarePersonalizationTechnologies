namespace Models
{
    public class Seat
    {
        public int Id { get; init; }
        public Booking? Booking { get; init; }
        public string? SeatNumber { get; set; }
    }
}

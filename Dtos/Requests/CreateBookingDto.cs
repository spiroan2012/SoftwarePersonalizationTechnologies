namespace Dtos.Requests
{
    public class CreateBookingDto
    {
        public int ShowId { get; init; }
        public DateTime DateOfShow { get; set; }
        public string[]? Seats { get; set; }
    }
}

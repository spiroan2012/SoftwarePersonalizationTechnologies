using Dtos.Requests;
using Dtos.Responses;
using Microsoft.AspNetCore.Http;

namespace Intefaces.Services
{
    public interface IBookingService
    {
        Task<BookingDto> CreateBooking(CreateBookingDto createBookingDto, int userId);
        Task<IList<BookingDto>> GetBookingsForLoggedUser(int userId);
        Task<IList<BookingDto>> GetBookingsForShowAndDate(int showId, DateTime showDate);
        Task<IList<BookingDto>> GetBookingForUserByEmail(FileDto model);
        Task<bool> UpdateBookingToAppeared(int id);
        Task<bool> SaveFileAsync(IFormFile? file);
    }
}

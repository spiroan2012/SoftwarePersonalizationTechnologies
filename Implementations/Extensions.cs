using Dtos.Responses;
using GeoCoordinatePortable;
using Microsoft.AspNetCore.Http;
using Models;
using Models.Params;
using System.Security.Claims;
using System.Text.Json;

namespace Implementations
{
    public static class Extensions
    {
        public static void AddPaginationHeader(this HttpResponse response, int currentPage, int itemsPerPage, int totalItems, int totalPages)
        {
            var paginationHeader = new PaginationHelper(currentPage, itemsPerPage, totalItems, totalPages);

            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            response.Headers.Add("Pagination", JsonSerializer.Serialize(paginationHeader, options));
            response.Headers.Add("Access-Control-Expose-Headers", "Pagination");
        }
        public static string GetUsername(this ClaimsPrincipal user)
        {
            return user.FindFirst(ClaimTypes.Name)?.Value ?? throw new Exception();
        }

        public static int GetUserId(this ClaimsPrincipal user)
        {
            return int.Parse(user.FindFirst(ClaimTypes.NameIdentifier)!.Value);
        }
        public static bool CheckSeatsAvailability(string[] userPreferences, string[] booked)
        {
            return userPreferences.Any(x => booked.Any(y => y.Equals(x)));
        }

        public static bool IsValidSeat(int capacity, string seat)
        {
            int seatNum = int.Parse(seat);
            return seatNum >= 1 && seatNum <= capacity;
        }

        public static bool NumOfRequestedSeatsMoreThanAvailable(int available, int numRequested)
        {
            return available < numRequested;
        }

        public static SeatsShowDto[] CreateArrayOfSeats(string[] reservedSeats, int capacity)
        {
            List<SeatsShowDto> seats = new();
            for (int i = 1; i <= capacity; i++)
            {
                seats.Add(new SeatsShowDto
                {
                    SeatNumber = i.ToString(),
                    IsAvailable = !reservedSeats.Contains(i.ToString())
                });
            }
            return seats.ToArray();
        }
        public static string CreateEmailText(this AppUser user, string title, string dateOfShow, string timeOfShow, string seats)
        {
            return "Αγαπητέ/ή " + user.FirstName + " " + user.LastName +
                "\n\nΗ κράτηση σου για την παράσταση " + title + " στις " + dateOfShow + " και ώρα " + timeOfShow +
                " ολοκληρώθηκε με επιτυχία. Οι θέσεις σας είναι " + seats + ". Παρακαλω΄να είστε στον χώρο του θεάτρου τουλάχιστον μισή ώρα πριν.\n\n" +
                "Ευχαριστούμε για την προτίμηση και την εμπιστοσύνη.\n\nΜε εκτίμηση,\n\nΗ ομάδα του ShowBooking";
        }

        public static List<Show> GetShowsWithinDistance(GeoCoordinate userLoc, IList<Show> recShows)
        {
            List<Show> finalShows = new List<Show>();

            foreach(var recShow in recShows)
            {
                var distance = userLoc.GetDistanceTo(new GeoCoordinate(recShow.Hall.Latitude, recShow.Hall.Longitude));

                if(distance <= 5000)
                {
                    finalShows.Add(recShow);
                }
            }

            return finalShows;
        }
    }
}
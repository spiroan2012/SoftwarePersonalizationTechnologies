using Microsoft.AspNetCore.Identity;
using System.Collections;

namespace Models
{
    public class AppUser : IdentityUser<int>
    {
        public DateTime DateOfBirth { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public string? Gender { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public bool IsDisabled { get; set; } = false;
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public ICollection<AppUserRole>? UserRoles { get; set; }
        public ICollection<Genre>? Genres { get; set; }
    }
}

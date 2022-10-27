using Implementations;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.Params;
using PagedListForEFCore;

namespace Intefaces.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly BookingContext _context;

        public UserRepository(BookingContext context)
        {
            _context = context;
        }
        public async Task<AppUser?> GetUserByIdAsync(int id)
        {
            return await _context.Users
                .FindAsync(id);
        }

        public async Task<AppUser?> GetUserByUsernameAsync(string? username)
        {
            var user = await _context.Users
                .SingleOrDefaultAsync(x => x.UserName == username);
            return user;
        }

        public async Task<AppUser?> GetUserByEmailAsync(string? email)
        {
            var user = await _context.Users
                .SingleOrDefaultAsync(x => x.Email == email);
            return user;
        }

        public async Task<PagedList<AppUser>> GetUsersAsync(UserParams userParams)
        {
            var query = _context.Users.AsQueryable();

            if (!string.IsNullOrWhiteSpace(userParams.SearchUsername))
            {
                query = query.Where(x => x.UserName.Contains(userParams.SearchUsername));
            }

            query = userParams.OrderBy switch
            {
                "username" => query.OrderByDescending(s => s.UserName),
                _ => query.OrderByDescending(s => s.CreationDate)
            };

            return await PagedList<AppUser>.CreateAsync(query, userParams.PageNumber, userParams.PageSize);
        }

        public void Update(AppUser user)
        {
            _context.Entry(user).State = EntityState.Modified;
        }

        public async Task<string> HealthCheck()
        {
            var result = await _context.Users.FromSqlRaw("select top 1 1 as Id from dbo.AspNetUsers ").Select(res => new { Id = res.Id.ToString() }).FirstOrDefaultAsync();
            return result!.Id.ToString();
        }

        public void UpdateUserLocationAsync(AppUser? user, double longt, double lat)
        {
            user.Latitude = lat;
            user.Longitude = longt;

            _context.Entry(user!).State = EntityState.Modified;
        }

        public async Task<bool> Complete()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}

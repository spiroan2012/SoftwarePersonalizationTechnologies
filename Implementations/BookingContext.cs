
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models;
using System.Reflection;

namespace Implementations
{
    public class BookingContext : IdentityDbContext<AppUser, AppRole, int,
                                IdentityUserClaim<int>, AppUserRole, IdentityUserLogin<int>,
                                IdentityRoleClaim<int>, IdentityUserToken<int>>
    {

        public BookingContext(DbContextOptions<BookingContext> options) : base(options)
        {
        }
        public DbSet<Hall>? Halls { get; set; }
        public DbSet<Show>? Shows { get; set; }
        public DbSet<Booking>? Bookings { get; set; }
        public DbSet<Seat>? Seats { get; set; }
        public DbSet<Genre>? Genres { get; set; }
       // public DbSet<UserGenres>? UserGenres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Hall>()
                .HasMany(sh => sh.Shows)
                .WithOne(sh => sh.Hall);
            modelBuilder.Entity<AppUser>()
                .HasMany(ur => ur.UserRoles)
                .WithOne(ur => ur.User)
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();

            modelBuilder.Entity<AppRole>()
                .HasMany(ur => ur.UserRoles)
                .WithOne(ur => ur.Role)
                .HasForeignKey(ur => ur.RoleId)
                .IsRequired();

            modelBuilder.Entity<Genre>()
                .HasMany(g => g.Users)
                .WithMany(g => g.Genres)
                .UsingEntity(g => g.ToTable("UserGenres"));
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}

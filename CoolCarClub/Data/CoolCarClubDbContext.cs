using CoolCarClub.Models;
using Microsoft.EntityFrameworkCore;

namespace CoolCarClub.Data
{
    public class CoolCarClubDbContext : DbContext
    {
        // constructor just calls the base class constructor
        public CoolCarClubDbContext(
           DbContextOptions<CoolCarClubDbContext> options) : base(options) { }

        // one DbSet for each domain model class
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Message> Messages { get; set; }
    }

}

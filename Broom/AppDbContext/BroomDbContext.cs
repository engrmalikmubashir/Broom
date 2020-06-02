using Broom.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace Broom.AppDbContext
{
    public class BroomDbContext : IdentityDbContext<IdentityUser>
    {
        public BroomDbContext(DbContextOptions<BroomDbContext> options) : base(options)
        {

        }

        public DbSet<Make> Makes { get; set; }
        public DbSet<BModel> BModels { get; set; }
        public DbSet<Bike> Bikes { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    }
}

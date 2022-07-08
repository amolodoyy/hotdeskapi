using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using HotDeskSystemApi.Data.Entities;


namespace HotDeskSystemApi.Data
{
    public class AppDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public AppDbContext(IConfiguration configuration) : base() => _configuration = configuration;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                _configuration.GetConnectionString("DefaultConnection"));
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Desk> Desks { get; set; }
    }
}

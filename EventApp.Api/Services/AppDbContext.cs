using EventApp.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace EventApp.Api.Services
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public required DbSet<Event> Events { get; set; }
    }
}

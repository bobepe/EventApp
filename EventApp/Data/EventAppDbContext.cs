using EventApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EventApp.Data
{
    public class EventAppDbContext : DbContext
    {
        public EventAppDbContext(DbContextOptions<EventAppDbContext> options) : base(options) { }

        public DbSet<Person> People { get; set; }
        public DbSet<Item> items { get; set; }
    }
}

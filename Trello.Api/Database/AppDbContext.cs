using Microsoft.EntityFrameworkCore;
using Trello.Api.Models;

namespace Trello.Api.Database
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
    }
}

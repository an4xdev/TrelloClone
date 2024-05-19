using Microsoft.EntityFrameworkCore;
using Trello.Api.Models;
using Trello.Shared;

namespace Trello.Api.Database
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Template> Templates { get; set; }
        public DbSet<Column> Columns { get; set; }

        public DbSet<Item> Items { get; set; }

        public DbSet<ColumnTemplate> ColumnTemplates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Template>().HasData(
                new Template()
                {
                    Name = "Default",
                    TemplateID = 1
                }
            );

            modelBuilder.Entity<Column>().HasData(
                new Column()
                {
                    ColumnID = 1,
                    Name = "TODO"
                },
                new Column()
                {
                    ColumnID = 2,
                    Name = "In progress"
                },
                new Column()
                {
                    ColumnID = 3,
                    Name = "Done"
                });
            modelBuilder.Entity<ColumnTemplate>().HasData(
                new ColumnTemplate()
                {
                    ID = 1,
                    TID = 1,
                    CID = 1,
                },
                new ColumnTemplate()
                {
                    ID = 2,
                    TID = 1,
                    CID = 2,
                },
                new ColumnTemplate()
                {
                    ID = 3,
                    TID = 1,
                    CID = 3,
                });
        }
    }
}

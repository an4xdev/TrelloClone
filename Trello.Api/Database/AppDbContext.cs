using Microsoft.EntityFrameworkCore;
using Trello.Api.Models;

namespace Trello.Api.Database
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Template> Templates { get; set; }
        public DbSet<Column> Columns { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Template>()
                .HasKey(t => t.ID);

            modelBuilder.Entity<Column>()
                .HasKey(t => t.ID);

            modelBuilder.Entity<Project>()
                .HasKey(p => p.ID);

            modelBuilder.Entity<Item>()
                .HasKey(p => p.ID);

            modelBuilder.Entity<Template>()
            .HasMany(t => t.Columns)
            .WithOne(c => c.Template)
            .HasForeignKey(c => c.TemplateID);

            modelBuilder.Entity<Project>()
                .HasOne(p => p.Template)
                .WithMany()
                .HasForeignKey(p => p.TemplateID);

            modelBuilder.Entity<Project>()
                .HasMany(p => p.Items)
                .WithOne(i => i.Project)
                .HasForeignKey(i => i.ProjectID);

            modelBuilder.Entity<Column>()
                .HasMany(c => c.Items)
                .WithOne(i => i.Column)
                .HasForeignKey(i => i.ColumnID);

            modelBuilder.Entity<Template>().HasData(new Template { ID = 1, Name = "Default" });

            modelBuilder.Entity<Column>().HasData(
                new Column { ID = 1, Name = "TODO", TemplateID = 1 },
                new Column { ID = 2, Name = "In progress", TemplateID = 1 },
                new Column { ID = 3, Name = "Done", TemplateID = 1 }
            );

            modelBuilder.Entity<Project>().HasData(new Project { ID = 1, Name = "Default Project", TemplateID = 1, Description = "Default description of default project." });

            modelBuilder.Entity<Item>().HasData(
                new Item { ID = 1, Name = "Get ready", Description = "Get ready to your project", ProjectID = 1, ColumnID = 1 },
                new Item { ID = 2, Name = "Plan it", Description = "You are planning your project", ProjectID = 1, ColumnID = 2 },
                new Item { ID = 3, Name = "Pet capybara", Description = "You petted capybara", ProjectID = 1, ColumnID = 3 }
            );

        }
    }
}

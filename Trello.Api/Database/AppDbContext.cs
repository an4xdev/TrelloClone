using Microsoft.EntityFrameworkCore;
using Trello.Api.Models;

namespace Trello.Api.Database;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<Template> Templates { get; set; }
    public DbSet<Column> Columns { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<ItemTag> ItemTags { get; set; }

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
            new Column { ID = 3, Name = "Done", TemplateID = 1, MarkAsDone = true }
        );

        modelBuilder.Entity<Project>().HasData(new Project { ID = 1, Name = "Default Project", TemplateID = 1, Description = "Default description of default project." });

        modelBuilder.Entity<Tag>().HasData(
            new Tag { ID = 1, Name = "High Priority", BackgroundColor = "#FF5733", FontColor = "#FFFFFF" },
            new Tag { ID = 2, Name = "Medium Priority", BackgroundColor = "#FFC300", FontColor = "#000000" },
            new Tag { ID = 3, Name = "Low Priority", BackgroundColor = "#DAF7A6", FontColor = "#000000" },
            new Tag { ID = 4, Name = "Completed", BackgroundColor = "#33FF57", FontColor = "#000000" },
            new Tag { ID = 5, Name = "In Progress", BackgroundColor = "#33C1FF", FontColor = "#FFFFFF" },
            new Tag { ID = 6, Name = "On Hold", BackgroundColor = "#8E44AD", FontColor = "#FFFFFF" },
            new Tag { ID = 7, Name = "Review", BackgroundColor = "#FF33A6", FontColor = "#FFFFFF" },
            new Tag { ID = 8, Name = "New", BackgroundColor = "#2E4053", FontColor = "#FFFFFF" },
            new Tag { ID = 9, Name = "Scheduled", BackgroundColor = "#7DCEA0", FontColor = "#000000" },
            new Tag { ID = 10, Name = "Urgent", BackgroundColor = "#F39C12", FontColor = "#000000" }
        );

        modelBuilder.Entity<Item>().HasData(
            new Item { ID = 1, Name = "Get ready", Description = "Get ready to your project", ProjectID = 1, ColumnID = 1 },
            new Item { ID = 2, Name = "Plan it", Description = "You are planning your project", ProjectID = 1, ColumnID = 2 },
            new Item { ID = 3, Name = "Pet capybara", Description = "You petted capybara", ProjectID = 1, ColumnID = 3, DoneDate = DateOnly.FromDateTime(DateTime.Now) }
        );

        modelBuilder.Entity<ItemTag>().HasData(
            new ItemTag { ID = 1, ItemID = 1, TagID = 1 },
            new ItemTag { ID = 2, ItemID = 2, TagID = 5 },
            new ItemTag { ID = 3, ItemID = 3, TagID = 4 }
        );

    }
}

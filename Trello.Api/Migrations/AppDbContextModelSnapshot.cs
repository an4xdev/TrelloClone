﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Trello.Api.Database;

#nullable disable

namespace Trello.Api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Trello.Api.Models.User", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ProfilePicture")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Trello.Shared.Column", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TemplateID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("TemplateID");

                    b.ToTable("Columns");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "TODO",
                            TemplateID = 1
                        },
                        new
                        {
                            ID = 2,
                            Name = "In progress",
                            TemplateID = 1
                        },
                        new
                        {
                            ID = 3,
                            Name = "Done",
                            TemplateID = 1
                        });
                });

            modelBuilder.Entity("Trello.Shared.Item", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("ColumnID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProjectID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ColumnID");

                    b.HasIndex("ProjectID");

                    b.ToTable("Items");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            ColumnID = 1,
                            Description = "Get ready to your project",
                            Name = "Get ready",
                            ProjectID = 1
                        },
                        new
                        {
                            ID = 2,
                            ColumnID = 2,
                            Description = "You are planning your project",
                            Name = "Plan it",
                            ProjectID = 1
                        },
                        new
                        {
                            ID = 3,
                            ColumnID = 3,
                            Description = "You petted capybara",
                            Name = "Pet capybara",
                            ProjectID = 1
                        });
                });

            modelBuilder.Entity("Trello.Shared.Project", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TemplateID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("TemplateID");

                    b.ToTable("Projects");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "Default Project",
                            TemplateID = 1
                        });
                });

            modelBuilder.Entity("Trello.Shared.Template", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Templates");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "Default"
                        });
                });

            modelBuilder.Entity("Trello.Shared.Column", b =>
                {
                    b.HasOne("Trello.Shared.Template", "Template")
                        .WithMany("Columns")
                        .HasForeignKey("TemplateID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Template");
                });

            modelBuilder.Entity("Trello.Shared.Item", b =>
                {
                    b.HasOne("Trello.Shared.Column", "Column")
                        .WithMany("Items")
                        .HasForeignKey("ColumnID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Trello.Shared.Project", "Project")
                        .WithMany("Items")
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Column");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Trello.Shared.Project", b =>
                {
                    b.HasOne("Trello.Shared.Template", "Template")
                        .WithMany()
                        .HasForeignKey("TemplateID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Template");
                });

            modelBuilder.Entity("Trello.Shared.Column", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("Trello.Shared.Project", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("Trello.Shared.Template", b =>
                {
                    b.Navigation("Columns");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Trello.Api.Database;

#nullable disable

namespace Trello.Api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240731173316_ColumnMarkAsDoneItemDoneDate")]
    partial class ColumnMarkAsDoneItemDoneDate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Trello.Api.Models.Column", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<bool>("MarkAsDone")
                        .HasColumnType("bit");

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
                            MarkAsDone = false,
                            Name = "TODO",
                            TemplateID = 1
                        },
                        new
                        {
                            ID = 2,
                            MarkAsDone = false,
                            Name = "In progress",
                            TemplateID = 1
                        },
                        new
                        {
                            ID = 3,
                            MarkAsDone = true,
                            Name = "Done",
                            TemplateID = 1
                        });
                });

            modelBuilder.Entity("Trello.Api.Models.Item", b =>
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

                    b.Property<DateOnly?>("DoneDate")
                        .HasColumnType("date");

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
                            DoneDate = new DateOnly(2024, 7, 31),
                            Name = "Pet capybara",
                            ProjectID = 1
                        });
                });

            modelBuilder.Entity("Trello.Api.Models.Project", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

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
                            Description = "Default description of default project.",
                            Name = "Default Project",
                            TemplateID = 1
                        });
                });

            modelBuilder.Entity("Trello.Api.Models.Template", b =>
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

            modelBuilder.Entity("Trello.Api.Models.Column", b =>
                {
                    b.HasOne("Trello.Api.Models.Template", "Template")
                        .WithMany("Columns")
                        .HasForeignKey("TemplateID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Template");
                });

            modelBuilder.Entity("Trello.Api.Models.Item", b =>
                {
                    b.HasOne("Trello.Api.Models.Column", "Column")
                        .WithMany("Items")
                        .HasForeignKey("ColumnID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Trello.Api.Models.Project", "Project")
                        .WithMany("Items")
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Column");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Trello.Api.Models.Project", b =>
                {
                    b.HasOne("Trello.Api.Models.Template", "Template")
                        .WithMany()
                        .HasForeignKey("TemplateID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Template");
                });

            modelBuilder.Entity("Trello.Api.Models.Column", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("Trello.Api.Models.Project", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("Trello.Api.Models.Template", b =>
                {
                    b.Navigation("Columns");
                });
#pragma warning restore 612, 618
        }
    }
}
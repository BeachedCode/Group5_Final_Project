﻿// <auto-generated />
using System;
using Group5_Final_Project.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Group5_Final_Project.Migrations
{
    [DbContext(typeof(GamesContext))]
    partial class GamesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Group5_Final_Project.Models.Developer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Developers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Location = "Japan",
                            Name = "Nintendo"
                        },
                        new
                        {
                            Id = 2,
                            Location = "Japan",
                            Name = "Sony"
                        },
                        new
                        {
                            Id = 3,
                            Location = "America",
                            Name = "Microsoft"
                        },
                        new
                        {
                            Id = 4,
                            Location = "America",
                            Name = "Naughty Dog"
                        });
                });

            modelBuilder.Entity("Group5_Final_Project.Models.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("DeveloperId")
                        .HasColumnType("int");

                    b.Property<int?>("GenreId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Rating")
                        .HasColumnType("int");

                    b.Property<DateOnly?>("ReleaseDate")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("DeveloperId");

                    b.HasIndex("GenreId");

                    b.ToTable("Games");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DeveloperId = 1,
                            GenreId = 2,
                            Name = "The Legend of Zelda: Breath of the Wild",
                            Rating = 10,
                            ReleaseDate = new DateOnly(2017, 3, 3)
                        },
                        new
                        {
                            Id = 2,
                            DeveloperId = 4,
                            GenreId = 4,
                            Name = "The Last of Us Part II",
                            Rating = 9,
                            ReleaseDate = new DateOnly(2020, 6, 19)
                        },
                        new
                        {
                            Id = 3,
                            DeveloperId = 3,
                            GenreId = 4,
                            Name = "Halo Infinite",
                            Rating = 8,
                            ReleaseDate = new DateOnly(2021, 12, 8)
                        });
                });

            modelBuilder.Entity("Group5_Final_Project.Models.GameGenre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Genre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Genre = "RPG"
                        },
                        new
                        {
                            Id = 2,
                            Genre = "Adventure"
                        },
                        new
                        {
                            Id = 3,
                            Genre = "Strategy"
                        },
                        new
                        {
                            Id = 4,
                            Genre = "Action"
                        });
                });

            modelBuilder.Entity("Group5_Final_Project.Models.Platform", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Platforms");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Nintendo Switch"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Playstation 5"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Xbox Series X"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Playstation 4"
                        });
                });

            modelBuilder.Entity("Group5_Final_Project.Models.Game", b =>
                {
                    b.HasOne("Group5_Final_Project.Models.Developer", "Developer")
                        .WithMany()
                        .HasForeignKey("DeveloperId");

                    b.HasOne("Group5_Final_Project.Models.GameGenre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId");

                    b.Navigation("Developer");

                    b.Navigation("Genre");
                });
#pragma warning restore 612, 618
        }
    }
}

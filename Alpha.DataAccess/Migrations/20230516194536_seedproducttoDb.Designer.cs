﻿// <auto-generated />
using Alpha.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Alpha.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230516194536_seedproducttoDb")]
    partial class seedproducttoDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Alpha.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DisplayOrder = 1,
                            Name = "Low Lights"
                        },
                        new
                        {
                            Id = 2,
                            DisplayOrder = 2,
                            Name = "Average Light"
                        },
                        new
                        {
                            Id = 3,
                            DisplayOrder = 3,
                            Name = "Strong Light"
                        });
                });

            modelBuilder.Entity("Alpha.Models.Models.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("brands");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DisplayOrder = 1,
                            Name = "Ray-Ban"
                        },
                        new
                        {
                            Id = 2,
                            DisplayOrder = 2,
                            Name = "Warby Parker"
                        },
                        new
                        {
                            Id = 3,
                            DisplayOrder = 3,
                            Name = "Gucci"
                        });
                });

            modelBuilder.Entity("Alpha.Models.Models.Lenstype", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("lenstypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DisplayOrder = 1,
                            Name = "Low Lights"
                        },
                        new
                        {
                            Id = 2,
                            DisplayOrder = 2,
                            Name = "Average Light"
                        },
                        new
                        {
                            Id = 3,
                            DisplayOrder = 3,
                            Name = "Strong Light"
                        });
                });

            modelBuilder.Entity("Alpha.Models.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ListPrice")
                        .HasColumnType("float");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<double>("Price10")
                        .HasColumnType("float");

                    b.Property<double>("Price5")
                        .HasColumnType("float");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Color = "Black",
                            Description = "\r\nFashion TR90 Square Computer Glasses Anti-blue Ray Eyewear Frame-5025-ShiningBlac ",
                            ISBN = "SWD9999001",
                            ListPrice = 2250.0,
                            Price = 1970.0,
                            Price10 = 1420.0,
                            Price5 = 1630.0,
                            Title = "Dalston"
                        },
                        new
                        {
                            Id = 2,
                            Color = "Black Noir",
                            Description = "\r\nFashion TR90 Square Computer Glasses Anti-blue Ray Eyewear Frame-5025-ShiningBlac ",
                            ISBN = "CAW777777701",
                            ListPrice = 1920.0,
                            Price = 1830.0,
                            Price10 = 1350.0,
                            Price5 = 1660.0,
                            Title = "Dalston Sun"
                        },
                        new
                        {
                            Id = 3,
                            Color = "Dark Green",
                            Description = "\r\nFashion TR90 Square Computer Glasses Anti-blue Ray Eyewear Frame-5025-ShiningBlac ",
                            ISBN = "RITO5555501",
                            ListPrice = 750.0,
                            Price = 690.0,
                            Price10 = 440.0,
                            Price5 = 510.0,
                            Title = "Le Marais Sun"
                        },
                        new
                        {
                            Id = 4,
                            Color = "Navy Blue",
                            Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                            ISBN = "WS3333333301",
                            ListPrice = 970.0,
                            Price = 830.0,
                            Price10 = 580.0,
                            Price5 = 700.0,
                            Title = "Osterbro"
                        },
                        new
                        {
                            Id = 5,
                            Color = "Silver Matte",
                            Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                            ISBN = "SOTJ1111111101",
                            ListPrice = 300.0,
                            Price = 270.0,
                            Price10 = 120.0,
                            Price5 = 175.0,
                            Title = "Ginza Sun"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}

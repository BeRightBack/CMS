﻿// <auto-generated />
using Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Api.Migrations
{
    [DbContext(typeof(CMSDbContext))]
    [Migration("20210725163614_Api-SeedData")]
    partial class ApiSeedData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Api.Data.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Canada",
                            ShortName = "CA"
                        },
                        new
                        {
                            Id = 2,
                            Name = "United State",
                            ShortName = "US"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Mexico",
                            ShortName = "MX"
                        });
                });

            modelBuilder.Entity("Api.Data.Hotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Rating")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Hotels");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Mtl",
                            CountryId = 1,
                            Name = "Down Town Resort and Spa",
                            Rating = 4.5
                        },
                        new
                        {
                            Id = 2,
                            Address = "George Town",
                            CountryId = 2,
                            Name = "Comfort Suites",
                            Rating = 4.2999999999999998
                        },
                        new
                        {
                            Id = 3,
                            Address = "Mexico City",
                            CountryId = 2,
                            Name = "Grand Palldium",
                            Rating = 4.0
                        });
                });

            modelBuilder.Entity("Api.Data.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FullDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("ShortDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StoreId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StoreId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FullDescription = "Full description",
                            Name = "Down Town Resort and Spa",
                            Price = 100.0,
                            ShortDescription = "short description",
                            StoreId = 1
                        },
                        new
                        {
                            Id = 2,
                            FullDescription = "Full description",
                            Name = "Comfort Suites",
                            Price = 10.0,
                            ShortDescription = "short description",
                            StoreId = 2
                        },
                        new
                        {
                            Id = 3,
                            FullDescription = "Full description",
                            Name = "Grand Palldium",
                            Price = 1.0,
                            ShortDescription = "short description",
                            StoreId = 3
                        });
                });

            modelBuilder.Entity("Api.Data.Store", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Stores");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Indiana",
                            Url = "http:frenzyzone.com.Indiana"
                        },
                        new
                        {
                            Id = 2,
                            Name = "AppleBee",
                            Url = "http:frenzyzone.com.AppleBee"
                        },
                        new
                        {
                            Id = 3,
                            Name = "TechnoHub",
                            Url = "http:frenzyzone.com.TechnoHub"
                        });
                });

            modelBuilder.Entity("Api.Data.Hotel", b =>
                {
                    b.HasOne("Api.Data.Country", "Country")
                        .WithMany("Hotels")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Api.Data.Product", b =>
                {
                    b.HasOne("Api.Data.Store", "Store")
                        .WithMany("Products")
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Store");
                });

            modelBuilder.Entity("Api.Data.Country", b =>
                {
                    b.Navigation("Hotels");
                });

            modelBuilder.Entity("Api.Data.Store", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}

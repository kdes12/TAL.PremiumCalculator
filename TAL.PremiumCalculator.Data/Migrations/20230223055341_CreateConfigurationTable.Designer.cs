﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TAL.PremiumCalculator.Data;

#nullable disable

namespace TAL.PremiumCalculator.Data.Migrations
{
    [DbContext(typeof(PremiumCalculatorContext))]
    [Migration("20230223055341_CreateConfigurationTable")]
    partial class CreateConfigurationTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TAL.PremiumCalculator.Data.Models.Configuration", b =>
                {
                    b.Property<int>("MaximumAge")
                        .HasColumnType("int");

                    b.ToTable("Configurations");
                });

            modelBuilder.Entity("TAL.PremiumCalculator.Data.Models.Occupation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<Guid>("OccupationRatingId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("OccupationRatingId");

                    b.ToTable("Occupations");

                    b.HasData(
                        new
                        {
                            Id = new Guid("fc9a7ff0-38f2-4a0b-9bd0-a4d927eb211e"),
                            Name = "Cleaner",
                            OccupationRatingId = new Guid("2e10167b-e895-4b3e-b557-bb9d164d8056")
                        },
                        new
                        {
                            Id = new Guid("5a5e144c-96fb-4a22-adad-1517a61b7bd0"),
                            Name = "Doctor",
                            OccupationRatingId = new Guid("17de5b02-2888-401a-ae29-d58ddf9038e4")
                        },
                        new
                        {
                            Id = new Guid("51546ab8-19e5-4334-966f-e4d67efb3806"),
                            Name = "Author",
                            OccupationRatingId = new Guid("35cf2054-e109-41d1-baca-62bb83a1885d")
                        },
                        new
                        {
                            Id = new Guid("1b766802-8d51-4c77-b98b-1c48217437c6"),
                            Name = "Farmer",
                            OccupationRatingId = new Guid("ef7f0408-0bc4-4451-81d1-6f3b322d4c0d")
                        },
                        new
                        {
                            Id = new Guid("c7dbca9d-e209-4b48-8ced-0e27969e84a9"),
                            Name = "Mechanic",
                            OccupationRatingId = new Guid("ef7f0408-0bc4-4451-81d1-6f3b322d4c0d")
                        },
                        new
                        {
                            Id = new Guid("c11e48a1-b920-4aa3-94c4-0b8ca279f16a"),
                            Name = "Florist",
                            OccupationRatingId = new Guid("2e10167b-e895-4b3e-b557-bb9d164d8056")
                        });
                });

            modelBuilder.Entity("TAL.PremiumCalculator.Data.Models.OccupationRating", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Factor")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("OccupationRatings");

                    b.HasData(
                        new
                        {
                            Id = new Guid("17de5b02-2888-401a-ae29-d58ddf9038e4"),
                            Factor = 1.0,
                            Name = "Professional"
                        },
                        new
                        {
                            Id = new Guid("35cf2054-e109-41d1-baca-62bb83a1885d"),
                            Factor = 1.25,
                            Name = "White Collar"
                        },
                        new
                        {
                            Id = new Guid("2e10167b-e895-4b3e-b557-bb9d164d8056"),
                            Factor = 1.5,
                            Name = "Light Manual"
                        },
                        new
                        {
                            Id = new Guid("ef7f0408-0bc4-4451-81d1-6f3b322d4c0d"),
                            Factor = 1.75,
                            Name = "Heavy Manual"
                        });
                });

            modelBuilder.Entity("TAL.PremiumCalculator.Data.Models.Occupation", b =>
                {
                    b.HasOne("TAL.PremiumCalculator.Data.Models.OccupationRating", "OccupationRating")
                        .WithMany()
                        .HasForeignKey("OccupationRatingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OccupationRating");
                });
#pragma warning restore 612, 618
        }
    }
}

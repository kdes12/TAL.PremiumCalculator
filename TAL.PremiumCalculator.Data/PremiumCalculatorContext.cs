﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAL.PremiumCalculator.Data.Abstractions;
using TAL.PremiumCalculator.Data.Models;

namespace TAL.PremiumCalculator.Data
{
    public class PremiumCalculatorContext : DbContext
    {
        public DbSet<Occupation> Occupations { get; set;}
        public DbSet<OccupationRating> OccupationRatings { get; set;}

        public PremiumCalculatorContext(DbContextOptions<PremiumCalculatorContext> dbContextOptions)
            : base (dbContextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // seed 
            Seed(modelBuilder);
        }

        private static void Seed(ModelBuilder modelBuilder)
        {
            List<OccupationRating> occupationRatings = new()
            {
                new OccupationRating { Id = Guid.NewGuid(), Name = "Professional", Factor = 1.00 },
                new OccupationRating { Id = Guid.NewGuid(), Name = "White Collar", Factor = 1.25 },
                new OccupationRating { Id = Guid.NewGuid(), Name = "Light Manual", Factor = 1.50 },
                new OccupationRating { Id = Guid.NewGuid(), Name = "Heavy Manual", Factor = 1.75 },
            };

            List<Occupation> occupations = new()
            {
                new Occupation { Id = Guid.NewGuid(), Name = "Cleaner", OccupationRatingId = occupationRatings.First(or => or.Name == "Light Manual").Id },
                new Occupation { Id = Guid.NewGuid(), Name = "Doctor", OccupationRatingId = occupationRatings.First(or => or.Name == "Professional").Id },
                new Occupation { Id = Guid.NewGuid(), Name = "Author", OccupationRatingId = occupationRatings.First(or => or.Name == "White Collar").Id },
                new Occupation { Id = Guid.NewGuid(), Name = "Farmer", OccupationRatingId = occupationRatings.First(or => or.Name == "Heavy Manual").Id },
                new Occupation { Id = Guid.NewGuid(), Name = "Mechanic", OccupationRatingId = occupationRatings.First(or => or.Name == "Heavy Manual").Id },
                new Occupation { Id = Guid.NewGuid(), Name = "Florist", OccupationRatingId = occupationRatings.First(or => or.Name == "Light Manual").Id },
            };

            modelBuilder.Entity<OccupationRating>().HasData(occupationRatings);
            modelBuilder.Entity<Occupation>().HasData(occupations);
        }
    }
}

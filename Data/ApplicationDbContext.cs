using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ELearn.Models;
using Microsoft.AspNetCore.Identity;

namespace ELearn.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //Users
        public DbSet<Lecturer> Lecturers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<SubjectCoordinator> SubjectCoordinators { get; set; }
        public DbSet<HeadOfDepartment> HeadOfDepartments { get; set; }
        public DbSet<Sponsor> Sponsors { get; set; }

        //Locations
        public DbSet<Office> Offices { get; set; }
        public DbSet<Accomodation> Accomodations { get; set; }

        public DbSet<Material> Materials { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Module_Course> Modules_Courses { get; set; }
        public DbSet<Student_Module> Students_Modules { get; set; }
        public DbSet<Student_Course> Students_Courses { get; set; }
        public DbSet<Lecturer_Module> Lecturers_Modules { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Submission_Student> Submissions_Students { get; set; }
        public DbSet<Submission> Submissions { get; set; }

        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Modified Identity tables

            base.OnModelCreating(builder);
            builder.HasDefaultSchema("Identity");
            builder.Entity<IdentityUser>(entity =>
            {
                entity.ToTable(name: "User");
            });
            builder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable(name: "Role");
            });
            builder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable("UserRoles");
            });
            builder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable("UserClaims");
            });
            builder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable("UserLogins");
            });
            builder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable("RoleClaims");
            });
            builder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable("UserTokens");
            });

            // Seeding database

            builder.Entity<Accomodation>().HasData(
            new Accomodation
            {
                AccomID = 1,
                BuildingName = "Building A",
                Address = "14 Dale Av"
            },
            new Accomodation
            {
                AccomID = 2,
                BuildingName = "Building D",
                Address = "14 Dale Av"
            });

            builder.Entity<Office>().HasData(
            new Office
            {
                OfficeID = 1,
                BuildingName = "Block J, E140",
                Location = "West Campus"
            },
            new Office
            {
                OfficeID = 2,
                BuildingName = "Block F, R20",
                Location = "East Campus"
            });

            builder.Entity<Course>().HasData(
            new Course
            {
                CourseID = 1,
                Name = "Dip : Metaphysics",
                Description = "Applied physics of the meta-scape.",
                CreditRequired = 300,
                Active = true
            },
            new Course
            {
                CourseID = 2,
                Name = "Dip : Astro-Engineering",
                Description = "Study of extra-planar construction.",
                CreditRequired = 1200,
                Active = true
            });

            builder.Entity<Material>().HasData(
            new Material
            {
                MatID = 1,
                ModID = 1,
                Week = 1,
                FileLink = "https://en.wikipedia.org/wiki/Metaphysics",
                Description = "Basic rundown of metaphysics.",
                Active = true
            },
            new Material
            {
                MatID = 2,
                ModID = 1,
                Week = 2,
                FileLink = "https://en.wikipedia.org/wiki/Metaphysics_(Aristotle)",
                Description = "Aristotle's take on metaphysics.",
                Active = true
            },
            new Material
            {
                MatID = 3,
                ModID = 2,
                Week = 1,
                FileLink = "https://en.wikipedia.org/wiki/Aerospace_engineering",
                Description = "Brief overview and notes.",
                Active = true
            },
            new Material
            {
                MatID = 4,
                ModID = 2,
                Week = 2,
                FileLink = "https://www.halopedia.org/Astroengineering",
                Description = "Extra-planar construction in science fiction.",
                Active = true
            });

            builder.Entity<Module>().HasData(
            new Module
            {
                ModID = 1,
                Name = "Physical Meta II",
                CreditAward = 30,
                Year = 1,
                Fee = 12000.00,
                PeriodMonths = 12,
                Active = true
            },
            new Module
            {
                ModID = 2,
                Name = "Neutrinos Phassification",
                CreditAward = 25,
                Year = 1,
                Fee = 14000.00,
                PeriodMonths = 6,
                Active = true
            });

            builder.Entity<Module_Course>().HasData(
            new Module_Course
            {
                ID = 1,
                ModID = 1,
                CourseID = 1,
                Active = true
            },
            new Module_Course
            {
                ID = 2,
                ModID = 2,
                CourseID = 2,
                Active = true
            });

            builder.Entity<Submission>().HasData(
            new Submission
            {
                SubID = 1,
                ModID = 2,
                Week = 3,
                FileLink = "",
                Description = "ASSIGNMENT 1. Ring-shaped Parasite Trap",
                StartDate = DateTime.ParseExact("2022-10-10", "yyyy-MM-dd", null),
                DueDate = DateTime.ParseExact("2022-11-15", "yyyy-MM-dd", null),
                TotalScore = 80,
                Active = true
            },
            new Submission
            {
                SubID = 2,
                ModID = 1,
                Week = 2,
                FileLink = "",
                Description = "ASSIGNMENT 4",
                StartDate = DateTime.ParseExact("2022-10-10", "yyyy-MM-dd", null),
                DueDate = DateTime.ParseExact("2022-11-15", "yyyy-MM-dd", null),
                TotalScore = 80,
                Active = true
            });



        }


    }
    

}

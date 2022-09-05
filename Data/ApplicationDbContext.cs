using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ELearn.Models;

namespace ELearn.Data
{
    public class ApplicationDbContext : IdentityDbContext
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
        //

        //Locations
        public DbSet<Office> Offices { get; set; }
        public DbSet<Accomodation> Accomodations { get; set; }
        //

        public DbSet<Material> Materials { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Module_Course> Modules_Courses { get; set; }
        public DbSet<Student_Module> Students_Modules { get; set; }
        public DbSet<Lecturer_Module> Lecturers_Modules { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Submission_Student> Submissions_Students { get; set; }
        public DbSet<Submission> Submissions { get; set; }

    }
}

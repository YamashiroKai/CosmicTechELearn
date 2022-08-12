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
        public DbSet<Material> Materials { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}

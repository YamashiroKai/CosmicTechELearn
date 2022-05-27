using ELearn.Models;
using Microsoft.EntityFrameworkCore;

namespace ELearn.Data
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        //public DbSet<Item> Items { get; set; }// Saves the data from our database and entity inside<> and table name 
        //public DbSet<Expense> Expenses { get; set; }
    }
}

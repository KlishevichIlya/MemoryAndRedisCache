using CacheEducation.Data.Configurations;
using CacheEducation.Models;
using Microsoft.EntityFrameworkCore;

namespace CacheEducation.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Author> Author { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<Book> Book { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AuthorConfiguration());
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new CountryConfiguration());
            modelBuilder.ApplyConfiguration(new BookAuthorConfiguration());
        }
    }
}

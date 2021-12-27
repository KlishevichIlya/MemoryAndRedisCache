using CacheEducation.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CacheEducation.Data.Configurations
{
    /// <summary>
    ///  Class for configure Book entity using Fluent API.
    /// </summary>
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Title).IsRequired().HasMaxLength(150);
            builder.Property(x => x.YearOfRelease).IsRequired();
        }
    }
}

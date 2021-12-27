using CacheEducation.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CacheEducation.Data.Configurations
{
    /// <summary>
    /// Class for configure Author entity using Fluent API.
    /// </summary>
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.YearOfBirth).IsRequired();

            builder.HasOne(x => x.Country)
                .WithMany(x => x.Authors)
                .HasForeignKey(x => x.CountryId)
                .OnDelete(DeleteBehavior.Cascade);     
            
        }
    }
}

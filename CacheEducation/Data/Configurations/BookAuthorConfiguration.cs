using CacheEducation.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CacheEducation.Data.Configurations
{
    /// <summary>
    /// Class for configure BookAuthor entity using Fluent API.
    /// </summary>
    public class BookAuthorConfiguration : IEntityTypeConfiguration<BookAuthor>
    {
        public void Configure(EntityTypeBuilder<BookAuthor> builder)
        {
            builder.HasKey(x => new {x.BookId, x.AuthorId});

            builder.HasOne(x => x.Author)
               .WithMany(x => x.BookAuthor)
               .HasForeignKey(x => x.AuthorId)
               .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Book)
                .WithMany(x => x.BookAuthor)
                .HasForeignKey(x => x.BookId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

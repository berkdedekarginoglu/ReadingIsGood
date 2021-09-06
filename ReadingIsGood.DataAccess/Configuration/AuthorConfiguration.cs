using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReadingIsGood.Core.Entities.Concrete;

namespace ReadingIsGood.DataAccess.Configuration
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.FirstName).HasMaxLength(128)
                .HasColumnType("nvarchar")
                .IsRequired();

            builder.Property(x => x.LastName).HasMaxLength(128)
               .HasColumnType("nvarchar")
               .IsRequired();

            builder.HasMany(x => x.Books)
                .WithOne(y => y.Author)
                .HasForeignKey(y => y.AuthorId);
         
        }
    }
}

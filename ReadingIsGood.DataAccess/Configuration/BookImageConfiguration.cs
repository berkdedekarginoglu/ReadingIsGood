using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReadingIsGood.Core.Entities.Concrete;

namespace ReadingIsGood.DataAccess.Configuration
{
    public class BookImageConfiguration : IEntityTypeConfiguration<BookImage>
    {
        public void Configure(EntityTypeBuilder<BookImage> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Book)
                .WithMany(x => x.BookImages)
                .HasForeignKey(x => x.BookId)
                .IsRequired();

            builder.Property(x => x.ImagePath)
                .HasMaxLength(256)
                .HasColumnType("nvarchar")
                .IsRequired();

            builder.Property(x => x.IsActive)
                .HasColumnType("bit")
                .IsRequired();

            builder.Property(x => x.CreatedAt)
                .HasColumnType("datetime2")
                .IsRequired();

            builder.Property(x => x.ModifiedAt)
                .HasColumnType("datetime2")
                .IsRequired();

        }
    }
}

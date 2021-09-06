using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReadingIsGood.Core.Entities.Concrete;
namespace ReadingIsGood.DataAccess.Configuration
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.BookCategories)
                .WithOne(y => y.Book)
                .HasForeignKey(y => y.BookId);
                
            builder.Property(x => x.AuthorId)
                .IsRequired();

            builder.HasOne(x => x.Author)
                .WithMany(y => y.Books)
                .HasForeignKey(x => x.AuthorId)
                .IsRequired();

            builder.Property(x => x.Name)
                .HasMaxLength(128)
                .HasColumnType("nvarchar")
                .IsRequired();

            builder.Property(x => x.ISBN)
                .HasMaxLength(128)
                .HasColumnType("nvarchar")
                .IsRequired();

            builder.Property(x => x.Description)
                .HasMaxLength(500)
                .HasColumnType("nvarchar")
                .IsRequired();

            builder.Property(x => x.Pages)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(x => x.ReorderLevel)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(x => x.UnitsInStock)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(x => x.IsActive)
                .HasColumnType("bit")
                .IsRequired();

            builder.Property(x => x.UnitPrice)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(x => x.YearOfPublication)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(x => x.CreatedAt)
                .HasColumnType("datetime2")
                .IsRequired();

            builder.Property(x => x.UpdatedAt)
                .HasColumnType("datetime2")
                .IsRequired();
        }
    }
}

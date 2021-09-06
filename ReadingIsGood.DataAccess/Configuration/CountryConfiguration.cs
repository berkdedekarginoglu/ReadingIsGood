using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReadingIsGood.Core.Entities.Concrete;

namespace ReadingIsGood.DataAccess.Configuration
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasColumnType("nvarchar")
                .HasMaxLength(128)
                .IsRequired();

            builder.Property(x => x.PhoneCode)
                .HasColumnType("nvarchar")
                .HasMaxLength(128)
                .IsRequired();

            builder.Property(x => x.TripleCode)
                .HasColumnType("nvarchar")
                .HasMaxLength(128)
                .IsRequired();

            builder.Property(x => x.BinaryCode)
                .HasColumnType("nvarchar")
                .HasMaxLength(128)
                .IsRequired();
        }
    }
}

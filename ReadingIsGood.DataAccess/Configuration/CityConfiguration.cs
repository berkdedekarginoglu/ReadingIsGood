using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReadingIsGood.Core.Entities.Concrete;

namespace ReadingIsGood.DataAccess.Configuration
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Country)
                .WithMany(x => x.Cities)
                .HasForeignKey(x => x.CountryId);

            builder.Property(x => x.CityName)
                .HasColumnType("nvarchar")
                .HasMaxLength(128)
                .IsRequired();

            builder.Property(x => x.PhoneCode)
                .HasColumnType("nvarchar")
                .HasMaxLength(128)
                .IsRequired(); ;

            builder.Property(x => x.PlateNo)
                .HasColumnType("nvarchar")
                .HasMaxLength(128)
                .IsRequired();
        }
    }
}

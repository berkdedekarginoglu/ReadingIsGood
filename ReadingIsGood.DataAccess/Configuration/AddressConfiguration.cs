using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReadingIsGood.Core.Entities;
using ReadingIsGood.Core.Entities.Concrete;

namespace ReadingIsGood.DataAccess.Configuration
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.UserAddress)
                .WithOne(y => y.Address)
                .HasForeignKey(y => y.AddressId);

            builder.HasOne(x => x.City)
                .WithMany(x => x.Adresses)
                .HasForeignKey(x => x.CityId);

            builder.Property(x => x.Details)
                .HasColumnType("nvarchar")
                .HasMaxLength(500)
                .IsRequired();
        }
    }
}

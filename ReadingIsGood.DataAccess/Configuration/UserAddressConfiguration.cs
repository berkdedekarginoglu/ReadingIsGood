using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReadingIsGood.Core.Entities.Concrete;

namespace ReadingIsGood.DataAccess.Configuration
{
    public class UserAddressConfiguration : IEntityTypeConfiguration<UserAddress>
    {
        public void Configure(EntityTypeBuilder<UserAddress> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.User)
                .WithMany(y => y.UserAddresses)
                .HasForeignKey(x => x.UserId);


            builder.HasOne(x => x.Address)
                .WithMany(y => y.UserAddress)
                .HasForeignKey(x => x.UserId);

        }
    }
}

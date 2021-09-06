using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReadingIsGood.Core.Entities.Concrete;

namespace ReadingIsGood.DataAccess.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Address)
                .WithMany(y => y.Orders)
                .HasForeignKey(x => x.AddressId);

            builder.HasOne(x => x.User)
                .WithMany(y => y.Orders)
                .HasForeignKey(x => x.UserId);



            builder.Property(x => x.OrderDate)
                .HasColumnType("datetime2")
                .IsRequired();

            builder.Property(x => x.RequiredDate)
                .HasColumnType("datetime2")
                .IsRequired();

            builder.Property(x => x.ShippedDate)
                .HasColumnType("datetime2")
                .IsRequired(false); 
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReadingIsGood.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingIsGood.DataAccess.Configuration
{
    class OrderStatusConfiguration : IEntityTypeConfiguration<OrderStatus>
    {
        public void Configure(EntityTypeBuilder<OrderStatus> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.Orders)
               .WithOne(x => x.OrderStatus)
               .HasForeignKey(x => x.OrderStatusId)
               .IsRequired();

            builder.Property(x => x.Status)
                .HasColumnType("nvarcar")
                .HasMaxLength(128)
                .IsRequired();
        }
    }
}

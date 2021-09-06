using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReadingIsGood.Core.Entities.Concrete;

namespace ReadingIsGood.DataAccess.Configuration
{
    public class UserOperationClaimConfiguration : IEntityTypeConfiguration<UserOperationClaim>
    {
        public void Configure(EntityTypeBuilder<UserOperationClaim> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.OperationClaim)
                .WithMany(x => x.UserOperationClaims)
                .HasForeignKey(x => x.OperationClaimId)
                .IsRequired();

            builder.HasOne(x => x.User)
                .WithMany(x => x.UserOperationClaims)
                .HasForeignKey(x => x.UserId)
                .IsRequired();

           
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReadingIsGood.Core.Entities;
using ReadingIsGood.Core.Entities.Concrete;
using System;

namespace ReadingIsGood.DataAccess.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasMaxLength(500)
                .HasColumnType("nvarchar")
                .IsRequired();

            builder.Property(x => x.Email).HasMaxLength(100)
                .HasColumnType("nvarchar")
                .IsRequired();

            builder.Property(x => x.PasswordHash).HasMaxLength(500)
                .HasColumnType("nvarchar")
                .IsRequired();

            builder.Property(x => x.PasswordSalt).HasMaxLength(500)
                .HasColumnType("nvarchar")
                .IsRequired();

            builder.Property(x => x.FirstName).HasMaxLength(128)
                .HasColumnType("nvarchar")
                .IsRequired();

            builder.Property(x => x.LastName).HasMaxLength(128)
                .HasColumnType("nvarchar")
                .IsRequired();

            builder.Property(x => x.DateOfBirth)
                .HasColumnType("datetime2")
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

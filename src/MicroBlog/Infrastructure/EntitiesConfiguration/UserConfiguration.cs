using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntitiesConfiguration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(user => user.Id);

        builder.Property(user => user.UserName)
            .IsRequired();

        builder.Property(user => user.Email)
            .IsRequired();

        builder.Property(user => user.PasswordHash)
            .IsRequired();

        builder.Property(user => user.Description)
            .HasMaxLength(256);

        builder.Ignore(user => user.AccessFailedCount);
        builder.Ignore(user => user.LockoutEnabled);
        builder.Ignore(user => user.LockoutEnd);
        builder.Ignore(user => user.TwoFactorEnabled);
        builder.Ignore(user => user.NormalizedEmail);
        builder.Ignore(user => user.NormalizedUserName);
        builder.Ignore(user => user.PhoneNumber);
        builder.Ignore(user => user.PhoneNumberConfirmed);
        builder.Ignore(user => user.EmailConfirmed);
    }
}

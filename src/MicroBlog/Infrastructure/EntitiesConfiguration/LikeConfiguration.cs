using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntitiesConfiguration;

public class LikeConfiguration : IEntityTypeConfiguration<Like>
{
    public void Configure(EntityTypeBuilder<Like> builder)
    {
        builder.HasKey(like => like.Id);

        builder.Property(like => like.UserId)
            .IsRequired();

        builder.Property(like => like.PostId)
            .IsRequired();

        builder.HasOne(like => like.User)
            .WithMany(user => user.Likes)
            .HasForeignKey(key => key.UserId)
            .IsRequired();

        builder.HasOne(like => like.Post)
            .WithMany(post => post.Likes)
            .HasForeignKey(key => key.PostId)
            .IsRequired();
    }
}

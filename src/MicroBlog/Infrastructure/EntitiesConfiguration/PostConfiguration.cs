using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntitiesConfiguration;

public class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.HasKey(post => post.Id);

        builder.Property(post => post.UserId)
            .IsRequired();

        builder.Property(post => post.CreatedAt)
            .IsRequired();

        builder.Property(post => post.TotalLikes)
            .IsRequired();

        builder.Property(post => post.Content)
            .HasMaxLength(500);

        builder.HasOne(post => post.User)
            .WithMany(user => user.Posts)
            .HasForeignKey(key => key.UserId)
            .IsRequired();
    }
}

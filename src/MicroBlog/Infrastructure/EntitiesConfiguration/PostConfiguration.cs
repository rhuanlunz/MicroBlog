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

        builder.Property(post => post.Likes)
            .IsRequired();

        builder.Property(post => post.Content)
            .HasMaxLength(500);
    }
}

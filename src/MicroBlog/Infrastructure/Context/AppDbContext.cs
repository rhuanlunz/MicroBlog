using Infrastructure.Entities;
using Infrastructure.EntitiesConfiguration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

public class AppDbContext : IdentityDbContext<User, IdentityRole<int>, int>
{
    public DbSet<Post> Posts { get; set; }
    public DbSet<Like> Likes { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfiguration(new PostConfiguration());
        builder.ApplyConfiguration(new UserConfiguration());
        builder.ApplyConfiguration(new LikeConfiguration());
    }
}

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MicroBlog.Models;

namespace MicroBlog.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityDbContext<User>(options)
{
    public DbSet<Post> Posts { get;set; }
    public DbSet<Like> Likes { get;set; }
}
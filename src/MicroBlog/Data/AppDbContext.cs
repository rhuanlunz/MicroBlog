using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MicroBlog.Models;

namespace MicroBlog.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityDbContext<User>(options)
{
}
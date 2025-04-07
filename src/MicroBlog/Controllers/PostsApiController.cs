using System.Web;
using MicroBlog.Data;
using MicroBlog.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MicroBlog.Controllers;

[Route("api/posts")]
[ApiController]
public class PostsApiController(
    UserManager<User> userManager,
    AppDbContext context
) : Controller
{

    private readonly UserManager<User> _userManager = userManager;
    private readonly AppDbContext _context = context;

    [AllowAnonymous]
    [HttpGet("get_posts")]
    public async Task<IActionResult> GetPostsAsync()
    {
        var posts = await _context.Posts
                                    .Join(_context.Users, 
                                        post => post.UserId,
                                        user => user.Id,
                                        (post, user) => new 
                                        {
                                            id = post.Id,
                                            username = user.UserName,
                                            createdAt = post.CreatedAt,
                                            content = post.Content,
                                            likes = post.Likes
                                        }
                                    )
                                    .OrderByDescending(post => post.createdAt)
                                    .ToListAsync();
        return Ok(posts);
    }

    [Authorize]
    [HttpGet("get_posts/{userId}")]
    public async Task<IActionResult> GetUserPostsAsync(string userId)
    {
        var userPosts = await _context.Posts
                                        .Join(_context.Users,
                                            post => post.UserId,
                                            user => user.Id,
                                            (post, user) => new
                                            {
                                                id = post.Id,
                                                userId = user.Id,
                                                username = user.UserName,
                                                createdAt = post.CreatedAt,
                                                content = post.Content,
                                                likes = post.Likes
                                            }
                                        )
                                        .Where(user => user.userId == userId)
                                        .OrderByDescending(post => post.createdAt)
                                        .ToListAsync();
        return userPosts != null ? Ok(userPosts) : NotFound();
    }

    [Authorize]
    [HttpPost("create_post")]
    public async Task<IActionResult> CreatePostAsync([FromBody] Post newPost)
    {
        var userId = _userManager.GetUserId(User);
        if (userId == null)
        {
            return BadRequest("You need to be authenticated to create new post!");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest("Post not valid!");
        }
        
        if (newPost.UserId != userId)
        {
            return BadRequest("User id not valid!");
        }

        EncodeUserInput(newPost);
        
        _context.Posts.Add(newPost);
        await _context.SaveChangesAsync();

        return Ok();
    }

    private static void EncodeUserInput(Post post)
    {
        post.Content = HttpUtility.HtmlEncode(post.Content);
    }
}
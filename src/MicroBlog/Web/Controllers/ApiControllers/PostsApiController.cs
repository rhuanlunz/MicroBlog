using System.Security.Claims;
using ApplicationCore.DTOs;
using ApplicationCore.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.ApiControllers;

[Route("api/posts")]
[ApiController]
[Authorize]
public class PostsApiController : Controller
{
    private readonly IPostApiService _postApiService;

    public PostsApiController(IPostApiService postApiService)
    {
        _postApiService = postApiService;
    }

    // GET /api/posts
    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetAllPostsAsync()
    {
        var posts = await _postApiService.GetAllPostsAsync();

        return Ok(new
        {
            success = true,
            data = posts
        });
    }

    // GET /api/posts/{id}
    [HttpGet("{postId}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetPostByIdAsync([FromRoute] int postId)
    {
        try
        {
            var post = await _postApiService.GetPostByIdAsync(postId);

            return Ok(new
            {
                success = true,
                data = post
            });
        }
        catch (Exception error)
        {
            return NotFound(new
            {
                success = false,
                message = error.Message
            });
        }
    }

    // GET /api/posts/user/{username}
    [HttpGet("user/{username}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetAllUserPostsAsync([FromRoute] string username)
    {
        try
        {
            var userPosts = await _postApiService.GetAllUserPostsAsync(username);

            return Ok(new
            {
                success = true,
                data = userPosts
            });
        }
        catch (Exception error)
        {
            return BadRequest(new
            {
                success = false,
                message = error.Message
            });
        }
    }

    // POST /api/posts
    [HttpPost]
    public async Task<IActionResult> CreatePostAsync([FromBody] CreatePostDTO newPost)
    {
        try
        {
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            await _postApiService.CreatePostAsync(newPost, userId);

            return Ok(new
            {
                success = true,
                message = "Post created!"
            });
        }
        catch (Exception error)
        {
            return BadRequest(new
            {
                success = false,
                message = error.Message
            });
        }
    }

    // DELETE /api/posts/{id}
    [HttpDelete("{postId}")]
    public async Task<IActionResult> DeletePostAsync([FromRoute] int postId)
    {
        try
        {
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            await _postApiService.DeletePostAsync(postId, userId);

            return Ok(new
            {
                success = true,
                message = $"Post {postId} deleted!"
            });
        }
        catch (Exception error)
        {
            return BadRequest(new
            {
                success = false,
                message = error.Message
            });
        }
    }

    // PUT /api/posts/{id}/like
    [HttpPut("{postId}/like")]
    public async Task<IActionResult> LikePostAsync([FromRoute] int postId)
    {
        try
        {
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            LikeDTO likeDto = new(postId, userId);

            int totalLikes = await _postApiService.LikePostAsync(likeDto);

            return Ok(new
            {
                success = true,
                data = totalLikes
            });
        }
        catch (Exception error)
        {
            return BadRequest(new
            {
                success = false,
                message = error.Message
            });
        }
    }
}
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

    [HttpGet("{postId}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetPostByIdAsync(int postId)
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

    [HttpPost]
    public async Task<IActionResult> CreatePostAsync([FromBody] CreatePostDTO newPost)
    {
        try
        {
            await _postApiService.CreatePostAsync(newPost, User);

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

    [HttpDelete("{postId}")]
    public async Task<IActionResult> DeletePostAsync(int postId)
    {
        try
        {
            await _postApiService.DeletePostAsync(postId, User);

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
}
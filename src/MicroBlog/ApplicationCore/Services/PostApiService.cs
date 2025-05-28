using System.Security.Claims;
using System.Web;
using ApplicationCore.DTOs;
using AutoMapper;
using Infrastructure.Entities;
using Infrastructure.Interfaces;

namespace ApplicationCore.Services;

public class PostApiService : IPostApiService
{
    private readonly IPostRepository _postRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public PostApiService(
        IPostRepository postRepository,
        IUserRepository userRepository,
        IMapper mapper)
    {
        _postRepository = postRepository;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task CreatePostAsync(CreatePostDTO newPost, ClaimsPrincipal user)
    {
        var userId = await _userRepository.GetUserId(user);

        if (userId != newPost.UserId)
        {
            throw new Exception("Operation not allowed!");
        }

        var newPostEntity = _mapper.Map<Post>(newPost);

        await _postRepository.CreatePostAsync(newPostEntity);
    }

    public async Task DeletePostAsync(int postId, ClaimsPrincipal user)
    {
        var post = await _postRepository.GetPostByIdAsync(postId);

        if (post == null)
        {
            throw new NullReferenceException($"Post {postId} not found!");
        }

        var userId = await _userRepository.GetUserId(user);

        if (userId != post.UserId)
        {
            throw new Exception("Operation not allowed!");
        }

        await _postRepository.DeletePostAsync(post);
    }

    public async Task<List<PostDTO>> GetAllPostsAsync()
    {
        var posts = await _postRepository.GetAllPostsAsync();

        return _mapper.Map<List<PostDTO>>(posts);
    }

    public async Task<PostDTO> GetPostByIdAsync(int postId)
    {
        var post = await _postRepository.GetPostByIdAsync(postId);

        if (post == null)
        {
            throw new NullReferenceException($"Post {postId} not found!");
        }

        return _mapper.Map<PostDTO>(post);
    }

    private static void EncodeUserInput(PostDTO post)
    {
        post.Content = HttpUtility.HtmlEncode(post.Content);
    }
}

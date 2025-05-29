using System.Web;
using ApplicationCore.DTOs;
using AutoMapper;
using Infrastructure.Entities;
using Infrastructure.Interfaces;

namespace ApplicationCore.Services;

public class PostApiService : IPostApiService
{
    private readonly IPostRepository _postRepository;
    private readonly ILikeRepository _likeRepository;
    private readonly IMapper _mapper;

    public PostApiService(
        IPostRepository postRepository,
        ILikeRepository likeRepository,
        IMapper mapper)
    {
        _postRepository = postRepository;
        _likeRepository = likeRepository;
        _mapper = mapper;
    }

    public async Task CreatePostAsync(CreatePostDTO newPost, int userId)
    {
        if (userId != newPost.UserId)
        {
            throw new Exception("Operation not allowed!");
        }

        var newPostEntity = _mapper.Map<Post>(newPost);

        await _postRepository.CreatePostAsync(newPostEntity);
    }

    public async Task DeletePostAsync(int postId, int userId)
    {
        var post = await _postRepository.GetPostByIdAsync(postId);

        if (post == null)
        {
            throw new NullReferenceException($"Post {postId} not found!");
        }

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

    public async Task<int> LikePostAsync(LikeDTO likeDto)
    {
        var post = await _postRepository.GetPostByIdAsync(likeDto.PostId);

        if (post == null)
        {
            throw new NullReferenceException($"Post {likeDto.PostId} not found!");
        }

        if (!_likeRepository.IsPostLikedByUser(likeDto.PostId, likeDto.UserId))
        {
            var like = _mapper.Map<Like>(likeDto);

            await _likeRepository.AddLikeAsync(like);
            post.AddLike();
        }
        else
        {
            var like = await _likeRepository.GetUserLikeAsync(likeDto.PostId, likeDto.UserId);

            await _likeRepository.RemoveLikeAsync(like);
            post.RemoveLike();
        }

        await _postRepository.UpdatePostAsync(post);
        return post.TotalLikes;
    }

    private static void EncodeUserInput(PostDTO post)
    {
        post.Content = HttpUtility.HtmlEncode(post.Content);
    }
}

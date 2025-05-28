using System;
using System.Web;
using ApplicationCore.DTOs;
using AutoMapper;
using Infrastructure.Entities;
using Infrastructure.Interfaces;

namespace ApplicationCore.Services;

public class PostApiService : IPostApiService
{
    public readonly IPostRepository _postRepository;
    public readonly IMapper _mapper;

    public PostApiService(
        IPostRepository postRepository,
        IMapper mapper)
    {
        _postRepository = postRepository;
        _mapper = mapper;
    }

    public async Task CreatePostAsync(CreatePostDTO newPost)
    {
        var newPostEntity = _mapper.Map<Post>(newPost);

        await _postRepository.CreatePostAsync(newPostEntity);
    }

    public async Task DeletePostAsync(int postId)
    {
        var post = await _postRepository.GetPostByIdAsync(postId);

        if (post == null)
        {
            throw new NullReferenceException($"Post {postId} not found!");
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

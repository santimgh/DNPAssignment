using Application.LogicInterfaces;
using FileData.DaoInterfaces;
using Shared.DTOs;
using Shared.Models;

namespace Application.Logic;

public class PostsLogic : IPostsLogic
{
    private readonly IPostDao PostDao;

    public PostsLogic(IPostDao postDao)
    {
        PostDao = postDao;
    }

    public Task<Post> Create(PostCreationDto dto)
    {
        
    }
}
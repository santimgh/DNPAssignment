using Application.LogicInterfaces;
using FileData.DaoInterfaces;
using Shared.DTOs;
using Shared.Models;

namespace Application.Logic;

public class PostsLogic : IPostsLogic
{
    private readonly IPostDao PostDao;
    private readonly IUserDao UserDao;

    public PostsLogic(IPostDao postDao, IUserDao userDao)
    {
        PostDao = postDao;
        UserDao = userDao;
    }

    public async Task<Post> Create(PostCreationDto dto)
    {
        User? user = await UserDao.GetByIdAsync(dto.usernameId);
        if (user == null)
            throw new Exception("You are not logged in! dumbass");

        Post toCreate = new Post()
        {
            userId = dto.usernameId,
            Body = dto.body,
            Title = dto.title
        };

        Post newPost = await PostDao.Create(toCreate);
        return newPost;
    }

    public Task<IEnumerable<Post>> GetAllAsync()
    {
        return PostDao.GetAllAsync();
    }

    public Task<IEnumerable<Post>> GetPostByIdAsync(int id)
    {
        return PostDao.GetPostByIdAsync(id);
    }
}
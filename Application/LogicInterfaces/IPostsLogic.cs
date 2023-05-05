using Shared.DTOs;
using Shared.Models;

namespace Application.LogicInterfaces;

public interface IPostsLogic
{
    Task<Post> Create(PostCreationDto dto);
    Task<IEnumerable<Post>> GetAllAsync();

    Task<Post?> GetPostByIdAsync(int id);
}
using Shared.Models;

namespace FileData.DaoInterfaces;

public interface IPostDao
{
    Task<Post> Create(Post post);
    Task<IEnumerable<Post>> GetAllAsync();
    Task<Post?> GetPostByIdAsync(int id);
}
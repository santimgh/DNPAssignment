using Shared.Models;

namespace FileData.DaoInterfaces;

public interface IPostDao
{
    Task<Post> Create(Post post);
    
}
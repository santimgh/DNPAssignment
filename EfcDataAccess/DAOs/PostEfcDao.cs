using FileData.DaoInterfaces;
using Shared.Models;

namespace EfcDataAccess.DAOs;

public class PostEfcDao : IPostDao
{
    public Task<Post> Create(Post post)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Post>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Post>> GetPostByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}
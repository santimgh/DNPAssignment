using FileData.DaoInterfaces;
using Shared.Models;

namespace FileData.DAOs;

public class PostFileDao : IPostDao
{

    private readonly FileContext _context;

    public PostFileDao(FileContext context)
    {
        _context = context;
    }
    public Task<Post> Create(Post post)
    {
        _context.Posts.Add(post);
        _context.SaveChanges();
        return Task.FromResult(post);
    }
}
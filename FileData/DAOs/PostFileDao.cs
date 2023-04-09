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
        int postId = 1;
        if (_context.Posts.Any())
        {
            postId = _context.Posts.Max(p => p.postId);
            postId++;
        }
        
        post.postId = postId;
        
        _context.Posts.Add(post);
        _context.SaveChanges();
        
        return Task.FromResult(post);
    }

    public Task<IEnumerable<Post>> GetAllAsync()
    {
        IEnumerable<Post> posts = _context.Posts.AsEnumerable();
        return Task.FromResult(posts);
    }
}
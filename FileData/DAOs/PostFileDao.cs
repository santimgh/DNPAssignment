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

    public Task<IEnumerable<Post>> GetPostByIdAsync(int id)
    {
        IEnumerable<Post>? existingPost = _context.Posts.Where(p =>p.postId==id );
        if (existingPost==null)
        {
            throw new Exception("Post not found");
        }
        return Task.FromResult(existingPost);
    }
    
    // public Task<Post> GetPostByTitleAsync(int id)
    // {
    //     Post? existingPost = _context.Posts.FirstOrDefault(p =>p.postId==id );
    //     if (existingPost==null)
    //     {
    //         throw new Exception("Post not found");
    //     }
    //     return Task.FromResult(existingPost);
    // }
    //
    // public Task<Post> GetPostBy....Async(int id)
    // {
    //     Post? existingPost = _context.Posts.FirstOrDefault(p =>p.postId==id );
    //     if (existingPost==null)
    //     {
    //         throw new Exception("Post not found");
    //     }
    //     return Task.FromResult(existingPost);
    // }
    
}
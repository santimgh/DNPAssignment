using FileData.DaoInterfaces;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shared.Models;

namespace EfcDataAccess.DAOs;

public class PostEfcDao : IPostDao
{

    private readonly Context context;

    public PostEfcDao(Context context)
    {
        this.context = context;
    }
    public async Task<Post> Create(Post post)
    {
        EntityEntry<Post> newPost = await context.Posts.AddAsync(post);
        await context.SaveChangesAsync();
        return newPost.Entity;
    }

    public async Task<IEnumerable<Post>> GetAllAsync()
    {
        IEnumerable<Post> posts = context.Posts.AsEnumerable();
        return posts;
    }

    public async Task<Post?> GetPostByIdAsync(int id)
    {
        Post? existing = await context.Posts.FindAsync(id);
        return existing;
    }
}
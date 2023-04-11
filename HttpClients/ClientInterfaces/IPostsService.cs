using Shared.DTOs;
using Shared.Models;

namespace Httplients.ClientInterfaces;

    public interface IPostsService
    {
        Task CreateAsync(PostCreationDto dto);
        Task<ICollection<Post>> GetAsync(string? title, int? userId, int? postId, string? body);
        int id { get; set; }
    }

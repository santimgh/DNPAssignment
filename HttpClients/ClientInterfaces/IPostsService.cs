using Shared.DTOs;

namespace Httplients.ClientInterfaces;

    public interface IPostsService
    {
        Task CreateAsync(PostCreationDto dto);
    }

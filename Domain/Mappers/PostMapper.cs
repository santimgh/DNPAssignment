using Shared.DTOs;
using Shared.Models;

namespace Shared.Mappers;

public class PostMapper
{
    public static Post CreationDtoToModel(PostCreationDto dto)
    {
        Post model = new Post()
        {
            userId = dto.usernameId,
            Body = dto.body,
            Title = dto.title
        };

        return model;
    }
}
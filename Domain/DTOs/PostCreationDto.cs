namespace Shared.DTOs;

public class PostCreationDto
{
    public int usernameId { get; }
    
    public String title { get; }

    public String body { get; }

    public PostCreationDto(int id, String title, String body)
    {
        usernameId = id;
        this.title = title;
        this.body = body;
    }
    
    
}
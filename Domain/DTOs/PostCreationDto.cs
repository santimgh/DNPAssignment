namespace Shared.DTOs;

public class PostCreationDto
{
    public String username { get; }

    public String title { get; }

    public String body { get; }

    public PostCreationDto(String username, String title, String body)
    {
        this.username = username;
        this.title = title;
        this.body = body;
    }
    
    
}
namespace Shared.DTOs;

public class PostCreationDto
{
    public int usernameId { get; }
    
    public String title { get; }

    public String body { get; }

    public PostCreationDto(int usernameId, String title, String body)
    {
        this.usernameId = usernameId;
        this.title = title;
        this.body = body;
    }
    
    
}
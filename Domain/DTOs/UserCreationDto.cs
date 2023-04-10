namespace Shared.DTOs;

public class UserCreationDto
{
    
    public string Email { get; }
    public string Name { get; }
    public string Username { get; }
    public string PassWord { get; }

    public UserCreationDto(string email, string name,string username, string password)
    {
        Email = email;
        Name = name;
        Username = username;
        PassWord = password;
    }

}
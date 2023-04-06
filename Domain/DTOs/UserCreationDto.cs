namespace Shared.DTOs;

public class UserCreationDto
{
    public string Username { get; }
    public string PassWord { get; }

    public UserCreationDto(string username, string passWord)
    {
        Username = username;
        PassWord = passWord;
    }

}
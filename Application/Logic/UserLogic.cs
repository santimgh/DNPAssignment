using System.Text.RegularExpressions;
using Application.LogicInterfaces;
using FileData.DaoInterfaces;
using Shared.DTOs;
using Shared.Models;

namespace Application.Logic;

public class UserLogic : IUserLogic
{
    private readonly IUserDao userDao;

    public UserLogic(IUserDao userDao)
    {
        this.userDao = userDao;
    }
    
    public async Task<User> Create(UserCreationDto dto)
    {
        User? existing = await userDao.GetByUsernameAsync(dto.Username);
        if (existing != null)
            throw new Exception("Username is already taken!");
        

        ValidateData(dto);
        
        User toCreate = new User
        {
            Name = dto.Name,
            Email = dto.Email,
            UserName = dto.Username,
            Password = dto.PassWord
        };

        User created = await userDao.CreateAsync(toCreate);
        return created;
    }

    public Task<IEnumerable<User>> GetAllAsync()
    {
        return userDao.GetAllAsync();
    }

    public Task<User?> GetUserByIdAsync(int id)
    {
        return userDao.GetByIdAsync(id);
    }


    private static void ValidateData(UserCreationDto userToCreate)
    {
        string userName = userToCreate.Username;
        string passWord = userToCreate.PassWord;
        
        Regex userRegex = new Regex("^[a-zA-Z0-9_-]{3,15}$");
        Regex passRegex = new Regex("^[^\\s]{5,}$");

        if (!userRegex.IsMatch(userName)) throw new Exception("Username is not valid, must be between 3-15 characters,without empty spaces and special characters different from '-' '_' or '.'");
        if (!passRegex.IsMatch(userName)) throw new Exception("Password is not valid, must be more than 4 characters without empty spaces");
    }
}
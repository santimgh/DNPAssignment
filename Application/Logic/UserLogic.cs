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
            UserName = dto.Username,
            Password = dto.PassWord
        };

        User created = await userDao.CreateAsync(toCreate);
        return created;
    }

    private static void ValidateData(UserCreationDto userToCreate)
    {
        string userName = userToCreate.Username;

        if (userName.Length < 3)
            throw new Exception("Username is too short. At least 3 characters!");
        if (userName.Length > 15)
            throw new Exception("Username is too long. No more than 15 characters!");
    }
}

using System.ComponentModel.DataAnnotations;
using Application.Services;
using FileData.DaoInterfaces;
using Shared.Models;

namespace FileData.DAOs;

public class UserFileDao : IUserDao, IAuthService
{

    private readonly FileContext context;

    public UserFileDao(FileContext context)
    {
        this.context = context;
    }
    public Task<User> CreateAsync(User user)
    {
        int userId = 1;
        if (context.Users.Any())
        {
            userId = context.Users.Max(u => u.Id);
            userId++;
        }

        user.Id = userId;
        
        context.Users.Add(user);
        context.SaveChanges();

        return Task.FromResult(user);
    }

    public Task<User?> GetByUsernameAsync(string userName)
    {
        User? existing = 
            context.Users.FirstOrDefault(u => u.UserName.Equals(userName, StringComparison.OrdinalIgnoreCase));
        return Task.FromResult(existing);
    }

    public Task<User?> GetByIdAsync(int dtoUsernameId)
    {
        User? existing = context.Users.FirstOrDefault(u => u.Id.Equals(dtoUsernameId));
        return Task.FromResult(existing);
    }

    public Task<IEnumerable<User>> GetAllAsync()
    {
        IEnumerable<User> users = context.Users.AsEnumerable();
        return Task.FromResult(users);
    }

    public Task<User> GetUser(string username, string password)
    {
        User? existingUser =
            context.Users.FirstOrDefault(u => u.UserName.Equals(username, StringComparison.OrdinalIgnoreCase));

        if (existingUser==null)
        {
            throw new Exception("User not found");
        }

        if (!existingUser.Password.Equals(password))
        {
            throw new Exception("Password mismatch");
        }

        return Task.FromResult(existingUser);
    }

    public Task RegisterUser(User user)
    {
        if (string.IsNullOrEmpty(user.UserName))
        {
            throw new ValidationException("Username cannot be null");
        }

        if (string.IsNullOrEmpty(user.Password))
        {
            throw new ValidationException("Password cannot be null");
        }

        if (string.IsNullOrEmpty(user.Email))
        {
            throw new ValidationException("Email cannot be null");
        }

        if (string.IsNullOrEmpty(user.Name))
        {
            throw new ValidationException("Name cannot be null");
        }
        
        context.Users.Add(user);
        context.SaveChanges();
        return Task.CompletedTask;
    }
}

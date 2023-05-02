using Application.Services;
using FileData.DaoInterfaces;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shared.Models;

namespace EfcDataAccess.DAOs;

public class UserEfcDao : IUserDao, IAuthService
{
    private readonly Context context;

    public UserEfcDao(Context context)
    {
        this.context = context;
    }
    
    public async Task<User> CreateAsync(User user)
    {
        if (user.Email.Contains("@") && user.Email.Contains("."))
        {
            EntityEntry<User> newUser = await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            return newUser.Entity;
        }
        else
        {
            throw new Exception("Insert a valid email");
        }
    }

    public async Task<User?> GetByUsernameAsync(string userName)
    {
        User? existing = context.Users.FirstOrDefault(u => u.UserName.ToLower().Equals(userName.ToLower()));
        return existing;
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        User? existing = await context.Users.FindAsync(id);
        return existing;
    }

    public Task<IEnumerable<User>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<User>> GetUserByName(string name)
    {
        throw new NotImplementedException();
    }

    //Find user for login
    public async Task<User> GetUser(string username, string password)
    {
        throw new NotImplementedException();
    }

    public Task RegisterUser(User user)
    {
        throw new NotImplementedException();
    }
}
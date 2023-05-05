using Application.Services;
using FileData.DaoInterfaces;
using Microsoft.EntityFrameworkCore;
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

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        IEnumerable<User> users = context.Users.AsEnumerable();
        return users;
    }

    public async Task<IEnumerable<User>> GetUserByName(string name)
    {
        IQueryable<User?> query = context.Users.Where(u => u.Name.Equals(name));
        IEnumerable<User?> enumerable = query.AsEnumerable();
        return enumerable;
    }

    //Find user for login
    public async Task<User> GetUser(string username, string password)
    {
        User user = await context.Users.FirstOrDefaultAsync(u => u.UserName == username && u.Password == password);
        return user;
    }

    public Task RegisterUser(User user)
    {
        throw new NotImplementedException();
    }
}
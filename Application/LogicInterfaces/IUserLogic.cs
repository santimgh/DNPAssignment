using Shared.DTOs;
using Shared.Models;

namespace Application.LogicInterfaces;

public interface IUserLogic
{
    Task<User> Create(UserCreationDto dto);
    Task<IEnumerable<User>> GetAllAsync();
    Task<User?> GetUserByIdAsync(int id);
    //hello
}
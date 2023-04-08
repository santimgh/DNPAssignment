using Shared.DTOs;
using Shared.Models;

namespace Httplients.ClientInterfaces;


public interface IUserService
{
    Task<User> Create(UserCreationDto dto);
}
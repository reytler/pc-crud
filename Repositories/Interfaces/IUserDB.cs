using crudpcapi.DTOs;
using crudpcapi.Models;

namespace crudpcapi.Repositories;

public interface IUserDB
{
    Task<User> CreateUser(User user);
    Task<User> UpdateUser(UserDTO user);
    Task<User> FindUserById(string userId);

    Task<List<User>> FindUsers(FilterUserDTO filters);

    Task<bool> UpdatePassword(UpdatePasswordDTO updatePasswordDTO);
    Task<bool> UsuarioExists(int usuario);

    Task<User> Validate(LoginDTO login);
}

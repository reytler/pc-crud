using crudpcapi.DTOs;
using crudpcapi.Mappers;
using crudpcapi.Models;
using crudpcapi.Repositories;
using crudpcapi.Services;

namespace crudpcapi.Domains;

public class UserDomain
{
    private IServiceProvider _serviceProvider;
    private IUserDB _userDB;
    public UserDomain(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public IUserDB UserDB
    {
        get
        {
            if (_userDB == null)
            {
                _userDB = _serviceProvider.GetService<IUserDB>()!;
            }
            return _userDB;
        }
    }

    public async Task<UserDTO> CreateUser(UserDTO user)
    {
        var usuarioCriado = await UserDB.CreateUser(user.ConverterParaModel());

        return usuarioCriado.ConverterParaDTO();
    }

    public async Task<UserDTO> UpdateUser(UserDTO user)
    {
        var usuarioAtualizado = await UserDB.UpdateUser(user);

        return usuarioAtualizado.ConverterParaDTO();
    }

    public async Task<UserDTO> GetUser(string idUser)
    {
        try
        {
            var res = await UserDB.FindUserById(idUser);
            return res.ConverterParaDTO();
        }catch (Exception ex)
        {
            throw new Exception("Usuário não encontrado");
        }
    }

    public async Task<List<UserDTO>> GetUsers(FilterUserDTO filters)
    {
        var res = await UserDB.FindUsers(filters);
        List<UserDTO> users = new List<UserDTO>();

        foreach (var user in res)
        {
            users.Add(user.ConverterParaDTO());
        }

        return users;
    }

    public async Task<bool> UpdatePassword(UpdatePasswordDTO updatePasswordDTO)
    {
        var encryptionService = new EncryptionService(Config.Secret);
        updatePasswordDTO.Password = encryptionService.GerarHash(updatePasswordDTO.Password);
        return await UserDB.UpdatePassword(updatePasswordDTO);

    }

    public async Task<LoginResultDTO> Login(LoginDTO login)
    {
        var encryptionService = new EncryptionService(Config.Secret);
        User userResult = null;
        login.Senha = encryptionService.GerarHash(login.Senha);
        try
        {
             userResult = await UserDB.Validate(login);
        } catch (Exception ex)
        {
            throw new Exception("Login ou senha incorretos");
        }

        var token = TokenService.GenerateToken(userResult);

        return new LoginResultDTO
        {
            token = token,
            User = userResult.ConverterParaDTO(),
        };
    }
}

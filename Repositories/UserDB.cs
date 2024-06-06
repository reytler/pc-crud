using crudpcapi.DTOs;
using crudpcapi.Models;
using Microsoft.EntityFrameworkCore;

namespace crudpcapi.Repositories;

public class UserDB : IUserDB
{
    private readonly MysqlContext _context;

    public UserDB(MysqlContext context)
    {
        _context = context;
    }

    public async Task<User> CreateUser(User user)
    {
        if (await UsuarioExists(user.Usuario))
        {
            throw new Exception("Já existe um resgistro com esse usuário");
        }

        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<User> FindUserById(string userId)
    {
        return await _context.Users
            .AsNoTracking()
            .SingleAsync(u=>u.Id == userId);
    }

    public async Task<bool> UsuarioExists(int usuario)
    {
        var res =  await _context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Usuario == usuario);

        if (res == null)
            return false;

        return true;
    }

    public async Task<List<User>> FindUsers(FilterUserDTO filters)
    {
        var query = _context.Users.AsQueryable();

        if(filters.Usuario.HasValue)
            query = query.Where(u=>u.Usuario == filters.Usuario);

        if(!string.IsNullOrEmpty(filters.Role))
            query = query.Where(u=>u.Role == filters.Role);

        return await query.ToListAsync();
    }

    public async Task<User> UpdateUser(UserDTO user)
    {
        User res = null;

        try
        {
            res = await FindUserById(user.Id);
        }
        catch (Exception ex)
        {
            throw new Exception("Usuário não encontrado: " + ex.Message);
        }

        if (await UsuarioExists(user.Usuario))
        {
            var temp = await _context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Usuario == user.Usuario);

            if(temp.Id != user.Id)
            {
                throw new Exception("Já existe um resgistro com esse usuário");
            }
        }

        res.Usuario = user.Usuario;
        res.Role = user.Role;

        _context.Users.Update(res);
        await _context.SaveChangesAsync();
        return res;
    }

    public async Task<bool> UpdatePassword(UpdatePasswordDTO updatePasswordDTO)
    {
        User res = null;

        try
        {
            res = await FindUserById(updatePasswordDTO.Id);
        } catch (Exception ex)
        {
            throw new Exception("Usuário não encontrado: " + ex.Message);
        }

        res.Senha = updatePasswordDTO.Password;
        res.AlterarSenha = updatePasswordDTO.AlterarSenha;
        _context.Users.Update(res);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<User> Validate(LoginDTO login)
    {
       return await _context.Users.AsNoTracking()
            .SingleAsync(u => 
                u.Usuario.Equals(login.Usuario) 
                && u.Senha.Equals(login.Senha));
    }
}

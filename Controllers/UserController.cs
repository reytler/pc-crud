using crudpcapi.Domains;
using crudpcapi.DTOs;
using crudpcapi.Mappers;
using crudpcapi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel.DataAnnotations;

namespace crudpcapi.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : BaseController
    {
        private IServiceProvider _serviceProvider;
        public UserController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        [HttpPost("create")]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> Create(
            [FromHeader(Name = "Authorization"), Required] string token,
            [FromBody] UserDTO user)
        {
            return await EncapsularChamadaDomain(async () =>
            {
                var userDomain = new UserDomain(_serviceProvider);
                var usuarioCriado = await userDomain.CreateUser(user);

                if(usuarioCriado != null)
                {
                    return Ok(new ApiResultDTO<UserDTO>
                    {
                        Data = usuarioCriado
                    });
                }

                throw new Exception("Não foi possível criar o usuário");
            });
        }

        [HttpPatch("update")]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> Update(
            [FromHeader(Name = "Authorization"), Required] string token,
            [FromBody] UserDTO user)
        {
            return await EncapsularChamadaDomain(async () =>
            {
                var userDomain = new UserDomain(_serviceProvider);
                var usuarioAlterado = await userDomain.UpdateUser(user);

                if (usuarioAlterado != null)
                {
                    return Ok(new ApiResultDTO<UserDTO>
                    {
                        Data = usuarioAlterado
                    });
                }

                throw new Exception("Não foi possível criar o usuário");
            });
        }

        [HttpGet("getuser/{idUser}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> GetUser(
            [FromHeader(Name = "Authorization"), Required] string token,
            [FromRoute] string idUser)
        {
            return await EncapsularChamadaDomain(async () =>
            {
                var userDomain = new UserDomain(_serviceProvider);
                var usuarioEncontrado = await userDomain.GetUser(idUser);

                return Ok(new ApiResultDTO<UserDTO>
                {
                    Data = usuarioEncontrado
                });
                
            });
        }

        [HttpGet()]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> GetUsers(
            [FromHeader(Name = "Authorization"), Required] string token,
            FilterUserDTO filters)
        {
            return await EncapsularChamadaDomain(async () =>
            {
                var userDomain = new UserDomain(_serviceProvider);
                var usuariosEncontrados = await userDomain.GetUsers(filters);

                return Ok(new ApiResultDTO<List<UserDTO>>
                {
                    Data = usuariosEncontrados
                });

            });
        }

        [HttpPatch("password")]
        [Authorize(Roles = "ADMIN,USER")]
        public async Task<IActionResult> UpdatePassword(
            [FromHeader(Name = "Authorization"), Required] string token, 
            UpdatePasswordDTO updatePasswordDTO)
        {
            return await EncapsularChamadaDomain(async () =>
            {
                var userDomain = new UserDomain(_serviceProvider);
                var senhaAlterada = await userDomain.UpdatePassword(updatePasswordDTO);  
                
                return Ok(new ApiResultDTO<bool>
                {
                    Data = senhaAlterada
                });

            });
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginDTO login)
        {
            return await EncapsularChamadaDomain(async () =>
            {
                var userDomain = new UserDomain(_serviceProvider);
                var usuarioLogado = await userDomain.Login(login);

                return Ok(new ApiResultDTO<LoginResultDTO>
                {
                    Data = usuarioLogado
                });

            });
        }
    }
}

using crudpcapi.DTOs;
using crudpcapi.Models;
using crudpcapi.Services;
using System.Data;

namespace crudpcapi.Mappers
{
    public static class MapperUser
    {

        public static User ConverterParaModel(this UserDTO user)
        {
            var encryptionService = new EncryptionService(Config.Secret);
            return new User()
            {
                Id = Guid.NewGuid().ToString(),
                Senha = encryptionService.GerarHash(user.Senha),
                Usuario = user.Usuario,
                Role = user.Role,
            };
        }

        public static User ConverterParaUpdateModel(this UserDTO user)
        {
            return new User()
            {
                Id = user.Id,
                Usuario = user.Usuario,
                Role = user.Role,
            };
        }

        public static UserDTO ConverterParaDTO(this User user)
        {
            return new UserDTO()
            {
                Id = user.Id,
                Senha = null,
                Usuario = user.Usuario,
                Role = user.Role,
                AlterarSenha = user.AlterarSenha
            };
        }
    }
}

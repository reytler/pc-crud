using crudpcapi.DTOs;
using crudpcapi.Models;
using crudpcapi.Services;
using crudpcapi.Utils;
using System.Text.RegularExpressions;

namespace crudpcapi.Mappers
{
    public static class MapperSujeito
    {
        private static string CpfSemCaracteres(string cpf)
        {
            var encryptionService = new EncryptionService(Config.Secret);

            var cpfSemCaracteres = Regex.Replace(cpf, "[^0-9]", "");
            var valido = Util.ValidateCpf(cpf);

            if (valido == true)
            {
                return encryptionService.Encrypt(cpfSemCaracteres);
            }

            throw new Exception("O Cpf informado não é válido");
        }
        public static Sujeito ConverterParaModel(this SujeitoDTO sujeitoDTO)
        {
            return new Sujeito() { 
                Id = sujeitoDTO.Id,
                Nome = sujeitoDTO.Nome,
                Vulgo = sujeitoDTO.Vulgo,
                Cidade = sujeitoDTO.Cidade,
                Rua = sujeitoDTO.Rua,
                Complemento = sujeitoDTO.Complemento,
                Referencia = sujeitoDTO.Referencia,
                Idade = sujeitoDTO.Idade,
                AlturaAproximada = sujeitoDTO.AlturaAproximada,
                Cpf = CpfSemCaracteres(sujeitoDTO.Cpf),
                Photos = sujeitoDTO.Photos.ConverterParaModel(sujeitoDTO.Id),
            };
        }
    }
}

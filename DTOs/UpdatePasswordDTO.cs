using Microsoft.Extensions.FileSystemGlobbing.Internal;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace crudpcapi.DTOs;

public class UpdatePasswordDTO
{
    public string Id { get; set; }
    /// <summary>
    /// Informe uma senha que atenda os seguintes requisitos:
    /// - 6 Caracteres
    /// - No mínimo uma letra Maiúscula
    /// - No mínimo uma letra minúscula
    /// - No mínimo um caractere numérico
    /// - No minimo um caractere especial
    /// </summary>
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*()_+\-=\[\]{};':""\\|,.<>\/?]).{6}$", ErrorMessage = "Informe uma senha que atenda todos os requisitos")]
    public string Password { get; set; }

    public bool? AlterarSenha { get; set; } = false;
}

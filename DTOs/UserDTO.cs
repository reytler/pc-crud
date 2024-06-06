using System.ComponentModel.DataAnnotations;

namespace crudpcapi.DTOs;
public class UserDTO
{
    public string? Id { get; set; } = null;

    [Required(ErrorMessage = "O campo Usuario é obrigatório")]
    public int Usuario { get; set; }
    public string? Senha { get; set; }
    [Required(ErrorMessage = "O campo Role é obrigatório")]
    public string Role { get; set; }
    public bool? AlterarSenha { get; set; }
}

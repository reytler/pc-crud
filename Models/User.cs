using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace crudpcapi.Models;

[Table("USERS")]
public class User
{
    [Key, Column("ID_USUARIO")]
    public string Id { get; set; }

    [Column("USUARIO")]
    public int Usuario { get; set; }
    [Column("SENHA")]
    public string? Senha { get; set; }
    [Column("ROLE")]
    public string? Role { get; set; }
    [Column("ALTERAR_SENHA")]
    public bool? AlterarSenha { get; set; } = false;
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace crudpcapi.Models;

[Table("USERS")]
public class User
{
    [Key,Column("ID_USUARIO")]
    public string Id { get; set; }

    [Column("NOME")]
    public string Nome { get; set; }
    [Column("USUARIO")]
    public string Usuario { get; set; }
    [Column("SENHA")]
    public string Senha { get; set; }
    [Column("ROLE")]
    public string? Role { get; set; }
    [Column("FOTO_PERFIL")]
    public byte[]? FotoPerfil { get; set; }
}

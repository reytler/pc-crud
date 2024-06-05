using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace crudpcapi.Models;

[Table("SUJEITOS")]
public class Sujeito
{
    [Key,Column("CODIGO")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    [Column("NOME")]
    public string Nome { get; set; }
    [Column("VULGO")]
    public string Vulgo { get; set; }
    [Column("IDADE")]
    public int Idade { get; set; }
    [Column("CPF")]
    public string Cpf { get; set; }
    [Column("ALTURA_APROXIMADA")]
    public int AlturaAproximada { get; set; }
    [Column("CIDADE")]
    public string Cidade { get; set; }
    [Column("RUA")]
    public string Rua { get; set; }
    [Column("COMPLEMENTO")]
    public string? Complemento { get; set; }
    [Column("REFERENCIA")]
    public string? Referencia { get; set; }

    public ICollection<Photo> Photos { get; set; } = new List<Photo>();
}

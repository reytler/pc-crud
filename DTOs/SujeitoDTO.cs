using System.ComponentModel.DataAnnotations;

namespace crudpcapi.DTOs;

public class SujeitoDTO
{
    public long? Id { get; set; } = 0;

    [Required(ErrorMessage ="O campo Nome é obrigatório")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O campo Vulgo é obrigatório")]
    public string Vulgo { get; set; }

    [Required(ErrorMessage = "O campo Idade é obrigatório")]
    public int Idade { get; set; }

    [Required(ErrorMessage = "O campo Cpf é obrigatório")]
    public string Cpf { get; set; }

    [Required(ErrorMessage = "O campo Altura Aproximada é obrigatório")]
    public int AlturaAproximada { get; set; }

    [Required(ErrorMessage = "O campo Cidade é obrigatório")]
    public string Cidade { get; set; }

    [Required(ErrorMessage = "O campo Rua é obrigatório")]
    public string Rua { get; set; }

    public string? Complemento { get; set; }

    public string? Referencia { get; set; }

    [Required(ErrorMessage = "Carregar as fotos é obrigatório")]
    public List<PhotoDTO> Photos { get; set; }
}

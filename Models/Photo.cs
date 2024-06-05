using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace crudpcapi.Models;

[Table("PHOTOS")]
public class Photo
{
    [Key, Column("CODIGO")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    [Column("CODIGO_SUJEITO")]
    public int SujeitoId { get; set; }

    [Column("PHOTO_BYTES")]
    public byte[] PhotoBytes { get; set; }
}

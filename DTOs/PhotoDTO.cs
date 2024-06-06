namespace crudpcapi.DTOs
{
    public class PhotoDTO
    {
        public int? Id { get; set; } = null;
        public byte[] Photobytes { get; set; }

        public int? SujeitoId { get; set; }
    }
}

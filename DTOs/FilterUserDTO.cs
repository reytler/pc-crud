using Microsoft.AspNetCore.Mvc;

namespace crudpcapi.DTOs
{
    public class FilterUserDTO
    {
        [FromQuery(Name = "usuario")]
        public int? Usuario { get; set; }
        [FromQuery(Name = "role")]
        public string? Role { get; set; }
    }
}

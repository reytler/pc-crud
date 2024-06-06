namespace crudpcapi.DTOs;

public class LoginResultDTO
{
    public UserDTO User { get; set; }
    public string token { get; set; }
}

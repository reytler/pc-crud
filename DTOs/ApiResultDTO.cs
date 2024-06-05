namespace crudpcapi.DTOs
{
    public class ApiResultDTO<T>
    {
        public string? Message { get; set; }

        public T? Data { get; set; }

        public List<string>? Errors { get; set; }
    }
}

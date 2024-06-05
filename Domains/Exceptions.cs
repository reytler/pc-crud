namespace crudpcapi.Domains;

public class NotFoundException : Exception
{
    public bool IgnoreLog { get; set; }
    public NotFoundException(string message) : base(message)
    {
    }

    public NotFoundException(string message, bool ignoreLog) : base(message)
    {
        this.IgnoreLog = ignoreLog;
    }
}

public class BadRequestException : Exception
{
    public BadRequestException(string message) : base(message)
    {
    }
}


public class ForbiddenException : Exception
{
    public ForbiddenException(string message) : base(message)
    {
    }
}

public class ExternalApiException : Exception
{
    public int StatusCode { get; set; }
    public ExternalApiException(int statusCode, string message) : base(message)
    {
        this.StatusCode = statusCode;
    }
}

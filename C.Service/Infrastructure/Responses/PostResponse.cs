namespace C.Service.Infrastructure.Responses;
public class PostResponse
{
    public bool Succeeded { get; set; }
    public string Message { get; set; }

    public PostResponse(bool succeeded, string message)
    {
        Succeeded = succeeded;
        Message = message;
    }
    public PostResponse(bool succeeded)
    {
        Succeeded = succeeded;
        Message = string.Empty;
    }
}

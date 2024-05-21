namespace C.Service.Infrastructure.Responses;
public class GetResponse<T> where T : class
{
    public bool Succeeded { get; set; }
    public string Message { get; set; }
    public T? Data { get; set; }

    public GetResponse(bool succeeded, string message)
    {
        Succeeded = succeeded;
        Message = message;
        Data = null;
    }

    public GetResponse(bool succeeded, T data)
    {
        Succeeded = succeeded;
        Message = string.Empty;
        Data = data;
    }
}

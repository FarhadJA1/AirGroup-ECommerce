namespace C.Service.Infrastructure.Responses;
public class GetAllResponse<T> where T : class
{
    public bool Succeeded { get; set; }
    public string Message { get; set; }
    public List<T> Data { get; set; }

    public GetAllResponse(bool succeeded, string message)
    {
        Succeeded = succeeded;
        Message = message;
        Data = new List<T>(0);
    }

    public GetAllResponse(bool succeeded, List<T> data)
    {
        Succeeded = succeeded;
        Message = string.Empty;
        Data = data;
    }
}
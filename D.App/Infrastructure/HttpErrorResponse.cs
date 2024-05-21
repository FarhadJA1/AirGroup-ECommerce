namespace D.App.Infrastructure;
public class HttpErrorResponse
{
    public bool Succeeded { get; set; }
    public List<string> Messages { get; private set; }
    
    public HttpErrorResponse(List<string> messages)
    {
        Messages = messages;
        Succeeded = false;
    }
}

namespace A.Domain.Exceptions;
public class InvalidClientOperationException : Exception
{
    public InvalidClientOperationException(string message) : base(message)
    {

    }
}

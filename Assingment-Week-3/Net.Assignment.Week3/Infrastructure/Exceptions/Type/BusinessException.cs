namespace Infrastructure.Exceptions.Type;

public class BusinessException : Exception
{
    public BusinessException(string message) : base(message)
    {
    }
}
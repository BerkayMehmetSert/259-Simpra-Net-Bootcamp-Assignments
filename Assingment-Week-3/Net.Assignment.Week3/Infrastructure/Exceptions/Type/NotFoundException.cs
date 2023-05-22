namespace Infrastructure.Exceptions.Type;

public class NotFoundException : Exception
{
    public NotFoundException(string message) : base(message)
    {
    }
}
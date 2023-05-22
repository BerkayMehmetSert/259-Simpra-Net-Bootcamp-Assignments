using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Infrastructure.Exceptions.Details;

public class NotFoundExceptionDetails : ProblemDetails
{
    public NotFoundExceptionDetails(string detail)
    {
        Title = "Not Found Exception";
        Status = StatusCodes.Status404NotFound;
        Detail = detail;
        Type = "https://example.com/probs/not-found";
    }
}
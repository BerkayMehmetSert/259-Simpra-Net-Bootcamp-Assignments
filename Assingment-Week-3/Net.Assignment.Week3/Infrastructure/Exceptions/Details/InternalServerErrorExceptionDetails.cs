using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Infrastructure.Exceptions.Details;

public class InternalServerErrorExceptionDetails : ProblemDetails
{
    public InternalServerErrorExceptionDetails(string detail)
    {
        Title = "Internal Server Error Exception";
        Status = StatusCodes.Status500InternalServerError;
        Detail = detail;
        Type = "https://example.com/probs/internal-server-error";
    }
}
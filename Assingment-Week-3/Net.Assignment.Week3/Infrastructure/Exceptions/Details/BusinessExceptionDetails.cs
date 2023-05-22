using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Infrastructure.Exceptions.Details;

public class BusinessExceptionDetails : ProblemDetails
{
    public BusinessExceptionDetails(string detail)
    {
        Title = "Business Exception";
        Status = StatusCodes.Status400BadRequest;
        Detail = detail;
        Type = "https://example.com/probs/business";
    }
}
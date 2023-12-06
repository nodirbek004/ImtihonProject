using System.Net;

namespace Restarant.Domain.Exceptions;

public class NotFoundException:Exception
{
    public HttpStatusCode StatusCode { get; } = HttpStatusCode.NotFound;

    public string TitleMessage { get; protected set; } = string.Empty;
}


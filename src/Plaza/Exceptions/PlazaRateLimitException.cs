using System.Net.Http;

namespace Plaza.Exceptions;

public class PlazaRateLimitException : Plaza4xxException
{
    public PlazaRateLimitException(HttpRequestException? innerException = null)
        : base(innerException) { }
}

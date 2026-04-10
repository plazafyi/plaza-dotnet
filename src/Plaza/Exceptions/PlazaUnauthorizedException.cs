using System.Net.Http;

namespace Plaza.Exceptions;

public class PlazaUnauthorizedException : Plaza4xxException
{
    public PlazaUnauthorizedException(HttpRequestException? innerException = null)
        : base(innerException) { }
}

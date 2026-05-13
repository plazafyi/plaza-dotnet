using System.Net.Http;

namespace Plaza.Exceptions;

public class PlazaForbiddenException : Plaza4xxException
{
    public PlazaForbiddenException(HttpRequestException? innerException = null)
        : base(innerException) { }
}

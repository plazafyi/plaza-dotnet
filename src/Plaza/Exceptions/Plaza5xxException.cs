using System.Net.Http;

namespace Plaza.Exceptions;

public class Plaza5xxException : PlazaApiException
{
    public Plaza5xxException(HttpRequestException? innerException = null)
        : base(innerException) { }
}

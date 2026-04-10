using System.Net.Http;

namespace Plaza.Exceptions;

public class Plaza4xxException : PlazaApiException
{
    public Plaza4xxException(HttpRequestException? innerException = null)
        : base(innerException) { }
}

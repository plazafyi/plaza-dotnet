using System.Net.Http;

namespace Plaza.Exceptions;

public class PlazaUnexpectedStatusCodeException : PlazaApiException
{
    public PlazaUnexpectedStatusCodeException(HttpRequestException? innerException = null)
        : base(innerException) { }
}

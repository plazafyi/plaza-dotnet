using System.Net.Http;

namespace Plaza.Exceptions;

public class PlazaBadRequestException : Plaza4xxException
{
    public PlazaBadRequestException(HttpRequestException? innerException = null)
        : base(innerException) { }
}

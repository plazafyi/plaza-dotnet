using System.Net.Http;

namespace Plaza.Exceptions;

public class PlazaNotFoundException : Plaza4xxException
{
    public PlazaNotFoundException(HttpRequestException? innerException = null)
        : base(innerException) { }
}

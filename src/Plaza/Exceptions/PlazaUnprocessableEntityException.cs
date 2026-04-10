using System.Net.Http;

namespace Plaza.Exceptions;

public class PlazaUnprocessableEntityException : Plaza4xxException
{
    public PlazaUnprocessableEntityException(HttpRequestException? innerException = null)
        : base(innerException) { }
}

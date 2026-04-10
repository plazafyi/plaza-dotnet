using System;
using System.Net.Http;

namespace Plaza.Exceptions;

public class PlazaException : Exception
{
    public PlazaException(string message, Exception? innerException = null)
        : base(message, innerException) { }

    protected PlazaException(HttpRequestException? innerException)
        : base(null, innerException) { }
}

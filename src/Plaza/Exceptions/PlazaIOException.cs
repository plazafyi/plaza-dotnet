using System;
using System.Net.Http;

namespace Plaza.Exceptions;

public class PlazaIOException : PlazaException
{
    public new HttpRequestException InnerException
    {
        get
        {
            if (base.InnerException == null)
            {
                throw new ArgumentNullException();
            }
            return (HttpRequestException)base.InnerException;
        }
    }

    public PlazaIOException(string message, HttpRequestException? innerException = null)
        : base(message, innerException) { }
}

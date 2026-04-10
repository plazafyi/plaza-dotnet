using System;

namespace Plaza.Exceptions;

public class PlazaInvalidDataException : PlazaException
{
    public PlazaInvalidDataException(string message, Exception? innerException = null)
        : base(message, innerException) { }
}

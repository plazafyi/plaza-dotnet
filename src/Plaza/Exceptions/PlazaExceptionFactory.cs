using System.Net;

namespace Plaza.Exceptions;

public class PlazaExceptionFactory
{
    public static PlazaApiException CreateApiException(
        HttpStatusCode statusCode,
        string responseBody
    )
    {
        return (int)statusCode switch
        {
            400 => new PlazaBadRequestException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
            },
            401 => new PlazaUnauthorizedException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
            },
            403 => new PlazaForbiddenException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
            },
            404 => new PlazaNotFoundException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
            },
            422 => new PlazaUnprocessableEntityException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
            },
            429 => new PlazaRateLimitException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
            },
            >= 400 and <= 499 => new Plaza4xxException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
            },
            >= 500 and <= 599 => new Plaza5xxException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
            },
            _ => new PlazaUnexpectedStatusCodeException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
            },
        };
    }
}

using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Plaza.Core;
using Plaza.Services;

namespace Plaza;

/// <summary>
/// A client for interacting with the Plaza REST API.
///
/// <para>This client performs best when you create a single instance and reuse it
/// for all interactions with the REST API. This is because each client holds its
/// own connection pool and thread pools. Reusing connections and threads reduces
/// latency and saves memory.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IPlazaClient : IDisposable
{
    /// <inheritdoc cref="ClientOptions.HttpClient" />
    HttpClient HttpClient { get; init; }

    /// <inheritdoc cref="ClientOptions.BaseUrl" />
    string BaseUrl { get; init; }

    /// <inheritdoc cref="ClientOptions.ResponseValidation" />
    bool ResponseValidation { get; init; }

    /// <inheritdoc cref="ClientOptions.MaxRetries" />
    int? MaxRetries { get; init; }

    /// <inheritdoc cref="ClientOptions.Timeout" />
    TimeSpan? Timeout { get; init; }

    /// <summary>
    /// Plaza API key
    /// </summary>
    string ApiKey { get; init; }

    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IPlazaClientWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPlazaClient WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IFeatureService Features { get; }

    IDatasetService Datasets { get; }

    IGeocodeService Geocode { get; }

    ISearchService Search { get; }

    IRoutingService Routing { get; }

    IElevationService Elevation { get; }

    IMapMatchService MapMatch { get; }

    IOptimizeService Optimize { get; }

    IQueryService Query { get; }

    ITileService Tiles { get; }
}

/// <summary>
/// A view of <see cref="IPlazaClient"/> that provides access to raw HTTP responses for each method.
/// </summary>
public interface IPlazaClientWithRawResponse : IDisposable
{
    /// <inheritdoc cref="ClientOptions.HttpClient" />
    HttpClient HttpClient { get; init; }

    /// <inheritdoc cref="ClientOptions.BaseUrl" />
    string BaseUrl { get; init; }

    /// <inheritdoc cref="ClientOptions.ResponseValidation" />
    bool ResponseValidation { get; init; }

    /// <inheritdoc cref="ClientOptions.MaxRetries" />
    int? MaxRetries { get; init; }

    /// <inheritdoc cref="ClientOptions.Timeout" />
    TimeSpan? Timeout { get; init; }

    /// <summary>
    /// Plaza API key
    /// </summary>
    string ApiKey { get; init; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPlazaClientWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IFeatureServiceWithRawResponse Features { get; }

    IDatasetServiceWithRawResponse Datasets { get; }

    IGeocodeServiceWithRawResponse Geocode { get; }

    ISearchServiceWithRawResponse Search { get; }

    IRoutingServiceWithRawResponse Routing { get; }

    IElevationServiceWithRawResponse Elevation { get; }

    IMapMatchServiceWithRawResponse MapMatch { get; }

    IOptimizeServiceWithRawResponse Optimize { get; }

    IQueryServiceWithRawResponse Query { get; }

    ITileServiceWithRawResponse Tiles { get; }

    /// <summary>
    /// Sends a request to the Plaza REST API.
    /// </summary>
    Task<HttpResponse> Execute<T>(
        HttpRequest<T> request,
        CancellationToken cancellationToken = default
    )
        where T : ParamsBase;
}

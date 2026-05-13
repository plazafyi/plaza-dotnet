using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Plaza.Core;
using Plaza.Exceptions;
using Plaza.Services;

namespace Plaza;

/// <inheritdoc/>
public sealed class PlazaClient : IPlazaClient
{
    readonly ClientOptions _options;

    /// <inheritdoc/>
    public HttpClient HttpClient
    {
        get { return this._options.HttpClient; }
        init { this._options.HttpClient = value; }
    }

    /// <inheritdoc/>
    public string BaseUrl
    {
        get { return this._options.BaseUrl; }
        init { this._options.BaseUrl = value; }
    }

    /// <inheritdoc/>
    public bool ResponseValidation
    {
        get { return this._options.ResponseValidation; }
        init { this._options.ResponseValidation = value; }
    }

    /// <inheritdoc/>
    public int? MaxRetries
    {
        get { return this._options.MaxRetries; }
        init { this._options.MaxRetries = value; }
    }

    /// <inheritdoc/>
    public TimeSpan? Timeout
    {
        get { return this._options.Timeout; }
        init { this._options.Timeout = value; }
    }

    /// <inheritdoc/>
    public string ApiKey
    {
        get { return this._options.ApiKey; }
        init { this._options.ApiKey = value; }
    }

    readonly Lazy<IPlazaClientWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IPlazaClientWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    /// <inheritdoc/>
    public IPlazaClient WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new PlazaClient(modifier(this._options));
    }

    readonly Lazy<IFeatureService> _features;
    public IFeatureService Features
    {
        get { return _features.Value; }
    }

    readonly Lazy<IDatasetService> _datasets;
    public IDatasetService Datasets
    {
        get { return _datasets.Value; }
    }

    readonly Lazy<IGeocodeService> _geocode;
    public IGeocodeService Geocode
    {
        get { return _geocode.Value; }
    }

    readonly Lazy<ISearchService> _search;
    public ISearchService Search
    {
        get { return _search.Value; }
    }

    readonly Lazy<IRoutingService> _routing;
    public IRoutingService Routing
    {
        get { return _routing.Value; }
    }

    readonly Lazy<IElevationService> _elevation;
    public IElevationService Elevation
    {
        get { return _elevation.Value; }
    }

    readonly Lazy<IMapMatchService> _mapMatch;
    public IMapMatchService MapMatch
    {
        get { return _mapMatch.Value; }
    }

    readonly Lazy<IOptimizeService> _optimize;
    public IOptimizeService Optimize
    {
        get { return _optimize.Value; }
    }

    readonly Lazy<IQueryService> _query;
    public IQueryService Query
    {
        get { return _query.Value; }
    }

    readonly Lazy<ITileService> _tiles;
    public ITileService Tiles
    {
        get { return _tiles.Value; }
    }

    public void Dispose() => this.HttpClient.Dispose();

    public PlazaClient()
    {
        _options = new();

        _withRawResponse = new(() => new PlazaClientWithRawResponse(this._options));
        _features = new(() => new FeatureService(this));
        _datasets = new(() => new DatasetService(this));
        _geocode = new(() => new GeocodeService(this));
        _search = new(() => new SearchService(this));
        _routing = new(() => new RoutingService(this));
        _elevation = new(() => new ElevationService(this));
        _mapMatch = new(() => new MapMatchService(this));
        _optimize = new(() => new OptimizeService(this));
        _query = new(() => new QueryService(this));
        _tiles = new(() => new TileService(this));
    }

    public PlazaClient(ClientOptions options)
        : this()
    {
        _options = options;
    }
}

/// <inheritdoc/>
public sealed class PlazaClientWithRawResponse : IPlazaClientWithRawResponse
{
#if NET
    static readonly Random Random = Random.Shared;
#else
    static readonly ThreadLocal<Random> _threadLocalRandom = new(() => new Random());

    static Random Random
    {
        get { return _threadLocalRandom.Value!; }
    }
#endif

    readonly ClientOptions _options;

    /// <inheritdoc/>
    public HttpClient HttpClient
    {
        get { return this._options.HttpClient; }
        init { this._options.HttpClient = value; }
    }

    /// <inheritdoc/>
    public string BaseUrl
    {
        get { return this._options.BaseUrl; }
        init { this._options.BaseUrl = value; }
    }

    /// <inheritdoc/>
    public bool ResponseValidation
    {
        get { return this._options.ResponseValidation; }
        init { this._options.ResponseValidation = value; }
    }

    /// <inheritdoc/>
    public int? MaxRetries
    {
        get { return this._options.MaxRetries; }
        init { this._options.MaxRetries = value; }
    }

    /// <inheritdoc/>
    public TimeSpan? Timeout
    {
        get { return this._options.Timeout; }
        init { this._options.Timeout = value; }
    }

    /// <inheritdoc/>
    public string ApiKey
    {
        get { return this._options.ApiKey; }
        init { this._options.ApiKey = value; }
    }

    /// <inheritdoc/>
    public IPlazaClientWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new PlazaClientWithRawResponse(modifier(this._options));
    }

    readonly Lazy<IFeatureServiceWithRawResponse> _features;
    public IFeatureServiceWithRawResponse Features
    {
        get { return _features.Value; }
    }

    readonly Lazy<IDatasetServiceWithRawResponse> _datasets;
    public IDatasetServiceWithRawResponse Datasets
    {
        get { return _datasets.Value; }
    }

    readonly Lazy<IGeocodeServiceWithRawResponse> _geocode;
    public IGeocodeServiceWithRawResponse Geocode
    {
        get { return _geocode.Value; }
    }

    readonly Lazy<ISearchServiceWithRawResponse> _search;
    public ISearchServiceWithRawResponse Search
    {
        get { return _search.Value; }
    }

    readonly Lazy<IRoutingServiceWithRawResponse> _routing;
    public IRoutingServiceWithRawResponse Routing
    {
        get { return _routing.Value; }
    }

    readonly Lazy<IElevationServiceWithRawResponse> _elevation;
    public IElevationServiceWithRawResponse Elevation
    {
        get { return _elevation.Value; }
    }

    readonly Lazy<IMapMatchServiceWithRawResponse> _mapMatch;
    public IMapMatchServiceWithRawResponse MapMatch
    {
        get { return _mapMatch.Value; }
    }

    readonly Lazy<IOptimizeServiceWithRawResponse> _optimize;
    public IOptimizeServiceWithRawResponse Optimize
    {
        get { return _optimize.Value; }
    }

    readonly Lazy<IQueryServiceWithRawResponse> _query;
    public IQueryServiceWithRawResponse Query
    {
        get { return _query.Value; }
    }

    readonly Lazy<ITileServiceWithRawResponse> _tiles;
    public ITileServiceWithRawResponse Tiles
    {
        get { return _tiles.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse> Execute<T>(
        HttpRequest<T> request,
        CancellationToken cancellationToken = default
    )
        where T : ParamsBase
    {
        var maxRetries = this.MaxRetries ?? ClientOptions.DefaultMaxRetries;
        var retries = 0;
        while (true)
        {
            HttpResponse? response = null;
            try
            {
                response = await ExecuteOnce(request, retries, cancellationToken)
                    .ConfigureAwait(false);
            }
            catch (Exception e)
            {
                if (++retries > maxRetries || !ShouldRetry(e))
                {
                    throw;
                }
            }

            if (response != null && (++retries > maxRetries || !ShouldRetry(response)))
            {
                if (response.IsSuccessStatusCode)
                {
                    return response;
                }

                try
                {
                    throw PlazaExceptionFactory.CreateApiException(
                        response.StatusCode,
                        await response.ReadAsString(cancellationToken).ConfigureAwait(false)
                    );
                }
                catch (HttpRequestException e)
                {
                    throw new PlazaIOException("I/O Exception", e);
                }
                finally
                {
                    response.Dispose();
                }
            }

            var backoff = ComputeRetryBackoff(retries, response);
            response?.Dispose();
            await Task.Delay(backoff, cancellationToken).ConfigureAwait(false);
        }
    }

    async Task<HttpResponse> ExecuteOnce<T>(
        HttpRequest<T> request,
        int retryCount,
        CancellationToken cancellationToken = default
    )
        where T : ParamsBase
    {
        using HttpRequestMessage requestMessage = new(
            request.Method,
            request.Params.Url(this._options)
        )
        {
            Content = request.Params.BodyContent(),
        };
        request.Params.AddHeadersToRequest(requestMessage, this._options);
        if (!requestMessage.Headers.Contains("x-stainless-retry-count"))
        {
            requestMessage.Headers.Add("x-stainless-retry-count", retryCount.ToString());
        }
        using CancellationTokenSource timeoutCts = new(
            this.Timeout ?? ClientOptions.DefaultTimeout
        );
        using var cts = CancellationTokenSource.CreateLinkedTokenSource(
            timeoutCts.Token,
            cancellationToken
        );
        HttpResponseMessage responseMessage;
        try
        {
            responseMessage = await this
                .HttpClient.SendAsync(
                    requestMessage,
                    HttpCompletionOption.ResponseHeadersRead,
                    cts.Token
                )
                .ConfigureAwait(false);
        }
        catch (HttpRequestException e)
        {
            throw new PlazaIOException("I/O exception", e);
        }
        return new() { RawMessage = responseMessage, CancellationToken = cts.Token };
    }

    static TimeSpan ComputeRetryBackoff(int retries, HttpResponse? response)
    {
        TimeSpan? apiBackoff = ParseRetryAfterMsHeader(response) ?? ParseRetryAfterHeader(response);
        if (
            apiBackoff != null
            && apiBackoff > TimeSpan.Zero
            && apiBackoff < TimeSpan.FromMinutes(1)
        )
        {
            // If the API asks us to wait a certain amount of time (and it's a reasonable amount), then just
            // do what it says.
            return (TimeSpan)apiBackoff;
        }

        // Apply exponential backoff, but not more than the max.
        var backoffSeconds = Math.Min(0.5 * Math.Pow(2.0, retries - 1), 8.0);
        var jitter = 1.0 - 0.25 * Random.NextDouble();
        return TimeSpan.FromSeconds(backoffSeconds * jitter);
    }

    static TimeSpan? ParseRetryAfterMsHeader(HttpResponse? response)
    {
        IEnumerable<string>? headerValues = null;
        response?.TryGetHeaderValues("Retry-After-Ms", out headerValues);
        var headerValue = headerValues == null ? null : Enumerable.FirstOrDefault(headerValues);
        if (headerValue == null)
        {
            return null;
        }

        if (float.TryParse(headerValue, out var retryAfterMs))
        {
            return TimeSpan.FromMilliseconds(retryAfterMs);
        }

        return null;
    }

    static TimeSpan? ParseRetryAfterHeader(HttpResponse? response)
    {
        IEnumerable<string>? headerValues = null;
        response?.TryGetHeaderValues("Retry-After", out headerValues);
        var headerValue = headerValues == null ? null : Enumerable.FirstOrDefault(headerValues);
        if (headerValue == null)
        {
            return null;
        }

        if (float.TryParse(headerValue, out var retryAfterSeconds))
        {
            return TimeSpan.FromSeconds(retryAfterSeconds);
        }
        else if (DateTimeOffset.TryParse(headerValue, out var retryAfterDate))
        {
            return retryAfterDate - DateTimeOffset.Now;
        }

        return null;
    }

    static bool ShouldRetry(HttpResponse response)
    {
        if (
            response.TryGetHeaderValues("X-Should-Retry", out var headerValues)
            && bool.TryParse(Enumerable.FirstOrDefault(headerValues), out var shouldRetry)
        )
        {
            // If the server explicitly says whether to retry, then we obey.
            return shouldRetry;
        }

        return (int)response.StatusCode switch
        {
            // Retry on request timeouts
            408
            or
            // Retry on lock timeouts
            409
            or
            // Retry on rate limits
            429
            or
            // Retry internal errors
            >= 500 => true,
            _ => false,
        };
    }

    static bool ShouldRetry(Exception e)
    {
        return e is IOException || e is PlazaIOException;
    }

    public void Dispose() => this.HttpClient.Dispose();

    public PlazaClientWithRawResponse()
    {
        _options = new();

        _features = new(() => new FeatureServiceWithRawResponse(this));
        _datasets = new(() => new DatasetServiceWithRawResponse(this));
        _geocode = new(() => new GeocodeServiceWithRawResponse(this));
        _search = new(() => new SearchServiceWithRawResponse(this));
        _routing = new(() => new RoutingServiceWithRawResponse(this));
        _elevation = new(() => new ElevationServiceWithRawResponse(this));
        _mapMatch = new(() => new MapMatchServiceWithRawResponse(this));
        _optimize = new(() => new OptimizeServiceWithRawResponse(this));
        _query = new(() => new QueryServiceWithRawResponse(this));
        _tiles = new(() => new TileServiceWithRawResponse(this));
    }

    public PlazaClientWithRawResponse(ClientOptions options)
        : this()
    {
        _options = options;
    }
}

using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Plaza.Core;
using Plaza.Exceptions;
using Plaza.Models.Tiles;

namespace Plaza.Services;

/// <inheritdoc/>
public sealed class TileService : ITileService
{
    readonly Lazy<ITileServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ITileServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IPlazaClient _client;

    /// <inheritdoc/>
    public ITileService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new TileService(this._client.WithOptions(modifier));
    }

    public TileService(IPlazaClient client)
    {
        _client = client;

        _withRawResponse = new(() => new TileServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Get(
        TileGetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Get(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Get(
        long y,
        TileGetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Get(parameters with { Y = y }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class TileServiceWithRawResponse : ITileServiceWithRawResponse
{
    readonly IPlazaClientWithRawResponse _client;

    /// <inheritdoc/>
    public ITileServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new TileServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public TileServiceWithRawResponse(IPlazaClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Get(
        TileGetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Y == null)
        {
            throw new PlazaInvalidDataException("'parameters.Y' cannot be null");
        }

        HttpRequest<TileGetParams> request = new() { Method = HttpMethod.Get, Params = parameters };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Get(
        long y,
        TileGetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Get(parameters with { Y = y }, cancellationToken);
    }
}

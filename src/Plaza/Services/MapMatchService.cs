using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Plaza.Core;
using Plaza.Models.MapMatch;

namespace Plaza.Services;

/// <inheritdoc/>
public sealed class MapMatchService : IMapMatchService
{
    readonly Lazy<IMapMatchServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IMapMatchServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IPlazaClient _client;

    /// <inheritdoc/>
    public IMapMatchService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new MapMatchService(this._client.WithOptions(modifier));
    }

    public MapMatchService(IPlazaClient client)
    {
        _client = client;

        _withRawResponse = new(() => new MapMatchServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<MapMatchResult> Match(
        MapMatchMatchParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Match(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class MapMatchServiceWithRawResponse : IMapMatchServiceWithRawResponse
{
    readonly IPlazaClientWithRawResponse _client;

    /// <inheritdoc/>
    public IMapMatchServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new MapMatchServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public MapMatchServiceWithRawResponse(IPlazaClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MapMatchResult>> Match(
        MapMatchMatchParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<MapMatchMatchParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var mapMatchResult = await response
                    .Deserialize<MapMatchResult>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    mapMatchResult.Validate();
                }
                return mapMatchResult;
            }
        );
    }
}

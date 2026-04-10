using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Plaza.Core;
using Plaza.Models.Elevation;

namespace Plaza.Services;

/// <inheritdoc/>
public sealed class ElevationService : IElevationService
{
    readonly Lazy<IElevationServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IElevationServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IPlazaClient _client;

    /// <inheritdoc/>
    public IElevationService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ElevationService(this._client.WithOptions(modifier));
    }

    public ElevationService(IPlazaClient client)
    {
        _client = client;

        _withRawResponse = new(() => new ElevationServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<ElevationLookupResult> Lookup(
        ElevationLookupParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Lookup(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<ElevationProfileResult> Profile(
        ElevationProfileParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Profile(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class ElevationServiceWithRawResponse : IElevationServiceWithRawResponse
{
    readonly IPlazaClientWithRawResponse _client;

    /// <inheritdoc/>
    public IElevationServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ElevationServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ElevationServiceWithRawResponse(IPlazaClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ElevationLookupResult>> Lookup(
        ElevationLookupParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ElevationLookupParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var elevationLookupResult = await response
                    .Deserialize<ElevationLookupResult>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    elevationLookupResult.Validate();
                }
                return elevationLookupResult;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ElevationProfileResult>> Profile(
        ElevationProfileParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ElevationProfileParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var elevationProfileResult = await response
                    .Deserialize<ElevationProfileResult>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    elevationProfileResult.Validate();
                }
                return elevationProfileResult;
            }
        );
    }
}

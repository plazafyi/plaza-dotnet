using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Plaza.Core;
using Plaza.Models.Routing;

namespace Plaza.Services;

/// <inheritdoc/>
public sealed class RoutingService : IRoutingService
{
    readonly Lazy<IRoutingServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IRoutingServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IPlazaClient _client;

    /// <inheritdoc/>
    public IRoutingService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new RoutingService(this._client.WithOptions(modifier));
    }

    public RoutingService(IPlazaClient client)
    {
        _client = client;

        _withRawResponse = new(() => new RoutingServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<RoutingIsochroneResponse> Isochrone(
        RoutingIsochroneParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Isochrone(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Dictionary<string, JsonElement>> Matrix(
        RoutingMatrixParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Matrix(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<NearestResult> Nearest(
        RoutingNearestParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Nearest(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<RouteResult> Route(
        RoutingRouteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Route(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class RoutingServiceWithRawResponse : IRoutingServiceWithRawResponse
{
    readonly IPlazaClientWithRawResponse _client;

    /// <inheritdoc/>
    public IRoutingServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new RoutingServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public RoutingServiceWithRawResponse(IPlazaClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RoutingIsochroneResponse>> Isochrone(
        RoutingIsochroneParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<RoutingIsochroneParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<RoutingIsochroneResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Dictionary<string, JsonElement>>> Matrix(
        RoutingMatrixParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<RoutingMatrixParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                return await response
                    .Deserialize<Dictionary<string, JsonElement>>(token)
                    .ConfigureAwait(false);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<NearestResult>> Nearest(
        RoutingNearestParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<RoutingNearestParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var nearestResult = await response
                    .Deserialize<NearestResult>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    nearestResult.Validate();
                }
                return nearestResult;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RouteResult>> Route(
        RoutingRouteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<RoutingRouteParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var routeResult = await response
                    .Deserialize<RouteResult>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    routeResult.Validate();
                }
                return routeResult;
            }
        );
    }
}

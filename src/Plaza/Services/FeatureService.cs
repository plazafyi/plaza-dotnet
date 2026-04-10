using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Plaza.Core;
using Plaza.Exceptions;
using Plaza.Models;
using Plaza.Models.Features;

namespace Plaza.Services;

/// <inheritdoc/>
public sealed class FeatureService : IFeatureService
{
    readonly Lazy<IFeatureServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IFeatureServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IPlazaClient _client;

    /// <inheritdoc/>
    public IFeatureService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new FeatureService(this._client.WithOptions(modifier));
    }

    public FeatureService(IPlazaClient client)
    {
        _client = client;

        _withRawResponse = new(() => new FeatureServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<GeoJsonFeature> Retrieve(
        FeatureRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<GeoJsonFeature> Retrieve(
        long id,
        FeatureRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<FeatureCollection> Batch(
        FeatureBatchParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Batch(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<FeatureCollection> Query(
        FeatureQueryParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Query(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class FeatureServiceWithRawResponse : IFeatureServiceWithRawResponse
{
    readonly IPlazaClientWithRawResponse _client;

    /// <inheritdoc/>
    public IFeatureServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new FeatureServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public FeatureServiceWithRawResponse(IPlazaClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<GeoJsonFeature>> Retrieve(
        FeatureRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new PlazaInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<FeatureRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var geoJsonFeature = await response
                    .Deserialize<GeoJsonFeature>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    geoJsonFeature.Validate();
                }
                return geoJsonFeature;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<GeoJsonFeature>> Retrieve(
        long id,
        FeatureRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<FeatureCollection>> Batch(
        FeatureBatchParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<FeatureBatchParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var featureCollection = await response
                    .Deserialize<FeatureCollection>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    featureCollection.Validate();
                }
                return featureCollection;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<FeatureCollection>> Query(
        FeatureQueryParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<FeatureQueryParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var featureCollection = await response
                    .Deserialize<FeatureCollection>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    featureCollection.Validate();
                }
                return featureCollection;
            }
        );
    }
}

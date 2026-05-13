using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Plaza.Core;
using Plaza.Models.Geocode;

namespace Plaza.Services;

/// <inheritdoc/>
public sealed class GeocodeService : IGeocodeService
{
    readonly Lazy<IGeocodeServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IGeocodeServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IPlazaClient _client;

    /// <inheritdoc/>
    public IGeocodeService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new GeocodeService(this._client.WithOptions(modifier));
    }

    public GeocodeService(IPlazaClient client)
    {
        _client = client;

        _withRawResponse = new(() => new GeocodeServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<AutocompleteResult> Autocomplete(
        GeocodeAutocompleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Autocomplete(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<GeocodeBatchResponse> Batch(
        GeocodeBatchParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Batch(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<GeocodeResult> Forward(
        GeocodeForwardParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Forward(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<ReverseGeocodeResult> Reverse(
        GeocodeReverseParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Reverse(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class GeocodeServiceWithRawResponse : IGeocodeServiceWithRawResponse
{
    readonly IPlazaClientWithRawResponse _client;

    /// <inheritdoc/>
    public IGeocodeServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new GeocodeServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public GeocodeServiceWithRawResponse(IPlazaClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AutocompleteResult>> Autocomplete(
        GeocodeAutocompleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<GeocodeAutocompleteParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var autocompleteResult = await response
                    .Deserialize<AutocompleteResult>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    autocompleteResult.Validate();
                }
                return autocompleteResult;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<GeocodeBatchResponse>> Batch(
        GeocodeBatchParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<GeocodeBatchParams> request = new()
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
                    .Deserialize<GeocodeBatchResponse>(token)
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
    public async Task<HttpResponse<GeocodeResult>> Forward(
        GeocodeForwardParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<GeocodeForwardParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var geocodeResult = await response
                    .Deserialize<GeocodeResult>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    geocodeResult.Validate();
                }
                return geocodeResult;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ReverseGeocodeResult>> Reverse(
        GeocodeReverseParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<GeocodeReverseParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var reverseGeocodeResult = await response
                    .Deserialize<ReverseGeocodeResult>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    reverseGeocodeResult.Validate();
                }
                return reverseGeocodeResult;
            }
        );
    }
}

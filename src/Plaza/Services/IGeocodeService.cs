using System;
using System.Threading;
using System.Threading.Tasks;
using Plaza.Core;
using Plaza.Models.Geocode;

namespace Plaza.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IGeocodeService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IGeocodeServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IGeocodeService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Autocomplete a partial address
    /// </summary>
    Task<AutocompleteResult> Autocomplete(
        GeocodeAutocompleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Batch geocode multiple addresses
    /// </summary>
    Task<GeocodeBatchResponse> Batch(
        GeocodeBatchParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Forward geocode an address
    /// </summary>
    Task<GeocodeResult> Forward(
        GeocodeForwardParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Reverse geocode a coordinate
    /// </summary>
    Task<ReverseGeocodeResult> Reverse(
        GeocodeReverseParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IGeocodeService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IGeocodeServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IGeocodeServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v1/geocode/autocomplete</c>, but is otherwise the
    /// same as <see cref="IGeocodeService.Autocomplete(GeocodeAutocompleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AutocompleteResult>> Autocomplete(
        GeocodeAutocompleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v1/geocode/batch</c>, but is otherwise the
    /// same as <see cref="IGeocodeService.Batch(GeocodeBatchParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<GeocodeBatchResponse>> Batch(
        GeocodeBatchParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v1/geocode</c>, but is otherwise the
    /// same as <see cref="IGeocodeService.Forward(GeocodeForwardParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<GeocodeResult>> Forward(
        GeocodeForwardParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v1/geocode/reverse</c>, but is otherwise the
    /// same as <see cref="IGeocodeService.Reverse(GeocodeReverseParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ReverseGeocodeResult>> Reverse(
        GeocodeReverseParams parameters,
        CancellationToken cancellationToken = default
    );
}

using System;
using System.Threading;
using System.Threading.Tasks;
using Plaza.Core;
using Plaza.Models;
using Plaza.Models.Features;

namespace Plaza.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IFeatureService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IFeatureServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IFeatureService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get feature by type and ID
    /// </summary>
    Task<GeoJsonFeature> Retrieve(
        FeatureRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(FeatureRetrieveParams, CancellationToken)"/>
    Task<GeoJsonFeature> Retrieve(
        long id,
        FeatureRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Fetch multiple features by type and ID
    /// </summary>
    Task<FeatureCollection> Batch(
        FeatureBatchParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Query features by spatial predicate, bounding box, or H3 cell
    /// </summary>
    Task<FeatureCollection> Query(
        FeatureQueryParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IFeatureService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IFeatureServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IFeatureServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v1/features/{type}/{id}</c>, but is otherwise the
    /// same as <see cref="IFeatureService.Retrieve(FeatureRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<GeoJsonFeature>> Retrieve(
        FeatureRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(FeatureRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<GeoJsonFeature>> Retrieve(
        long id,
        FeatureRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v1/features/batch</c>, but is otherwise the
    /// same as <see cref="IFeatureService.Batch(FeatureBatchParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<FeatureCollection>> Batch(
        FeatureBatchParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v1/features</c>, but is otherwise the
    /// same as <see cref="IFeatureService.Query(FeatureQueryParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<FeatureCollection>> Query(
        FeatureQueryParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

using System;
using System.Threading;
using System.Threading.Tasks;
using Plaza.Core;
using Plaza.Models.Elevation;

namespace Plaza.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IElevationService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IElevationServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IElevationService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Look up elevation at one or more points
    /// </summary>
    Task<ElevationLookupResult> Lookup(
        ElevationLookupParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Elevation profile along coordinates
    /// </summary>
    Task<ElevationProfileResult> Profile(
        ElevationProfileParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IElevationService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IElevationServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IElevationServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v1/elevation</c>, but is otherwise the
    /// same as <see cref="IElevationService.Lookup(ElevationLookupParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ElevationLookupResult>> Lookup(
        ElevationLookupParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v1/elevation/profile</c>, but is otherwise the
    /// same as <see cref="IElevationService.Profile(ElevationProfileParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ElevationProfileResult>> Profile(
        ElevationProfileParams parameters,
        CancellationToken cancellationToken = default
    );
}

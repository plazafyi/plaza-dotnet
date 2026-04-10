using System;
using System.Threading;
using System.Threading.Tasks;
using Plaza.Core;
using Plaza.Models.MapMatch;

namespace Plaza.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IMapMatchService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IMapMatchServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMapMatchService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Match GPS coordinates to the road network
    /// </summary>
    Task<MapMatchResult> Match(
        MapMatchMatchParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IMapMatchService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IMapMatchServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMapMatchServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v1/map-match</c>, but is otherwise the
    /// same as <see cref="IMapMatchService.Match(MapMatchMatchParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<MapMatchResult>> Match(
        MapMatchMatchParams parameters,
        CancellationToken cancellationToken = default
    );
}

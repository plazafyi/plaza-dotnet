using System;
using System.Threading;
using System.Threading.Tasks;
using Plaza.Core;
using Plaza.Models.Tiles;

namespace Plaza.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ITileService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ITileServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITileService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get a Mapbox Vector Tile
    ///
    /// <para>It's the caller's responsibility to dispose the returned response.</para>
    /// </summary>
    Task<HttpResponse> Get(TileGetParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Get(TileGetParams, CancellationToken)"/>
    Task<HttpResponse> Get(
        long y,
        TileGetParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ITileService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ITileServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITileServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v1/tiles/{z}/{x}/{y}</c>, but is otherwise the
    /// same as <see cref="ITileService.Get(TileGetParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Get(TileGetParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Get(TileGetParams, CancellationToken)"/>
    Task<HttpResponse> Get(
        long y,
        TileGetParams parameters,
        CancellationToken cancellationToken = default
    );
}

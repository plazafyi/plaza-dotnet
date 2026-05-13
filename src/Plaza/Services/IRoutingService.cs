using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Plaza.Core;
using Plaza.Models.Routing;

namespace Plaza.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IRoutingService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IRoutingServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRoutingService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Calculate an isochrone from a point
    /// </summary>
    Task<RoutingIsochroneResponse> Isochrone(
        RoutingIsochroneParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Calculate a distance matrix between points
    /// </summary>
    Task<Dictionary<string, JsonElement>> Matrix(
        RoutingMatrixParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Snap a coordinate to the nearest road
    /// </summary>
    Task<NearestResult> Nearest(
        RoutingNearestParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Calculate a route between two points
    /// </summary>
    Task<RouteResult> Route(
        RoutingRouteParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IRoutingService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IRoutingServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRoutingServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v1/isochrone</c>, but is otherwise the
    /// same as <see cref="IRoutingService.Isochrone(RoutingIsochroneParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<RoutingIsochroneResponse>> Isochrone(
        RoutingIsochroneParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v1/matrix</c>, but is otherwise the
    /// same as <see cref="IRoutingService.Matrix(RoutingMatrixParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Dictionary<string, JsonElement>>> Matrix(
        RoutingMatrixParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v1/nearest</c>, but is otherwise the
    /// same as <see cref="IRoutingService.Nearest(RoutingNearestParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<NearestResult>> Nearest(
        RoutingNearestParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v1/route</c>, but is otherwise the
    /// same as <see cref="IRoutingService.Route(RoutingRouteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<RouteResult>> Route(
        RoutingRouteParams parameters,
        CancellationToken cancellationToken = default
    );
}

using System;
using System.Threading;
using System.Threading.Tasks;
using Plaza.Core;
using Plaza.Models;
using Plaza.Models.Search;

namespace Plaza.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ISearchService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ISearchServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISearchService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Search OSM features by name
    /// </summary>
    Task<FeatureCollection> Query(
        SearchQueryParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ISearchService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ISearchServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISearchServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v1/search</c>, but is otherwise the
    /// same as <see cref="ISearchService.Query(SearchQueryParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<FeatureCollection>> Query(
        SearchQueryParams parameters,
        CancellationToken cancellationToken = default
    );
}

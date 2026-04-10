using System;
using System.Threading;
using System.Threading.Tasks;
using Plaza.Core;
using Plaza.Models;
using Plaza.Models.Query;

namespace Plaza.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IQueryService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IQueryServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IQueryService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Execute a PlazaQL query
    /// </summary>
    Task<FeatureCollection> Execute(
        QueryExecuteParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IQueryService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IQueryServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IQueryServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v1/query</c>, but is otherwise the
    /// same as <see cref="IQueryService.Execute(QueryExecuteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<FeatureCollection>> Execute(
        QueryExecuteParams parameters,
        CancellationToken cancellationToken = default
    );
}

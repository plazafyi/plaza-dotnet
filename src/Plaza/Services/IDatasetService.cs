using System;
using System.Threading;
using System.Threading.Tasks;
using Plaza.Core;
using Plaza.Models.Datasets;

namespace Plaza.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IDatasetService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IDatasetServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IDatasetService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create a new dataset
    /// </summary>
    Task<Dataset> Create(
        DatasetCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get dataset by ID
    /// </summary>
    Task<Dataset> Retrieve(
        DatasetRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(DatasetRetrieveParams, CancellationToken)"/>
    Task<Dataset> Retrieve(
        string id,
        DatasetRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List datasets
    /// </summary>
    Task<DatasetList> List(
        DatasetListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a dataset
    /// </summary>
    Task Delete(DatasetDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(DatasetDeleteParams, CancellationToken)"/>
    Task Delete(
        string id,
        DatasetDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IDatasetService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IDatasetServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IDatasetServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v1/datasets</c>, but is otherwise the
    /// same as <see cref="IDatasetService.Create(DatasetCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Dataset>> Create(
        DatasetCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v1/datasets/{id}</c>, but is otherwise the
    /// same as <see cref="IDatasetService.Retrieve(DatasetRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Dataset>> Retrieve(
        DatasetRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(DatasetRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<Dataset>> Retrieve(
        string id,
        DatasetRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v1/datasets</c>, but is otherwise the
    /// same as <see cref="IDatasetService.List(DatasetListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<DatasetList>> List(
        DatasetListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /api/v1/datasets/{id}</c>, but is otherwise the
    /// same as <see cref="IDatasetService.Delete(DatasetDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        DatasetDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(DatasetDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string id,
        DatasetDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

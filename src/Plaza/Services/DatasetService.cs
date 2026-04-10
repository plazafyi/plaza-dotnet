using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Plaza.Core;
using Plaza.Exceptions;
using Plaza.Models.Datasets;

namespace Plaza.Services;

/// <inheritdoc/>
public sealed class DatasetService : IDatasetService
{
    readonly Lazy<IDatasetServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IDatasetServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IPlazaClient _client;

    /// <inheritdoc/>
    public IDatasetService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new DatasetService(this._client.WithOptions(modifier));
    }

    public DatasetService(IPlazaClient client)
    {
        _client = client;

        _withRawResponse = new(() => new DatasetServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<Dataset> Create(
        DatasetCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Dataset> Retrieve(
        DatasetRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Dataset> Retrieve(
        string id,
        DatasetRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<DatasetList> List(
        DatasetListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Delete(
        DatasetDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string id,
        DatasetDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with { ID = id }, cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class DatasetServiceWithRawResponse : IDatasetServiceWithRawResponse
{
    readonly IPlazaClientWithRawResponse _client;

    /// <inheritdoc/>
    public IDatasetServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new DatasetServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public DatasetServiceWithRawResponse(IPlazaClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Dataset>> Create(
        DatasetCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<DatasetCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var dataset = await response.Deserialize<Dataset>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    dataset.Validate();
                }
                return dataset;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Dataset>> Retrieve(
        DatasetRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new PlazaInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<DatasetRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var dataset = await response.Deserialize<Dataset>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    dataset.Validate();
                }
                return dataset;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Dataset>> Retrieve(
        string id,
        DatasetRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<DatasetList>> List(
        DatasetListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<DatasetListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var datasetList = await response
                    .Deserialize<DatasetList>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    datasetList.Validate();
                }
                return datasetList;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        DatasetDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new PlazaInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<DatasetDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string id,
        DatasetDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { ID = id }, cancellationToken);
    }
}

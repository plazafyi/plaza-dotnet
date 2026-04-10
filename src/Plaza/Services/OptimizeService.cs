using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Plaza.Core;
using Plaza.Exceptions;
using Plaza.Models.Optimize;

namespace Plaza.Services;

/// <inheritdoc/>
public sealed class OptimizeService : IOptimizeService
{
    readonly Lazy<IOptimizeServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IOptimizeServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IPlazaClient _client;

    /// <inheritdoc/>
    public IOptimizeService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new OptimizeService(this._client.WithOptions(modifier));
    }

    public OptimizeService(IPlazaClient client)
    {
        _client = client;

        _withRawResponse = new(() => new OptimizeServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<OptimizeResult> Create(
        OptimizeCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<OptimizeJobStatus> Retrieve(
        OptimizeRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<OptimizeJobStatus> Retrieve(
        string jobID,
        OptimizeRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { JobID = jobID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class OptimizeServiceWithRawResponse : IOptimizeServiceWithRawResponse
{
    readonly IPlazaClientWithRawResponse _client;

    /// <inheritdoc/>
    public IOptimizeServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new OptimizeServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public OptimizeServiceWithRawResponse(IPlazaClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<OptimizeResult>> Create(
        OptimizeCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<OptimizeCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var optimizeResult = await response
                    .Deserialize<OptimizeResult>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    optimizeResult.Validate();
                }
                return optimizeResult;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<OptimizeJobStatus>> Retrieve(
        OptimizeRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.JobID == null)
        {
            throw new PlazaInvalidDataException("'parameters.JobID' cannot be null");
        }

        HttpRequest<OptimizeRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var optimizeJobStatus = await response
                    .Deserialize<OptimizeJobStatus>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    optimizeJobStatus.Validate();
                }
                return optimizeJobStatus;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<OptimizeJobStatus>> Retrieve(
        string jobID,
        OptimizeRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { JobID = jobID }, cancellationToken);
    }
}

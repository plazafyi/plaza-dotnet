using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Plaza.Core;
using Plaza.Models;
using Plaza.Models.Query;

namespace Plaza.Services;

/// <inheritdoc/>
public sealed class QueryService : IQueryService
{
    readonly Lazy<IQueryServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IQueryServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IPlazaClient _client;

    /// <inheritdoc/>
    public IQueryService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new QueryService(this._client.WithOptions(modifier));
    }

    public QueryService(IPlazaClient client)
    {
        _client = client;

        _withRawResponse = new(() => new QueryServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<FeatureCollection> Execute(
        QueryExecuteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Execute(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class QueryServiceWithRawResponse : IQueryServiceWithRawResponse
{
    readonly IPlazaClientWithRawResponse _client;

    /// <inheritdoc/>
    public IQueryServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new QueryServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public QueryServiceWithRawResponse(IPlazaClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<FeatureCollection>> Execute(
        QueryExecuteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<QueryExecuteParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var featureCollection = await response
                    .Deserialize<FeatureCollection>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    featureCollection.Validate();
                }
                return featureCollection;
            }
        );
    }
}

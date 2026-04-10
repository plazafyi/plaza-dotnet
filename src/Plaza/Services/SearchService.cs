using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Plaza.Core;
using Plaza.Models;
using Plaza.Models.Search;

namespace Plaza.Services;

/// <inheritdoc/>
public sealed class SearchService : ISearchService
{
    readonly Lazy<ISearchServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ISearchServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IPlazaClient _client;

    /// <inheritdoc/>
    public ISearchService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SearchService(this._client.WithOptions(modifier));
    }

    public SearchService(IPlazaClient client)
    {
        _client = client;

        _withRawResponse = new(() => new SearchServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<FeatureCollection> Query(
        SearchQueryParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Query(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class SearchServiceWithRawResponse : ISearchServiceWithRawResponse
{
    readonly IPlazaClientWithRawResponse _client;

    /// <inheritdoc/>
    public ISearchServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SearchServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public SearchServiceWithRawResponse(IPlazaClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<FeatureCollection>> Query(
        SearchQueryParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<SearchQueryParams> request = new()
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

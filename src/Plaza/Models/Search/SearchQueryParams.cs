using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Plaza.Core;

namespace Plaza.Models.Search;

/// <summary>
/// Search OSM features by name
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class SearchQueryParams : ParamsBase
{
    /// <summary>
    /// Search query string
    /// </summary>
    public required string Q
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNotNullClass<string>("q");
        }
        init { this._rawQueryData.Set("q", value); }
    }

    /// <summary>
    /// Cursor for pagination
    /// </summary>
    public string? Cursor
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("cursor");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("cursor", value);
        }
    }

    /// <summary>
    /// Response format: json (default), geojson, csv, ndjson
    /// </summary>
    public string? Format
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("format");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("format", value);
        }
    }

    /// <summary>
    /// Maximum results (default 25, max 100)
    /// </summary>
    public long? Limit
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("limit");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("limit", value);
        }
    }

    /// <summary>
    /// Comma-separated property fields to include
    /// </summary>
    public string? OutputFields
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("output[fields]");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("output[fields]", value);
        }
    }

    /// <summary>
    /// Extra computed fields: bbox, distance, center
    /// </summary>
    public string? OutputInclude
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("output[include]");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("output[include]", value);
        }
    }

    /// <summary>
    /// Coordinate decimal precision (1-15, default 7)
    /// </summary>
    public long? OutputPrecision
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("output[precision]");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("output[precision]", value);
        }
    }

    /// <summary>
    /// Sort by: distance, name, osm_id
    /// </summary>
    public string? OutputSort
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("output[sort]");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("output[sort]", value);
        }
    }

    public SearchQueryParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SearchQueryParams(SearchQueryParams searchQueryParams)
        : base(searchQueryParams) { }
#pragma warning restore CS8618

    public SearchQueryParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SearchQueryParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static SearchQueryParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(SearchQueryParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/api/v1/search")
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

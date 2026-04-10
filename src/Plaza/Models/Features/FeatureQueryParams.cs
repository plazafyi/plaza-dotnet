using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Plaza.Core;

namespace Plaza.Models.Features;

/// <summary>
/// Query features by spatial predicate, bounding box, or H3 cell
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class FeatureQueryParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
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
    /// Response format. json (default) returns paginated GeoJSON. geojson/csv/ndjson
    /// stream via chunked transfer encoding.
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
    /// Legacy shorthand. H3 cell index. Use spatial predicates instead.
    /// </summary>
    public string? H3
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("h3");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("h3", value);
        }
    }

    /// <summary>
    /// Maximum results (default 100, max 10000)
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
    /// Element types (comma-separated: node,way,relation)
    /// </summary>
    public string? Type
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("type", value);
        }
    }

    /// <summary>
    /// GeoJSON Geometry object per RFC 7946. Discriminated union — the `type` field
    /// determines the coordinate structure.
    /// </summary>
    public Geometry? Around
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Geometry>("around");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("around", value);
        }
    }

    /// <summary>
    /// GeoJSON Geometry object per RFC 7946. Discriminated union — the `type` field
    /// determines the coordinate structure.
    /// </summary>
    public Geometry? Contains
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Geometry>("contains");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("contains", value);
        }
    }

    /// <summary>
    /// GeoJSON Geometry object per RFC 7946. Discriminated union — the `type` field
    /// determines the coordinate structure.
    /// </summary>
    public Geometry? Crosses
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Geometry>("crosses");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("crosses", value);
        }
    }

    /// <summary>
    /// GeoJSON Geometry object per RFC 7946. Discriminated union — the `type` field
    /// determines the coordinate structure.
    /// </summary>
    public Geometry? Intersects
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Geometry>("intersects");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("intersects", value);
        }
    }

    /// <summary>
    /// GeoJSON Geometry object per RFC 7946. Discriminated union — the `type` field
    /// determines the coordinate structure.
    /// </summary>
    public Geometry? NotContains
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Geometry>("not_contains");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("not_contains", value);
        }
    }

    /// <summary>
    /// GeoJSON Geometry object per RFC 7946. Discriminated union — the `type` field
    /// determines the coordinate structure.
    /// </summary>
    public Geometry? NotIntersects
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Geometry>("not_intersects");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("not_intersects", value);
        }
    }

    /// <summary>
    /// GeoJSON Geometry object per RFC 7946. Discriminated union — the `type` field
    /// determines the coordinate structure.
    /// </summary>
    public Geometry? NotWithin
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Geometry>("not_within");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("not_within", value);
        }
    }

    /// <summary>
    /// Search radius in meters. Required for `around`, optional buffer for other predicates.
    /// </summary>
    public double? Radius
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<double>("radius");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("radius", value);
        }
    }

    /// <summary>
    /// GeoJSON Geometry object per RFC 7946. Discriminated union — the `type` field
    /// determines the coordinate structure.
    /// </summary>
    public Geometry? Touches
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Geometry>("touches");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("touches", value);
        }
    }

    /// <summary>
    /// GeoJSON Geometry object per RFC 7946. Discriminated union — the `type` field
    /// determines the coordinate structure.
    /// </summary>
    public Geometry? Within
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Geometry>("within");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("within", value);
        }
    }

    public FeatureQueryParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FeatureQueryParams(FeatureQueryParams featureQueryParams)
        : base(featureQueryParams)
    {
        this._rawBodyData = new(featureQueryParams._rawBodyData);
    }
#pragma warning restore CS8618

    public FeatureQueryParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FeatureQueryParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static FeatureQueryParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
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
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(FeatureQueryParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/api/v1/features")
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
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

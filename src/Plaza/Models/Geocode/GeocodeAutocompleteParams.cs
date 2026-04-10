using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Plaza.Core;

namespace Plaza.Models.Geocode;

/// <summary>
/// Autocomplete a partial address
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class GeocodeAutocompleteParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Partial address or place name input
    /// </summary>
    public required string Q
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("q");
        }
        init { this._rawBodyData.Set("q", value); }
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
    /// ISO 3166-1 alpha-2 country code to restrict results
    /// </summary>
    public string? CountryCode
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("country_code");
        }
        init { this._rawBodyData.Set("country_code", value); }
    }

    /// <summary>
    /// GeoJSON Point geometry per RFC 7946. Coordinates use [longitude, latitude]
    /// order. Optional third element is altitude in meters.
    /// </summary>
    public PointGeometry? Focus
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<PointGeometry>("focus");
        }
        init { this._rawBodyData.Set("focus", value); }
    }

    /// <summary>
    /// Preferred response language (ISO 639-1)
    /// </summary>
    public string? Lang
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("lang");
        }
        init { this._rawBodyData.Set("lang", value); }
    }

    /// <summary>
    /// Filter by result layer (e.g. `address`, `place`, `poi`)
    /// </summary>
    public string? Layer
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("layer");
        }
        init { this._rawBodyData.Set("layer", value); }
    }

    /// <summary>
    /// Maximum number of suggestions (default: 5, max: 20)
    /// </summary>
    public long? Limit
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>("limit");
        }
        init { this._rawBodyData.Set("limit", value); }
    }

    public GeocodeAutocompleteParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public GeocodeAutocompleteParams(GeocodeAutocompleteParams geocodeAutocompleteParams)
        : base(geocodeAutocompleteParams)
    {
        this._rawBodyData = new(geocodeAutocompleteParams._rawBodyData);
    }
#pragma warning restore CS8618

    public GeocodeAutocompleteParams(
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
    GeocodeAutocompleteParams(
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
    public static GeocodeAutocompleteParams FromRawUnchecked(
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

    public virtual bool Equals(GeocodeAutocompleteParams? other)
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
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/api/v1/geocode/autocomplete"
        )
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

using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Plaza.Core;

namespace Plaza.Models.Geocode;

/// <summary>
/// Request body for forward geocoding. Converts an address or place name to coordinates.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<GeocodeForwardRequest, GeocodeForwardRequestFromRaw>))]
public sealed record class GeocodeForwardRequest : JsonModel
{
    /// <summary>
    /// Address or place name to geocode
    /// </summary>
    public required string Q
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("q");
        }
        init { this._rawData.Set("q", value); }
    }

    /// <summary>
    /// ISO 3166-1 alpha-2 country code to restrict results
    /// </summary>
    public string? CountryCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("country_code");
        }
        init { this._rawData.Set("country_code", value); }
    }

    /// <summary>
    /// GeoJSON Point geometry per RFC 7946. Coordinates use [longitude, latitude]
    /// order. Optional third element is altitude in meters.
    /// </summary>
    public PointGeometry? Focus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PointGeometry>("focus");
        }
        init { this._rawData.Set("focus", value); }
    }

    /// <summary>
    /// Preferred response language (ISO 639-1)
    /// </summary>
    public string? Lang
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("lang");
        }
        init { this._rawData.Set("lang", value); }
    }

    /// <summary>
    /// Filter by result layer (e.g. `address`, `place`, `poi`)
    /// </summary>
    public string? Layer
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("layer");
        }
        init { this._rawData.Set("layer", value); }
    }

    /// <summary>
    /// Maximum number of results (default: 5, max: 50)
    /// </summary>
    public long? Limit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("limit");
        }
        init { this._rawData.Set("limit", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Q;
        _ = this.CountryCode;
        this.Focus?.Validate();
        _ = this.Lang;
        _ = this.Layer;
        _ = this.Limit;
    }

    public GeocodeForwardRequest() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public GeocodeForwardRequest(GeocodeForwardRequest geocodeForwardRequest)
        : base(geocodeForwardRequest) { }
#pragma warning restore CS8618

    public GeocodeForwardRequest(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GeocodeForwardRequest(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="GeocodeForwardRequestFromRaw.FromRawUnchecked"/>
    public static GeocodeForwardRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public GeocodeForwardRequest(string q)
        : this()
    {
        this.Q = q;
    }
}

class GeocodeForwardRequestFromRaw : IFromRawJson<GeocodeForwardRequest>
{
    /// <inheritdoc/>
    public GeocodeForwardRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => GeocodeForwardRequest.FromRawUnchecked(rawData);
}

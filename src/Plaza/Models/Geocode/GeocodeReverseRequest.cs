using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Plaza.Core;

namespace Plaza.Models.Geocode;

/// <summary>
/// Request body for reverse geocoding. Converts coordinates to addresses or place names.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<GeocodeReverseRequest, GeocodeReverseRequestFromRaw>))]
public sealed record class GeocodeReverseRequest : JsonModel
{
    /// <summary>
    /// GeoJSON Point geometry per RFC 7946. Coordinates use [longitude, latitude]
    /// order. Optional third element is altitude in meters.
    /// </summary>
    public required PointGeometry Geometry
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<PointGeometry>("geometry");
        }
        init { this._rawData.Set("geometry", value); }
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
    /// Maximum number of results (default: 1, max: 50)
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

    /// <summary>
    /// Search radius in meters (default: 100)
    /// </summary>
    public double? Radius
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("radius");
        }
        init { this._rawData.Set("radius", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Geometry.Validate();
        _ = this.Lang;
        _ = this.Limit;
        _ = this.Radius;
    }

    public GeocodeReverseRequest() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public GeocodeReverseRequest(GeocodeReverseRequest geocodeReverseRequest)
        : base(geocodeReverseRequest) { }
#pragma warning restore CS8618

    public GeocodeReverseRequest(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GeocodeReverseRequest(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="GeocodeReverseRequestFromRaw.FromRawUnchecked"/>
    public static GeocodeReverseRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public GeocodeReverseRequest(PointGeometry geometry)
        : this()
    {
        this.Geometry = geometry;
    }
}

class GeocodeReverseRequestFromRaw : IFromRawJson<GeocodeReverseRequest>
{
    /// <inheritdoc/>
    public GeocodeReverseRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => GeocodeReverseRequest.FromRawUnchecked(rawData);
}

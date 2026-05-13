using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Plaza.Core;

namespace Plaza.Models.Routing;

/// <summary>
/// Request body for nearest-road-segment lookup. Snaps a point to the road network.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<NearestRequest, NearestRequestFromRaw>))]
public sealed record class NearestRequest : JsonModel
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
    /// Maximum search radius in meters (default: 100)
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
        _ = this.Radius;
    }

    public NearestRequest() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public NearestRequest(NearestRequest nearestRequest)
        : base(nearestRequest) { }
#pragma warning restore CS8618

    public NearestRequest(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NearestRequest(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NearestRequestFromRaw.FromRawUnchecked"/>
    public static NearestRequest FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public NearestRequest(PointGeometry geometry)
        : this()
    {
        this.Geometry = geometry;
    }
}

class NearestRequestFromRaw : IFromRawJson<NearestRequest>
{
    /// <inheritdoc/>
    public NearestRequest FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        NearestRequest.FromRawUnchecked(rawData);
}

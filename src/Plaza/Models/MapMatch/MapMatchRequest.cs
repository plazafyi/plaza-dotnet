using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Plaza.Core;

namespace Plaza.Models.MapMatch;

/// <summary>
/// GPS trace to snap to the road network. Provide a GeoJSON LineString geometry representing
/// the GPS trace.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<MapMatchRequest, MapMatchRequestFromRaw>))]
public sealed record class MapMatchRequest : JsonModel
{
    /// <summary>
    /// GeoJSON LineString geometry per RFC 7946. An ordered sequence of two or more positions.
    /// </summary>
    public required LineStringGeometry Geometry
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<LineStringGeometry>("geometry");
        }
        init { this._rawData.Set("geometry", value); }
    }

    /// <summary>
    /// Search radius per coordinate in meters. Must have the same length as the geometry
    /// coordinates or be omitted entirely. Default: 50m per point.
    /// </summary>
    public IReadOnlyList<double>? Radiuses
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<double>>("radiuses");
        }
        init
        {
            this._rawData.Set<ImmutableArray<double>?>(
                "radiuses",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Geometry.Validate();
        _ = this.Radiuses;
    }

    public MapMatchRequest() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MapMatchRequest(MapMatchRequest mapMatchRequest)
        : base(mapMatchRequest) { }
#pragma warning restore CS8618

    public MapMatchRequest(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MapMatchRequest(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MapMatchRequestFromRaw.FromRawUnchecked"/>
    public static MapMatchRequest FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public MapMatchRequest(LineStringGeometry geometry)
        : this()
    {
        this.Geometry = geometry;
    }
}

class MapMatchRequestFromRaw : IFromRawJson<MapMatchRequest>
{
    /// <inheritdoc/>
    public MapMatchRequest FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        MapMatchRequest.FromRawUnchecked(rawData);
}

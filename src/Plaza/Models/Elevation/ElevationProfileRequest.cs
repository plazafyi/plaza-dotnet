using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Plaza.Core;

namespace Plaza.Models.Elevation;

/// <summary>
/// Request body for elevation profile along a path. Provide a GeoJSON LineString
/// geometry defining the path.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ElevationProfileRequest, ElevationProfileRequestFromRaw>))]
public sealed record class ElevationProfileRequest : JsonModel
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

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Geometry.Validate();
    }

    public ElevationProfileRequest() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ElevationProfileRequest(ElevationProfileRequest elevationProfileRequest)
        : base(elevationProfileRequest) { }
#pragma warning restore CS8618

    public ElevationProfileRequest(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ElevationProfileRequest(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ElevationProfileRequestFromRaw.FromRawUnchecked"/>
    public static ElevationProfileRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ElevationProfileRequest(LineStringGeometry geometry)
        : this()
    {
        this.Geometry = geometry;
    }
}

class ElevationProfileRequestFromRaw : IFromRawJson<ElevationProfileRequest>
{
    /// <inheritdoc/>
    public ElevationProfileRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ElevationProfileRequest.FromRawUnchecked(rawData);
}

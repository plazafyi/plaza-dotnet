using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Plaza.Core;
using Plaza.Exceptions;
using System = System;

namespace Plaza.Models.Routing;

/// <summary>
/// GeoJSON Point Feature representing the nearest point on the road network to the
/// input coordinate. Used for snapping GPS coordinates to roads.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<NearestResult, NearestResultFromRaw>))]
public sealed record class NearestResult : JsonModel
{
    /// <summary>
    /// GeoJSON Geometry object per RFC 7946. Discriminated union — the `type` field
    /// determines the coordinate structure.
    /// </summary>
    public required Geometry Geometry
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Geometry>("geometry");
        }
        init { this._rawData.Set("geometry", value); }
    }

    /// <summary>
    /// Snap result metadata
    /// </summary>
    public required Properties Properties
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Properties>("properties");
        }
        init { this._rawData.Set("properties", value); }
    }

    public required ApiEnum<string, global::Plaza.Models.Routing.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Plaza.Models.Routing.Type>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Geometry.Validate();
        this.Properties.Validate();
        this.Type.Validate();
    }

    public NearestResult() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public NearestResult(NearestResult nearestResult)
        : base(nearestResult) { }
#pragma warning restore CS8618

    public NearestResult(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NearestResult(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NearestResultFromRaw.FromRawUnchecked"/>
    public static NearestResult FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NearestResultFromRaw : IFromRawJson<NearestResult>
{
    /// <inheritdoc/>
    public NearestResult FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        NearestResult.FromRawUnchecked(rawData);
}

/// <summary>
/// Snap result metadata
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Properties, PropertiesFromRaw>))]
public sealed record class Properties : JsonModel
{
    /// <summary>
    /// Distance from the input coordinate to the snapped point in meters
    /// </summary>
    public double? DistanceM
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("distance_m");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("distance_m", value);
        }
    }

    /// <summary>
    /// ID of the road network edge that was snapped to
    /// </summary>
    public long? EdgeID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("edge_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("edge_id", value);
        }
    }

    /// <summary>
    /// Length of the matched road edge in meters
    /// </summary>
    public double? EdgeLengthM
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("edge_length_m");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("edge_length_m", value);
        }
    }

    /// <summary>
    /// OSM highway tag value (e.g. `residential`, `primary`, `motorway`)
    /// </summary>
    public string? Highway
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("highway");
        }
        init { this._rawData.Set("highway", value); }
    }

    /// <summary>
    /// OSM way ID of the matched road segment
    /// </summary>
    public long? OsmWayID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("osm_way_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("osm_way_id", value);
        }
    }

    /// <summary>
    /// OSM surface tag value (e.g. `asphalt`, `gravel`, `paved`)
    /// </summary>
    public string? Surface
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("surface");
        }
        init { this._rawData.Set("surface", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DistanceM;
        _ = this.EdgeID;
        _ = this.EdgeLengthM;
        _ = this.Highway;
        _ = this.OsmWayID;
        _ = this.Surface;
    }

    public Properties() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Properties(Properties properties)
        : base(properties) { }
#pragma warning restore CS8618

    public Properties(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Properties(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PropertiesFromRaw.FromRawUnchecked"/>
    public static Properties FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PropertiesFromRaw : IFromRawJson<Properties>
{
    /// <inheritdoc/>
    public Properties FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Properties.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    Feature,
}

sealed class TypeConverter : JsonConverter<global::Plaza.Models.Routing.Type>
{
    public override global::Plaza.Models.Routing.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Feature" => global::Plaza.Models.Routing.Type.Feature,
            _ => (global::Plaza.Models.Routing.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Plaza.Models.Routing.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Plaza.Models.Routing.Type.Feature => "Feature",
                _ => throw new PlazaInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

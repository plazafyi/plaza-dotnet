using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Plaza.Core;
using Plaza.Exceptions;
using System = System;

namespace Plaza.Models.MapMatch;

/// <summary>
/// Map matching result as a GeoJSON FeatureCollection. Each Feature is a snapped
/// tracepoint. The top-level `matchings` array contains the matched sub-routes connecting
/// consecutive tracepoints.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<MapMatchResult, MapMatchResultFromRaw>))]
public sealed record class MapMatchResult : JsonModel
{
    /// <summary>
    /// Snapped tracepoint Features in input order
    /// </summary>
    public required IReadOnlyList<Feature> Features
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Feature>>("features");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Feature>>(
                "features",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Matched sub-routes. Each matching connects a contiguous sequence of tracepoints
    /// that could be matched to roads.
    /// </summary>
    public required IReadOnlyList<IReadOnlyDictionary<string, JsonElement>> Matchings
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<FrozenDictionary<string, JsonElement>>
            >("matchings");
        }
        init
        {
            this._rawData.Set<ImmutableArray<FrozenDictionary<string, JsonElement>>>(
                "matchings",
                ImmutableArray.ToImmutableArray(
                    Enumerable.Select(value, (item) => FrozenDictionary.ToFrozenDictionary(item))
                )
            );
        }
    }

    public required ApiEnum<string, MapMatchResultType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, MapMatchResultType>>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Features)
        {
            item.Validate();
        }
        _ = this.Matchings;
        this.Type.Validate();
    }

    public MapMatchResult() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MapMatchResult(MapMatchResult mapMatchResult)
        : base(mapMatchResult) { }
#pragma warning restore CS8618

    public MapMatchResult(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MapMatchResult(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MapMatchResultFromRaw.FromRawUnchecked"/>
    public static MapMatchResult FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MapMatchResultFromRaw : IFromRawJson<MapMatchResult>
{
    /// <inheritdoc/>
    public MapMatchResult FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        MapMatchResult.FromRawUnchecked(rawData);
}

/// <summary>
/// GeoJSON Point Feature representing a GPS point snapped to the road network.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Feature, FeatureFromRaw>))]
public sealed record class Feature : JsonModel
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

    public required Properties Properties
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Properties>("properties");
        }
        init { this._rawData.Set("properties", value); }
    }

    public required ApiEnum<string, global::Plaza.Models.MapMatch.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Plaza.Models.MapMatch.Type>
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

    public Feature() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Feature(Feature feature)
        : base(feature) { }
#pragma warning restore CS8618

    public Feature(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Feature(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FeatureFromRaw.FromRawUnchecked"/>
    public static Feature FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FeatureFromRaw : IFromRawJson<Feature>
{
    /// <inheritdoc/>
    public Feature FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Feature.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Properties, PropertiesFromRaw>))]
public sealed record class Properties : JsonModel
{
    /// <summary>
    /// Distance from the original GPS point to the snapped point in meters
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
    /// Road edge ID the point was snapped to
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
    /// Index into the `matchings` array indicating which matching sub-route this
    /// point belongs to
    /// </summary>
    public long? MatchingsIndex
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("matchings_index");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("matchings_index", value);
        }
    }

    /// <summary>
    /// Road name at the snapped point
    /// </summary>
    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Original GPS coordinate as [lng, lat]
    /// </summary>
    public IReadOnlyList<double>? Original
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<double>>("original");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<double>?>(
                "original",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Index of this tracepoint in the original `coordinates` array
    /// </summary>
    public long? WaypointIndex
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("waypoint_index");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("waypoint_index", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DistanceM;
        _ = this.EdgeID;
        _ = this.MatchingsIndex;
        _ = this.Name;
        _ = this.Original;
        _ = this.WaypointIndex;
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

sealed class TypeConverter : JsonConverter<global::Plaza.Models.MapMatch.Type>
{
    public override global::Plaza.Models.MapMatch.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Feature" => global::Plaza.Models.MapMatch.Type.Feature,
            _ => (global::Plaza.Models.MapMatch.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Plaza.Models.MapMatch.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Plaza.Models.MapMatch.Type.Feature => "Feature",
                _ => throw new PlazaInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(MapMatchResultTypeConverter))]
public enum MapMatchResultType
{
    FeatureCollection,
}

sealed class MapMatchResultTypeConverter : JsonConverter<MapMatchResultType>
{
    public override MapMatchResultType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "FeatureCollection" => MapMatchResultType.FeatureCollection,
            _ => (MapMatchResultType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MapMatchResultType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                MapMatchResultType.FeatureCollection => "FeatureCollection",
                _ => throw new PlazaInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Plaza.Core;
using Plaza.Exceptions;
using System = System;

namespace Plaza.Models.Optimize;

/// <summary>
/// Completed optimization result as a GeoJSON FeatureCollection. Each Feature is
/// a waypoint in optimized visit order. Top-level fields provide summary statistics.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<OptimizeCompletedResult, OptimizeCompletedResultFromRaw>))]
public sealed record class OptimizeCompletedResult : JsonModel
{
    /// <summary>
    /// Waypoints in optimized visit order
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
    /// Optimization method used (e.g. `nearest_neighbor`, `2opt`)
    /// </summary>
    public required string Optimization
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("optimization");
        }
        init { this._rawData.Set("optimization", value); }
    }

    /// <summary>
    /// Whether the route returns to the starting waypoint
    /// </summary>
    public required bool Roundtrip
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("roundtrip");
        }
        init { this._rawData.Set("roundtrip", value); }
    }

    /// <summary>
    /// Total travel time for the optimized route in seconds
    /// </summary>
    public required double TotalCostS
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("total_cost_s");
        }
        init { this._rawData.Set("total_cost_s", value); }
    }

    public required ApiEnum<string, OptimizeCompletedResultType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, OptimizeCompletedResultType>>(
                "type"
            );
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
        _ = this.Optimization;
        _ = this.Roundtrip;
        _ = this.TotalCostS;
        this.Type.Validate();
    }

    public OptimizeCompletedResult() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OptimizeCompletedResult(OptimizeCompletedResult optimizeCompletedResult)
        : base(optimizeCompletedResult) { }
#pragma warning restore CS8618

    public OptimizeCompletedResult(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OptimizeCompletedResult(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OptimizeCompletedResultFromRaw.FromRawUnchecked"/>
    public static OptimizeCompletedResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OptimizeCompletedResultFromRaw : IFromRawJson<OptimizeCompletedResult>
{
    /// <inheritdoc/>
    public OptimizeCompletedResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => OptimizeCompletedResult.FromRawUnchecked(rawData);
}

/// <summary>
/// GeoJSON Point Feature representing an optimized waypoint with cost data.
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

    public required ApiEnum<string, global::Plaza.Models.Optimize.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Plaza.Models.Optimize.Type>
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
    /// Travel time in seconds from the previous waypoint to this one (0 for the
    /// first waypoint)
    /// </summary>
    public required double CostS
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("cost_s");
        }
        init { this._rawData.Set("cost_s", value); }
    }

    /// <summary>
    /// Cumulative travel time in seconds from the start to this waypoint
    /// </summary>
    public required double CumulativeCostS
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("cumulative_cost_s");
        }
        init { this._rawData.Set("cumulative_cost_s", value); }
    }

    /// <summary>
    /// Position of this waypoint in the optimized visit order (0-based)
    /// </summary>
    public required long WaypointIndex
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("waypoint_index");
        }
        init { this._rawData.Set("waypoint_index", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CostS;
        _ = this.CumulativeCostS;
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

sealed class TypeConverter : JsonConverter<global::Plaza.Models.Optimize.Type>
{
    public override global::Plaza.Models.Optimize.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Feature" => global::Plaza.Models.Optimize.Type.Feature,
            _ => (global::Plaza.Models.Optimize.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Plaza.Models.Optimize.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Plaza.Models.Optimize.Type.Feature => "Feature",
                _ => throw new PlazaInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(OptimizeCompletedResultTypeConverter))]
public enum OptimizeCompletedResultType
{
    FeatureCollection,
}

sealed class OptimizeCompletedResultTypeConverter : JsonConverter<OptimizeCompletedResultType>
{
    public override OptimizeCompletedResultType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "FeatureCollection" => OptimizeCompletedResultType.FeatureCollection,
            _ => (OptimizeCompletedResultType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        OptimizeCompletedResultType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                OptimizeCompletedResultType.FeatureCollection => "FeatureCollection",
                _ => throw new PlazaInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

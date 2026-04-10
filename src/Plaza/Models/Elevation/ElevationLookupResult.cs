using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Plaza.Core;
using Plaza.Exceptions;
using Models = Plaza.Models;
using System = System;

namespace Plaza.Models.Elevation;

/// <summary>
/// GeoJSON Point Feature with a 3D coordinate [lng, lat, elevation] per RFC 7946
/// §3.1.1. The elevation is also available in `properties.elevation_m` for convenience.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ElevationLookupResult, ElevationLookupResultFromRaw>))]
public sealed record class ElevationLookupResult : JsonModel
{
    /// <summary>
    /// GeoJSON Geometry object per RFC 7946. Discriminated union — the `type` field
    /// determines the coordinate structure.
    /// </summary>
    public required Models::Geometry Geometry
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Models::Geometry>("geometry");
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

    public required ApiEnum<string, global::Plaza.Models.Elevation.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Plaza.Models.Elevation.Type>
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

    public ElevationLookupResult() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ElevationLookupResult(ElevationLookupResult elevationLookupResult)
        : base(elevationLookupResult) { }
#pragma warning restore CS8618

    public ElevationLookupResult(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ElevationLookupResult(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ElevationLookupResultFromRaw.FromRawUnchecked"/>
    public static ElevationLookupResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ElevationLookupResultFromRaw : IFromRawJson<ElevationLookupResult>
{
    /// <inheritdoc/>
    public ElevationLookupResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ElevationLookupResult.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Properties, PropertiesFromRaw>))]
public sealed record class Properties : JsonModel
{
    /// <summary>
    /// Elevation in meters above mean sea level (WGS84 EGM96 geoid)
    /// </summary>
    public required double ElevationM
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("elevation_m");
        }
        init { this._rawData.Set("elevation_m", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ElevationM;
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

    [SetsRequiredMembers]
    public Properties(double elevationM)
        : this()
    {
        this.ElevationM = elevationM;
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

sealed class TypeConverter : JsonConverter<global::Plaza.Models.Elevation.Type>
{
    public override global::Plaza.Models.Elevation.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Feature" => global::Plaza.Models.Elevation.Type.Feature,
            _ => (global::Plaza.Models.Elevation.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Plaza.Models.Elevation.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Plaza.Models.Elevation.Type.Feature => "Feature",
                _ => throw new PlazaInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

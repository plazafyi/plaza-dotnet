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
/// GeoJSON LineString Feature with 3D coordinates [lng, lat, elevation] representing
/// the elevation profile along the input path. Summary statistics are in properties.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ElevationProfileResult, ElevationProfileResultFromRaw>))]
public sealed record class ElevationProfileResult : JsonModel
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

    /// <summary>
    /// Elevation profile summary statistics
    /// </summary>
    public required ElevationProfileResultProperties Properties
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ElevationProfileResultProperties>("properties");
        }
        init { this._rawData.Set("properties", value); }
    }

    public required ApiEnum<string, ElevationProfileResultType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ElevationProfileResultType>>(
                "type"
            );
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

    public ElevationProfileResult() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ElevationProfileResult(ElevationProfileResult elevationProfileResult)
        : base(elevationProfileResult) { }
#pragma warning restore CS8618

    public ElevationProfileResult(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ElevationProfileResult(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ElevationProfileResultFromRaw.FromRawUnchecked"/>
    public static ElevationProfileResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ElevationProfileResultFromRaw : IFromRawJson<ElevationProfileResult>
{
    /// <inheritdoc/>
    public ElevationProfileResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ElevationProfileResult.FromRawUnchecked(rawData);
}

/// <summary>
/// Elevation profile summary statistics
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ElevationProfileResultProperties,
        ElevationProfileResultPropertiesFromRaw
    >)
)]
public sealed record class ElevationProfileResultProperties : JsonModel
{
    /// <summary>
    /// Average elevation along the profile in meters
    /// </summary>
    public required double AvgElevationM
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("avg_elevation_m");
        }
        init { this._rawData.Set("avg_elevation_m", value); }
    }

    /// <summary>
    /// Maximum elevation along the profile in meters
    /// </summary>
    public required double MaxElevationM
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("max_elevation_m");
        }
        init { this._rawData.Set("max_elevation_m", value); }
    }

    /// <summary>
    /// Minimum elevation along the profile in meters
    /// </summary>
    public required double MinElevationM
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("min_elevation_m");
        }
        init { this._rawData.Set("min_elevation_m", value); }
    }

    /// <summary>
    /// Total cumulative elevation gain in meters
    /// </summary>
    public required double TotalAscentM
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("total_ascent_m");
        }
        init { this._rawData.Set("total_ascent_m", value); }
    }

    /// <summary>
    /// Total cumulative elevation loss in meters
    /// </summary>
    public required double TotalDescentM
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("total_descent_m");
        }
        init { this._rawData.Set("total_descent_m", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AvgElevationM;
        _ = this.MaxElevationM;
        _ = this.MinElevationM;
        _ = this.TotalAscentM;
        _ = this.TotalDescentM;
    }

    public ElevationProfileResultProperties() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ElevationProfileResultProperties(
        ElevationProfileResultProperties elevationProfileResultProperties
    )
        : base(elevationProfileResultProperties) { }
#pragma warning restore CS8618

    public ElevationProfileResultProperties(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ElevationProfileResultProperties(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ElevationProfileResultPropertiesFromRaw.FromRawUnchecked"/>
    public static ElevationProfileResultProperties FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ElevationProfileResultPropertiesFromRaw : IFromRawJson<ElevationProfileResultProperties>
{
    /// <inheritdoc/>
    public ElevationProfileResultProperties FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ElevationProfileResultProperties.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ElevationProfileResultTypeConverter))]
public enum ElevationProfileResultType
{
    Feature,
}

sealed class ElevationProfileResultTypeConverter : JsonConverter<ElevationProfileResultType>
{
    public override ElevationProfileResultType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Feature" => ElevationProfileResultType.Feature,
            _ => (ElevationProfileResultType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ElevationProfileResultType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ElevationProfileResultType.Feature => "Feature",
                _ => throw new PlazaInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Plaza.Core;
using Plaza.Exceptions;
using System = System;

namespace Plaza.Models;

/// <summary>
/// GeoJSON Point geometry per RFC 7946. Coordinates use [longitude, latitude] order.
/// Optional third element is altitude in meters.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PointGeometry, PointGeometryFromRaw>))]
public sealed record class PointGeometry : JsonModel
{
    /// <summary>
    /// [longitude, latitude] or [longitude, latitude, altitude]
    /// </summary>
    public required IReadOnlyList<double> Coordinates
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<double>>("coordinates");
        }
        init
        {
            this._rawData.Set<ImmutableArray<double>>(
                "coordinates",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required ApiEnum<string, PointGeometryType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, PointGeometryType>>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Coordinates;
        this.Type.Validate();
    }

    public PointGeometry() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PointGeometry(PointGeometry pointGeometry)
        : base(pointGeometry) { }
#pragma warning restore CS8618

    public PointGeometry(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PointGeometry(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PointGeometryFromRaw.FromRawUnchecked"/>
    public static PointGeometry FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PointGeometryFromRaw : IFromRawJson<PointGeometry>
{
    /// <inheritdoc/>
    public PointGeometry FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PointGeometry.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(PointGeometryTypeConverter))]
public enum PointGeometryType
{
    Point,
}

sealed class PointGeometryTypeConverter : JsonConverter<PointGeometryType>
{
    public override PointGeometryType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Point" => PointGeometryType.Point,
            _ => (PointGeometryType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PointGeometryType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PointGeometryType.Point => "Point",
                _ => throw new PlazaInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

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

namespace Plaza.Models;

/// <summary>
/// GeoJSON LineString geometry per RFC 7946. An ordered sequence of two or more positions.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<LineStringGeometry, LineStringGeometryFromRaw>))]
public sealed record class LineStringGeometry : JsonModel
{
    /// <summary>
    /// Array of [lng, lat] or [lng, lat, alt] positions
    /// </summary>
    public required IReadOnlyList<IReadOnlyList<double>> Coordinates
    {
        get
        {
            this._rawData.Freeze();
            return ImmutableArray.ToImmutableArray(
                Enumerable.Select(
                    this._rawData.GetNotNullStruct<ImmutableArray<ImmutableArray<double>>>(
                        "coordinates"
                    ),
                    (item) => (IReadOnlyList<double>)item
                )
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<ImmutableArray<double>>>(
                "coordinates",
                ImmutableArray.ToImmutableArray(
                    Enumerable.Select(value, (item) => ImmutableArray.ToImmutableArray(item))
                )
            );
        }
    }

    public required ApiEnum<string, LineStringGeometryType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, LineStringGeometryType>>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Coordinates;
        this.Type.Validate();
    }

    public LineStringGeometry() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public LineStringGeometry(LineStringGeometry lineStringGeometry)
        : base(lineStringGeometry) { }
#pragma warning restore CS8618

    public LineStringGeometry(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LineStringGeometry(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LineStringGeometryFromRaw.FromRawUnchecked"/>
    public static LineStringGeometry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LineStringGeometryFromRaw : IFromRawJson<LineStringGeometry>
{
    /// <inheritdoc/>
    public LineStringGeometry FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        LineStringGeometry.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(LineStringGeometryTypeConverter))]
public enum LineStringGeometryType
{
    LineString,
}

sealed class LineStringGeometryTypeConverter : JsonConverter<LineStringGeometryType>
{
    public override LineStringGeometryType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "LineString" => LineStringGeometryType.LineString,
            _ => (LineStringGeometryType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        LineStringGeometryType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                LineStringGeometryType.LineString => "LineString",
                _ => throw new PlazaInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

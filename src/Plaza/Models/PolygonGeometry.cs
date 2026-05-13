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
/// GeoJSON Polygon geometry per RFC 7946. An array of linear rings where the first
/// ring is the exterior boundary and subsequent rings are holes. Each ring must have
/// at least 4 positions with the first and last being identical.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PolygonGeometry, PolygonGeometryFromRaw>))]
public sealed record class PolygonGeometry : JsonModel
{
    /// <summary>
    /// Array of linear rings (first = exterior, rest = holes)
    /// </summary>
    public required IReadOnlyList<IReadOnlyList<IReadOnlyList<double>>> Coordinates
    {
        get
        {
            this._rawData.Freeze();
            return ImmutableArray.ToImmutableArray(
                Enumerable.Select(
                    this._rawData.GetNotNullStruct<
                        ImmutableArray<ImmutableArray<ImmutableArray<double>>>
                    >("coordinates"),
                    (item) =>
                        (IReadOnlyList<IReadOnlyList<double>>)
                            ImmutableArray.ToImmutableArray(
                                Enumerable.Select(item, (item1) => (IReadOnlyList<double>)item1)
                            )
                )
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<ImmutableArray<ImmutableArray<double>>>>(
                "coordinates",
                ImmutableArray.ToImmutableArray(
                    Enumerable.Select(
                        value,
                        (item) =>
                            ImmutableArray.ToImmutableArray(
                                Enumerable.Select(
                                    item,
                                    (item1) => ImmutableArray.ToImmutableArray(item1)
                                )
                            )
                    )
                )
            );
        }
    }

    public required ApiEnum<string, PolygonGeometryType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, PolygonGeometryType>>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Coordinates;
        this.Type.Validate();
    }

    public PolygonGeometry() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PolygonGeometry(PolygonGeometry polygonGeometry)
        : base(polygonGeometry) { }
#pragma warning restore CS8618

    public PolygonGeometry(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PolygonGeometry(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PolygonGeometryFromRaw.FromRawUnchecked"/>
    public static PolygonGeometry FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PolygonGeometryFromRaw : IFromRawJson<PolygonGeometry>
{
    /// <inheritdoc/>
    public PolygonGeometry FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PolygonGeometry.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(PolygonGeometryTypeConverter))]
public enum PolygonGeometryType
{
    Polygon,
}

sealed class PolygonGeometryTypeConverter : JsonConverter<PolygonGeometryType>
{
    public override PolygonGeometryType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Polygon" => PolygonGeometryType.Polygon,
            _ => (PolygonGeometryType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PolygonGeometryType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PolygonGeometryType.Polygon => "Polygon",
                _ => throw new PlazaInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

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
/// GeoJSON MultiPolygon geometry per RFC 7946. An array of Polygon coordinate arrays.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<MultiPolygonGeometry, MultiPolygonGeometryFromRaw>))]
public sealed record class MultiPolygonGeometry : JsonModel
{
    /// <summary>
    /// Array of Polygon coordinate arrays
    /// </summary>
    public required IReadOnlyList<IReadOnlyList<IReadOnlyList<IReadOnlyList<double>>>> Coordinates
    {
        get
        {
            this._rawData.Freeze();
            return ImmutableArray.ToImmutableArray(
                Enumerable.Select(
                    this._rawData.GetNotNullStruct<
                        ImmutableArray<ImmutableArray<ImmutableArray<ImmutableArray<double>>>>
                    >("coordinates"),
                    (item) =>
                        (IReadOnlyList<IReadOnlyList<IReadOnlyList<double>>>)
                            ImmutableArray.ToImmutableArray(
                                Enumerable.Select(
                                    item,
                                    (item1) =>
                                        (IReadOnlyList<IReadOnlyList<double>>)
                                            ImmutableArray.ToImmutableArray(
                                                Enumerable.Select(
                                                    item1,
                                                    (item2) => (IReadOnlyList<double>)item2
                                                )
                                            )
                                )
                            )
                )
            );
        }
        init
        {
            this._rawData.Set<
                ImmutableArray<ImmutableArray<ImmutableArray<ImmutableArray<double>>>>
            >(
                "coordinates",
                ImmutableArray.ToImmutableArray(
                    Enumerable.Select(
                        value,
                        (item) =>
                            ImmutableArray.ToImmutableArray(
                                Enumerable.Select(
                                    item,
                                    (item1) =>
                                        ImmutableArray.ToImmutableArray(
                                            Enumerable.Select(
                                                item1,
                                                (item2) => ImmutableArray.ToImmutableArray(item2)
                                            )
                                        )
                                )
                            )
                    )
                )
            );
        }
    }

    public required ApiEnum<string, MultiPolygonGeometryType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, MultiPolygonGeometryType>>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Coordinates;
        this.Type.Validate();
    }

    public MultiPolygonGeometry() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MultiPolygonGeometry(MultiPolygonGeometry multiPolygonGeometry)
        : base(multiPolygonGeometry) { }
#pragma warning restore CS8618

    public MultiPolygonGeometry(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MultiPolygonGeometry(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MultiPolygonGeometryFromRaw.FromRawUnchecked"/>
    public static MultiPolygonGeometry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MultiPolygonGeometryFromRaw : IFromRawJson<MultiPolygonGeometry>
{
    /// <inheritdoc/>
    public MultiPolygonGeometry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MultiPolygonGeometry.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(MultiPolygonGeometryTypeConverter))]
public enum MultiPolygonGeometryType
{
    MultiPolygon,
}

sealed class MultiPolygonGeometryTypeConverter : JsonConverter<MultiPolygonGeometryType>
{
    public override MultiPolygonGeometryType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "MultiPolygon" => MultiPolygonGeometryType.MultiPolygon,
            _ => (MultiPolygonGeometryType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MultiPolygonGeometryType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                MultiPolygonGeometryType.MultiPolygon => "MultiPolygon",
                _ => throw new PlazaInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

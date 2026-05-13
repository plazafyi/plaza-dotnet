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
/// GeoJSON MultiLineString geometry per RFC 7946. An array of LineString coordinate arrays.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<MultiLineStringGeometry, MultiLineStringGeometryFromRaw>))]
public sealed record class MultiLineStringGeometry : JsonModel
{
    /// <summary>
    /// Array of LineString coordinate arrays
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

    public required ApiEnum<string, MultiLineStringGeometryType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, MultiLineStringGeometryType>>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Coordinates;
        this.Type.Validate();
    }

    public MultiLineStringGeometry() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MultiLineStringGeometry(MultiLineStringGeometry multiLineStringGeometry)
        : base(multiLineStringGeometry) { }
#pragma warning restore CS8618

    public MultiLineStringGeometry(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MultiLineStringGeometry(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MultiLineStringGeometryFromRaw.FromRawUnchecked"/>
    public static MultiLineStringGeometry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MultiLineStringGeometryFromRaw : IFromRawJson<MultiLineStringGeometry>
{
    /// <inheritdoc/>
    public MultiLineStringGeometry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MultiLineStringGeometry.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(MultiLineStringGeometryTypeConverter))]
public enum MultiLineStringGeometryType
{
    MultiLineString,
}

sealed class MultiLineStringGeometryTypeConverter : JsonConverter<MultiLineStringGeometryType>
{
    public override MultiLineStringGeometryType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "MultiLineString" => MultiLineStringGeometryType.MultiLineString,
            _ => (MultiLineStringGeometryType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MultiLineStringGeometryType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                MultiLineStringGeometryType.MultiLineString => "MultiLineString",
                _ => throw new PlazaInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

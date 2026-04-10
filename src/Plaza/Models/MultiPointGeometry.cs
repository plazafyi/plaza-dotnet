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
/// GeoJSON MultiPoint geometry per RFC 7946. An array of positions.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<MultiPointGeometry, MultiPointGeometryFromRaw>))]
public sealed record class MultiPointGeometry : JsonModel
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

    public required ApiEnum<string, MultiPointGeometryType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, MultiPointGeometryType>>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Coordinates;
        this.Type.Validate();
    }

    public MultiPointGeometry() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MultiPointGeometry(MultiPointGeometry multiPointGeometry)
        : base(multiPointGeometry) { }
#pragma warning restore CS8618

    public MultiPointGeometry(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MultiPointGeometry(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MultiPointGeometryFromRaw.FromRawUnchecked"/>
    public static MultiPointGeometry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MultiPointGeometryFromRaw : IFromRawJson<MultiPointGeometry>
{
    /// <inheritdoc/>
    public MultiPointGeometry FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        MultiPointGeometry.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(MultiPointGeometryTypeConverter))]
public enum MultiPointGeometryType
{
    MultiPoint,
}

sealed class MultiPointGeometryTypeConverter : JsonConverter<MultiPointGeometryType>
{
    public override MultiPointGeometryType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "MultiPoint" => MultiPointGeometryType.MultiPoint,
            _ => (MultiPointGeometryType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MultiPointGeometryType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                MultiPointGeometryType.MultiPoint => "MultiPoint",
                _ => throw new PlazaInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

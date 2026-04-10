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
/// GeoJSON FeatureCollection (RFC 7946). For paginated endpoints, metadata is returned
/// in HTTP response headers rather than the body:
///
/// <para>| Header | Description | |---|---| | `X-Limit` | Requested result limit
/// | | `X-Has-More` | `true` if more results exist | | `X-Next-Cursor` | Opaque
/// cursor for next page (cursor pagination) | | `X-Next-Offset` | Numeric offset
/// for next page (offset pagination) | | `Link` | RFC 8288 `rel="next"` link to
/// the next page |</para>
///
/// <para>Content-Type is `application/geo+json`. </para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<FeatureCollection, FeatureCollectionFromRaw>))]
public sealed record class FeatureCollection : JsonModel
{
    /// <summary>
    /// Array of GeoJSON Feature objects
    /// </summary>
    public required IReadOnlyList<GeoJsonFeature> Features
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<GeoJsonFeature>>("features");
        }
        init
        {
            this._rawData.Set<ImmutableArray<GeoJsonFeature>>(
                "features",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Always `FeatureCollection`
    /// </summary>
    public required ApiEnum<string, global::Plaza.Models.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, global::Plaza.Models.Type>>(
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
        this.Type.Validate();
    }

    public FeatureCollection() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FeatureCollection(FeatureCollection featureCollection)
        : base(featureCollection) { }
#pragma warning restore CS8618

    public FeatureCollection(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FeatureCollection(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FeatureCollectionFromRaw.FromRawUnchecked"/>
    public static FeatureCollection FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FeatureCollectionFromRaw : IFromRawJson<FeatureCollection>
{
    /// <inheritdoc/>
    public FeatureCollection FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FeatureCollection.FromRawUnchecked(rawData);
}

/// <summary>
/// Always `FeatureCollection`
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    FeatureCollection,
}

sealed class TypeConverter : JsonConverter<global::Plaza.Models.Type>
{
    public override global::Plaza.Models.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "FeatureCollection" => global::Plaza.Models.Type.FeatureCollection,
            _ => (global::Plaza.Models.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Plaza.Models.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Plaza.Models.Type.FeatureCollection => "FeatureCollection",
                _ => throw new PlazaInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

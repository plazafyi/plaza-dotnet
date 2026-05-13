using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Plaza.Core;
using Plaza.Exceptions;
using System = System;

namespace Plaza.Models;

/// <summary>
/// GeoJSON Feature representing an OSM element. Tags from the original OSM element
/// are flattened directly into `properties` (not nested under a `tags` key). Metadata
/// fields `@type` and `@id` identify the OSM element type and ID within properties.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<GeoJsonFeature, GeoJsonFeatureFromRaw>))]
public sealed record class GeoJsonFeature : JsonModel
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

    /// <summary>
    /// OSM tags flattened as key-value pairs, plus `@type` (node/way/relation) and
    /// `@id` (OSM ID) metadata fields. May include `distance_m` for proximity queries.
    /// </summary>
    public required IReadOnlyDictionary<string, JsonElement> Properties
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, JsonElement>>(
                "properties"
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonElement>>(
                "properties",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Always `Feature`
    /// </summary>
    public required ApiEnum<string, GeoJsonFeatureType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, GeoJsonFeatureType>>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Compound identifier in `type/osm_id` format
    /// </summary>
    public string? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Geometry.Validate();
        _ = this.Properties;
        this.Type.Validate();
        _ = this.ID;
    }

    public GeoJsonFeature() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public GeoJsonFeature(GeoJsonFeature geoJsonFeature)
        : base(geoJsonFeature) { }
#pragma warning restore CS8618

    public GeoJsonFeature(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GeoJsonFeature(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="GeoJsonFeatureFromRaw.FromRawUnchecked"/>
    public static GeoJsonFeature FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class GeoJsonFeatureFromRaw : IFromRawJson<GeoJsonFeature>
{
    /// <inheritdoc/>
    public GeoJsonFeature FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        GeoJsonFeature.FromRawUnchecked(rawData);
}

/// <summary>
/// Always `Feature`
/// </summary>
[JsonConverter(typeof(GeoJsonFeatureTypeConverter))]
public enum GeoJsonFeatureType
{
    Feature,
}

sealed class GeoJsonFeatureTypeConverter : JsonConverter<GeoJsonFeatureType>
{
    public override GeoJsonFeatureType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Feature" => GeoJsonFeatureType.Feature,
            _ => (GeoJsonFeatureType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        GeoJsonFeatureType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                GeoJsonFeatureType.Feature => "Feature",
                _ => throw new PlazaInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

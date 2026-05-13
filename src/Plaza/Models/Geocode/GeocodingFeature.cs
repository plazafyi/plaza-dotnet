using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Plaza.Core;
using Plaza.Exceptions;
using System = System;

namespace Plaza.Models.Geocode;

/// <summary>
/// GeoJSON Feature representing a geocoding result. The geometry is always a Point.
/// Properties include the formatted display name, OSM metadata, confidence score,
/// and source type.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<GeocodingFeature, GeocodingFeatureFromRaw>))]
public sealed record class GeocodingFeature : JsonModel
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
    /// Geocoding result properties
    /// </summary>
    public required Properties Properties
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Properties>("properties");
        }
        init { this._rawData.Set("properties", value); }
    }

    public required ApiEnum<string, GeocodingFeatureType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, GeocodingFeatureType>>("type");
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

    public GeocodingFeature() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public GeocodingFeature(GeocodingFeature geocodingFeature)
        : base(geocodingFeature) { }
#pragma warning restore CS8618

    public GeocodingFeature(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GeocodingFeature(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="GeocodingFeatureFromRaw.FromRawUnchecked"/>
    public static GeocodingFeature FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class GeocodingFeatureFromRaw : IFromRawJson<GeocodingFeature>
{
    /// <inheritdoc/>
    public GeocodingFeature FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        GeocodingFeature.FromRawUnchecked(rawData);
}

/// <summary>
/// Geocoding result properties
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Properties, PropertiesFromRaw>))]
public sealed record class Properties : JsonModel
{
    /// <summary>
    /// Formatted address or place name
    /// </summary>
    public required string DisplayName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("display_name");
        }
        init { this._rawData.Set("display_name", value); }
    }

    /// <summary>
    /// POI category (e.g. restaurant, cafe, park). Present for place results.
    /// </summary>
    public string? Category
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("category");
        }
        init { this._rawData.Set("category", value); }
    }

    /// <summary>
    /// City or town name. Present for address results.
    /// </summary>
    public string? City
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("city");
        }
        init { this._rawData.Set("city", value); }
    }

    /// <summary>
    /// Interpolation confidence (0-1). Present only for interpolated results.
    /// </summary>
    public double? Confidence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("confidence");
        }
        init { this._rawData.Set("confidence", value); }
    }

    /// <summary>
    /// Country name. Present for reverse geocode address results.
    /// </summary>
    public string? Country
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("country");
        }
        init { this._rawData.Set("country", value); }
    }

    /// <summary>
    /// ISO 3166-1 alpha-2 country code
    /// </summary>
    public string? CountryCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("country_code");
        }
        init { this._rawData.Set("country_code", value); }
    }

    /// <summary>
    /// Distance from the query point in meters (reverse geocode / nearby only)
    /// </summary>
    public double? DistanceM
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("distance_m");
        }
        init { this._rawData.Set("distance_m", value); }
    }

    /// <summary>
    /// Complete formatted address from the database. Present for reverse geocode
    /// address results.
    /// </summary>
    public string? FullAddress
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("full_address");
        }
        init { this._rawData.Set("full_address", value); }
    }

    /// <summary>
    /// House or building number. Present for address and interpolated results.
    /// </summary>
    public string? HouseNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("house_number");
        }
        init { this._rawData.Set("house_number", value); }
    }

    /// <summary>
    /// Whether this result was estimated by address interpolation rather than an
    /// exact database match.
    /// </summary>
    public bool? Interpolated
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("interpolated");
        }
        init { this._rawData.Set("interpolated", value); }
    }

    /// <summary>
    /// Place name (raw). Present for reverse geocode place results.
    /// </summary>
    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// OpenStreetMap element ID (null for interpolated results)
    /// </summary>
    public long? OsmID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("osm_id");
        }
        init { this._rawData.Set("osm_id", value); }
    }

    /// <summary>
    /// OSM element type (node, way, relation)
    /// </summary>
    public ApiEnum<string, OsmType>? OsmType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, OsmType>>("osm_type");
        }
        init { this._rawData.Set("osm_type", value); }
    }

    /// <summary>
    /// Postal code. Present for reverse geocode address results.
    /// </summary>
    public string? Postcode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("postcode");
        }
        init { this._rawData.Set("postcode", value); }
    }

    /// <summary>
    /// Relevance score (higher is better). Incorporates text match quality, spatial
    /// proximity boost, and popularity signals. Not bounded to 0-1.
    /// </summary>
    public double? Score
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("score");
        }
        init { this._rawData.Set("score", value); }
    }

    /// <summary>
    /// Result source indicating how the result was found: structured (exact field
    /// match), fuzzy (trigram similarity), address (reverse geocode address), place
    /// (reverse geocode POI), interpolation (estimated from neighboring addresses)
    /// </summary>
    public ApiEnum<string, Source>? Source
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Source>>("source");
        }
        init { this._rawData.Set("source", value); }
    }

    /// <summary>
    /// State or province name. Present for reverse geocode address results.
    /// </summary>
    public string? State
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("state");
        }
        init { this._rawData.Set("state", value); }
    }

    /// <summary>
    /// Street name. Present for address and interpolated results.
    /// </summary>
    public string? Street
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("street");
        }
        init { this._rawData.Set("street", value); }
    }

    /// <summary>
    /// POI subcategory. Present for place results.
    /// </summary>
    public string? Subcategory
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("subcategory");
        }
        init { this._rawData.Set("subcategory", value); }
    }

    /// <summary>
    /// Raw OSM tags. Present for place results.
    /// </summary>
    public IReadOnlyDictionary<string, string>? Tags
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string>>("tags");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, string>?>(
                "tags",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Wikipedia article reference (e.g. en:Eiffel Tower). Present for notable places.
    /// </summary>
    public string? Wikipedia
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("wikipedia");
        }
        init { this._rawData.Set("wikipedia", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DisplayName;
        _ = this.Category;
        _ = this.City;
        _ = this.Confidence;
        _ = this.Country;
        _ = this.CountryCode;
        _ = this.DistanceM;
        _ = this.FullAddress;
        _ = this.HouseNumber;
        _ = this.Interpolated;
        _ = this.Name;
        _ = this.OsmID;
        this.OsmType?.Validate();
        _ = this.Postcode;
        _ = this.Score;
        this.Source?.Validate();
        _ = this.State;
        _ = this.Street;
        _ = this.Subcategory;
        _ = this.Tags;
        _ = this.Wikipedia;
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
    public Properties(string displayName)
        : this()
    {
        this.DisplayName = displayName;
    }
}

class PropertiesFromRaw : IFromRawJson<Properties>
{
    /// <inheritdoc/>
    public Properties FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Properties.FromRawUnchecked(rawData);
}

/// <summary>
/// OSM element type (node, way, relation)
/// </summary>
[JsonConverter(typeof(OsmTypeConverter))]
public enum OsmType
{
    Node,
    Way,
    Relation,
}

sealed class OsmTypeConverter : JsonConverter<OsmType>
{
    public override OsmType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "node" => OsmType.Node,
            "way" => OsmType.Way,
            "relation" => OsmType.Relation,
            _ => (OsmType)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, OsmType value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                OsmType.Node => "node",
                OsmType.Way => "way",
                OsmType.Relation => "relation",
                _ => throw new PlazaInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Result source indicating how the result was found: structured (exact field match),
/// fuzzy (trigram similarity), address (reverse geocode address), place (reverse
/// geocode POI), interpolation (estimated from neighboring addresses)
/// </summary>
[JsonConverter(typeof(SourceConverter))]
public enum Source
{
    Structured,
    Fuzzy,
    Address,
    Place,
    Interpolation,
}

sealed class SourceConverter : JsonConverter<Source>
{
    public override Source Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "structured" => Source.Structured,
            "fuzzy" => Source.Fuzzy,
            "address" => Source.Address,
            "place" => Source.Place,
            "interpolation" => Source.Interpolation,
            _ => (Source)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Source value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Source.Structured => "structured",
                Source.Fuzzy => "fuzzy",
                Source.Address => "address",
                Source.Place => "place",
                Source.Interpolation => "interpolation",
                _ => throw new PlazaInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(GeocodingFeatureTypeConverter))]
public enum GeocodingFeatureType
{
    Feature,
}

sealed class GeocodingFeatureTypeConverter : JsonConverter<GeocodingFeatureType>
{
    public override GeocodingFeatureType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Feature" => GeocodingFeatureType.Feature,
            _ => (GeocodingFeatureType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        GeocodingFeatureType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                GeocodingFeatureType.Feature => "Feature",
                _ => throw new PlazaInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Plaza.Core;
using Plaza.Exceptions;
using System = System;

namespace Plaza.Models.Geocode;

/// <summary>
/// GeoJSON FeatureCollection of forward geocoding results, ordered by relevance.
/// Content-Type: `application/geo+json`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<GeocodeResult, GeocodeResultFromRaw>))]
public sealed record class GeocodeResult : JsonModel
{
    /// <summary>
    /// Geocoding results ordered by relevance score
    /// </summary>
    public required IReadOnlyList<GeocodingFeature> Features
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<GeocodingFeature>>("features");
        }
        init
        {
            this._rawData.Set<ImmutableArray<GeocodingFeature>>(
                "features",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required ApiEnum<string, GeocodeResultType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, GeocodeResultType>>("type");
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

    public GeocodeResult() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public GeocodeResult(GeocodeResult geocodeResult)
        : base(geocodeResult) { }
#pragma warning restore CS8618

    public GeocodeResult(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GeocodeResult(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="GeocodeResultFromRaw.FromRawUnchecked"/>
    public static GeocodeResult FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class GeocodeResultFromRaw : IFromRawJson<GeocodeResult>
{
    /// <inheritdoc/>
    public GeocodeResult FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        GeocodeResult.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(GeocodeResultTypeConverter))]
public enum GeocodeResultType
{
    FeatureCollection,
}

sealed class GeocodeResultTypeConverter : JsonConverter<GeocodeResultType>
{
    public override GeocodeResultType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "FeatureCollection" => GeocodeResultType.FeatureCollection,
            _ => (GeocodeResultType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        GeocodeResultType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                GeocodeResultType.FeatureCollection => "FeatureCollection",
                _ => throw new PlazaInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

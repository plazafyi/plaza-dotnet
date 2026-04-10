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
/// GeoJSON FeatureCollection of reverse geocoding results, ordered by distance from
/// the query point. Content-Type: `application/geo+json`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ReverseGeocodeResult, ReverseGeocodeResultFromRaw>))]
public sealed record class ReverseGeocodeResult : JsonModel
{
    /// <summary>
    /// Reverse geocoding results ordered by distance
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

    public required ApiEnum<string, ReverseGeocodeResultType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ReverseGeocodeResultType>>("type");
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

    public ReverseGeocodeResult() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ReverseGeocodeResult(ReverseGeocodeResult reverseGeocodeResult)
        : base(reverseGeocodeResult) { }
#pragma warning restore CS8618

    public ReverseGeocodeResult(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReverseGeocodeResult(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ReverseGeocodeResultFromRaw.FromRawUnchecked"/>
    public static ReverseGeocodeResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ReverseGeocodeResultFromRaw : IFromRawJson<ReverseGeocodeResult>
{
    /// <inheritdoc/>
    public ReverseGeocodeResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ReverseGeocodeResult.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ReverseGeocodeResultTypeConverter))]
public enum ReverseGeocodeResultType
{
    FeatureCollection,
}

sealed class ReverseGeocodeResultTypeConverter : JsonConverter<ReverseGeocodeResultType>
{
    public override ReverseGeocodeResultType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "FeatureCollection" => ReverseGeocodeResultType.FeatureCollection,
            _ => (ReverseGeocodeResultType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ReverseGeocodeResultType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ReverseGeocodeResultType.FeatureCollection => "FeatureCollection",
                _ => throw new PlazaInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

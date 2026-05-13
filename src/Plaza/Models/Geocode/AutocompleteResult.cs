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
/// GeoJSON FeatureCollection of autocomplete suggestions for partial address input.
/// Optimized for low-latency type-ahead UIs. Content-Type: `application/geo+json`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<AutocompleteResult, AutocompleteResultFromRaw>))]
public sealed record class AutocompleteResult : JsonModel
{
    /// <summary>
    /// Autocomplete suggestions ordered by relevance
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

    public required ApiEnum<string, global::Plaza.Models.Geocode.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Plaza.Models.Geocode.Type>
            >("type");
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

    public AutocompleteResult() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AutocompleteResult(AutocompleteResult autocompleteResult)
        : base(autocompleteResult) { }
#pragma warning restore CS8618

    public AutocompleteResult(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AutocompleteResult(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AutocompleteResultFromRaw.FromRawUnchecked"/>
    public static AutocompleteResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AutocompleteResultFromRaw : IFromRawJson<AutocompleteResult>
{
    /// <inheritdoc/>
    public AutocompleteResult FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AutocompleteResult.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    FeatureCollection,
}

sealed class TypeConverter : JsonConverter<global::Plaza.Models.Geocode.Type>
{
    public override global::Plaza.Models.Geocode.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "FeatureCollection" => global::Plaza.Models.Geocode.Type.FeatureCollection,
            _ => (global::Plaza.Models.Geocode.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Plaza.Models.Geocode.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Plaza.Models.Geocode.Type.FeatureCollection => "FeatureCollection",
                _ => throw new PlazaInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

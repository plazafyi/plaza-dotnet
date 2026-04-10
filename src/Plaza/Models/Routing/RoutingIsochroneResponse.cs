using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Plaza.Core;
using Plaza.Exceptions;
using System = System;

namespace Plaza.Models.Routing;

/// <summary>
/// GeoJSON FeatureCollection of isochrone polygons — areas reachable within the
/// specified travel time(s). Each Feature is a Polygon contour with travel time
/// and area metadata in properties.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<RoutingIsochroneResponse, RoutingIsochroneResponseFromRaw>)
)]
public sealed record class RoutingIsochroneResponse : JsonModel
{
    /// <summary>
    /// Array of isochrone polygon Features, one per contour
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
    public required ApiEnum<string, RoutingIsochroneResponseType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, RoutingIsochroneResponseType>>(
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

    public RoutingIsochroneResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RoutingIsochroneResponse(RoutingIsochroneResponse routingIsochroneResponse)
        : base(routingIsochroneResponse) { }
#pragma warning restore CS8618

    public RoutingIsochroneResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RoutingIsochroneResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RoutingIsochroneResponseFromRaw.FromRawUnchecked"/>
    public static RoutingIsochroneResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RoutingIsochroneResponseFromRaw : IFromRawJson<RoutingIsochroneResponse>
{
    /// <inheritdoc/>
    public RoutingIsochroneResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RoutingIsochroneResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Always `FeatureCollection`
/// </summary>
[JsonConverter(typeof(RoutingIsochroneResponseTypeConverter))]
public enum RoutingIsochroneResponseType
{
    FeatureCollection,
}

sealed class RoutingIsochroneResponseTypeConverter : JsonConverter<RoutingIsochroneResponseType>
{
    public override RoutingIsochroneResponseType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "FeatureCollection" => RoutingIsochroneResponseType.FeatureCollection,
            _ => (RoutingIsochroneResponseType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RoutingIsochroneResponseType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RoutingIsochroneResponseType.FeatureCollection => "FeatureCollection",
                _ => throw new PlazaInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

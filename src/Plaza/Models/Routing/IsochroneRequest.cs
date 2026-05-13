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
/// Request body for isochrone calculation. Computes areas reachable from a point
/// within the given travel time(s).
/// </summary>
[JsonConverter(typeof(JsonModelConverter<IsochroneRequest, IsochroneRequestFromRaw>))]
public sealed record class IsochroneRequest : JsonModel
{
    /// <summary>
    /// GeoJSON Point geometry per RFC 7946. Coordinates use [longitude, latitude]
    /// order. Optional third element is altitude in meters.
    /// </summary>
    public required PointGeometry Geometry
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<PointGeometry>("geometry");
        }
        init { this._rawData.Set("geometry", value); }
    }

    /// <summary>
    /// Travel time budgets in seconds. Each value produces one contour polygon.
    /// </summary>
    public required IReadOnlyList<long> Time
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<long>>("time");
        }
        init
        {
            this._rawData.Set<ImmutableArray<long>>("time", ImmutableArray.ToImmutableArray(value));
        }
    }

    /// <summary>
    /// Travel mode (default: `auto`)
    /// </summary>
    public ApiEnum<string, IsochroneRequestMode>? Mode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, IsochroneRequestMode>>("mode");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("mode", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Geometry.Validate();
        _ = this.Time;
        this.Mode?.Validate();
    }

    public IsochroneRequest() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public IsochroneRequest(IsochroneRequest isochroneRequest)
        : base(isochroneRequest) { }
#pragma warning restore CS8618

    public IsochroneRequest(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IsochroneRequest(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IsochroneRequestFromRaw.FromRawUnchecked"/>
    public static IsochroneRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class IsochroneRequestFromRaw : IFromRawJson<IsochroneRequest>
{
    /// <inheritdoc/>
    public IsochroneRequest FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        IsochroneRequest.FromRawUnchecked(rawData);
}

/// <summary>
/// Travel mode (default: `auto`)
/// </summary>
[JsonConverter(typeof(IsochroneRequestModeConverter))]
public enum IsochroneRequestMode
{
    Auto,
    Foot,
    Bicycle,
}

sealed class IsochroneRequestModeConverter : JsonConverter<IsochroneRequestMode>
{
    public override IsochroneRequestMode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "auto" => IsochroneRequestMode.Auto,
            "foot" => IsochroneRequestMode.Foot,
            "bicycle" => IsochroneRequestMode.Bicycle,
            _ => (IsochroneRequestMode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        IsochroneRequestMode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                IsochroneRequestMode.Auto => "auto",
                IsochroneRequestMode.Foot => "foot",
                IsochroneRequestMode.Bicycle => "bicycle",
                _ => throw new PlazaInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

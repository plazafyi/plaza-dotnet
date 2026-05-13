using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Plaza.Core;
using Plaza.Exceptions;
using System = System;

namespace Plaza.Models.Optimize;

/// <summary>
/// Route optimization (Travelling Salesman) request. Finds the most efficient order
/// to visit a set of waypoints. Minimum 2 waypoints, maximum 50. For large inputs,
/// the request may be processed asynchronously.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<OptimizeRequest, OptimizeRequestFromRaw>))]
public sealed record class OptimizeRequest : JsonModel
{
    /// <summary>
    /// GeoJSON MultiPoint geometry per RFC 7946. An array of positions.
    /// </summary>
    public required MultiPointGeometry Waypoints
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<MultiPointGeometry>("waypoints");
        }
        init { this._rawData.Set("waypoints", value); }
    }

    /// <summary>
    /// Travel mode (default: `auto`)
    /// </summary>
    public ApiEnum<string, OptimizeRequestMode>? Mode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, OptimizeRequestMode>>("mode");
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

    /// <summary>
    /// Whether the route should return to the starting waypoint (default: true)
    /// </summary>
    public bool? Roundtrip
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("roundtrip");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("roundtrip", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Waypoints.Validate();
        this.Mode?.Validate();
        _ = this.Roundtrip;
    }

    public OptimizeRequest() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OptimizeRequest(OptimizeRequest optimizeRequest)
        : base(optimizeRequest) { }
#pragma warning restore CS8618

    public OptimizeRequest(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OptimizeRequest(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OptimizeRequestFromRaw.FromRawUnchecked"/>
    public static OptimizeRequest FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public OptimizeRequest(MultiPointGeometry waypoints)
        : this()
    {
        this.Waypoints = waypoints;
    }
}

class OptimizeRequestFromRaw : IFromRawJson<OptimizeRequest>
{
    /// <inheritdoc/>
    public OptimizeRequest FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        OptimizeRequest.FromRawUnchecked(rawData);
}

/// <summary>
/// Travel mode (default: `auto`)
/// </summary>
[JsonConverter(typeof(OptimizeRequestModeConverter))]
public enum OptimizeRequestMode
{
    Auto,
    Foot,
    Bicycle,
}

sealed class OptimizeRequestModeConverter : JsonConverter<OptimizeRequestMode>
{
    public override OptimizeRequestMode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "auto" => OptimizeRequestMode.Auto,
            "foot" => OptimizeRequestMode.Foot,
            "bicycle" => OptimizeRequestMode.Bicycle,
            _ => (OptimizeRequestMode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        OptimizeRequestMode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                OptimizeRequestMode.Auto => "auto",
                OptimizeRequestMode.Foot => "foot",
                OptimizeRequestMode.Bicycle => "bicycle",
                _ => throw new PlazaInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

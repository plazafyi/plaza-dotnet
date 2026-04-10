using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Plaza.Core;
using Plaza.Exceptions;
using System = System;

namespace Plaza.Models.Routing;

/// <summary>
/// Calculate a route between two points
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class RoutingRouteParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// GeoJSON Point geometry per RFC 7946. Coordinates use [longitude, latitude]
    /// order. Optional third element is altitude in meters.
    /// </summary>
    public required PointGeometry Destination
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<PointGeometry>("destination");
        }
        init { this._rawBodyData.Set("destination", value); }
    }

    /// <summary>
    /// GeoJSON Point geometry per RFC 7946. Coordinates use [longitude, latitude]
    /// order. Optional third element is altitude in meters.
    /// </summary>
    public required PointGeometry Origin
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<PointGeometry>("origin");
        }
        init { this._rawBodyData.Set("origin", value); }
    }

    /// <summary>
    /// Response format for alternatives: json (default), geojson, csv, ndjson
    /// </summary>
    public string? Format
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("format");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("format", value);
        }
    }

    /// <summary>
    /// Number of alternative routes to return (0-3, default 0). When &gt; 0, response
    /// is a FeatureCollection of route Features.
    /// </summary>
    public long? Alternatives
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>("alternatives");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("alternatives", value);
        }
    }

    /// <summary>
    /// Include per-edge annotations (speed, duration) on the route (default: false)
    /// </summary>
    public bool? Annotations
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("annotations");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("annotations", value);
        }
    }

    /// <summary>
    /// Departure time for traffic-aware routing (ISO 8601)
    /// </summary>
    public System::DateTimeOffset? DepartAt
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<System::DateTimeOffset>("depart_at");
        }
        init { this._rawBodyData.Set("depart_at", value); }
    }

    /// <summary>
    /// Electric vehicle parameters for EV-aware routing
    /// </summary>
    public Ev? Ev
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Ev>("ev");
        }
        init { this._rawBodyData.Set("ev", value); }
    }

    /// <summary>
    /// Comma-separated road types to exclude (e.g. `toll,motorway,ferry`)
    /// </summary>
    public string? Exclude
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("exclude");
        }
        init { this._rawBodyData.Set("exclude", value); }
    }

    /// <summary>
    /// Geometry encoding format. Default: `geojson`.
    /// </summary>
    public ApiEnum<string, Geometries>? Geometries
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, Geometries>>("geometries");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("geometries", value);
        }
    }

    /// <summary>
    /// Travel mode (default: `auto`)
    /// </summary>
    public ApiEnum<string, RoutingRouteParamsMode>? Mode
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, RoutingRouteParamsMode>>(
                "mode"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("mode", value);
        }
    }

    /// <summary>
    /// Level of geometry detail: `full` (all points), `simplified` (Douglas-Peucker),
    /// `false` (no geometry). Default: `full`.
    /// </summary>
    public ApiEnum<string, Overview>? Overview
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, Overview>>("overview");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("overview", value);
        }
    }

    /// <summary>
    /// Include turn-by-turn navigation steps (default: false)
    /// </summary>
    public bool? Steps
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("steps");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("steps", value);
        }
    }

    /// <summary>
    /// Traffic prediction model (only used when `depart_at` is set)
    /// </summary>
    public ApiEnum<string, TrafficModel>? TrafficModel
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, TrafficModel>>(
                "traffic_model"
            );
        }
        init { this._rawBodyData.Set("traffic_model", value); }
    }

    /// <summary>
    /// Intermediate waypoints to visit in order (maximum 25)
    /// </summary>
    public IReadOnlyList<PointGeometry>? Waypoints
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<PointGeometry>>("waypoints");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<PointGeometry>?>(
                "waypoints",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public RoutingRouteParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RoutingRouteParams(RoutingRouteParams routingRouteParams)
        : base(routingRouteParams)
    {
        this._rawBodyData = new(routingRouteParams._rawBodyData);
    }
#pragma warning restore CS8618

    public RoutingRouteParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RoutingRouteParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static RoutingRouteParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(RoutingRouteParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/api/v1/route")
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

/// <summary>
/// Electric vehicle parameters for EV-aware routing
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Ev, EvFromRaw>))]
public sealed record class Ev : JsonModel
{
    /// <summary>
    /// Total battery capacity in watt-hours (required for EV routing)
    /// </summary>
    public required double BatteryCapacityWh
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("battery_capacity_wh");
        }
        init { this._rawData.Set("battery_capacity_wh", value); }
    }

    /// <summary>
    /// Acceptable connector types (e.g. `["ccs", "chademo"]`)
    /// </summary>
    public IReadOnlyList<string>? ConnectorTypes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("connector_types");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "connector_types",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Starting charge as a fraction 0-1 (default: 0.8)
    /// </summary>
    public double? InitialChargePct
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("initial_charge_pct");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("initial_charge_pct", value);
        }
    }

    /// <summary>
    /// Minimum acceptable charge at destination as a fraction 0-1 (default: 0.10)
    /// </summary>
    public double? MinChargePct
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("min_charge_pct");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("min_charge_pct", value);
        }
    }

    /// <summary>
    /// Minimum charger power in kilowatts
    /// </summary>
    public double? MinPowerKw
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("min_power_kw");
        }
        init { this._rawData.Set("min_power_kw", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BatteryCapacityWh;
        _ = this.ConnectorTypes;
        _ = this.InitialChargePct;
        _ = this.MinChargePct;
        _ = this.MinPowerKw;
    }

    public Ev() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Ev(Ev ev)
        : base(ev) { }
#pragma warning restore CS8618

    public Ev(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Ev(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EvFromRaw.FromRawUnchecked"/>
    public static Ev FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Ev(double batteryCapacityWh)
        : this()
    {
        this.BatteryCapacityWh = batteryCapacityWh;
    }
}

class EvFromRaw : IFromRawJson<Ev>
{
    /// <inheritdoc/>
    public Ev FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Ev.FromRawUnchecked(rawData);
}

/// <summary>
/// Geometry encoding format. Default: `geojson`.
/// </summary>
[JsonConverter(typeof(GeometriesConverter))]
public enum Geometries
{
    Geojson,
    Polyline,
    Polyline6,
}

sealed class GeometriesConverter : JsonConverter<Geometries>
{
    public override Geometries Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "geojson" => Geometries.Geojson,
            "polyline" => Geometries.Polyline,
            "polyline6" => Geometries.Polyline6,
            _ => (Geometries)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        Geometries value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Geometries.Geojson => "geojson",
                Geometries.Polyline => "polyline",
                Geometries.Polyline6 => "polyline6",
                _ => throw new PlazaInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Travel mode (default: `auto`)
/// </summary>
[JsonConverter(typeof(RoutingRouteParamsModeConverter))]
public enum RoutingRouteParamsMode
{
    Auto,
    Foot,
    Bicycle,
}

sealed class RoutingRouteParamsModeConverter : JsonConverter<RoutingRouteParamsMode>
{
    public override RoutingRouteParamsMode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "auto" => RoutingRouteParamsMode.Auto,
            "foot" => RoutingRouteParamsMode.Foot,
            "bicycle" => RoutingRouteParamsMode.Bicycle,
            _ => (RoutingRouteParamsMode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RoutingRouteParamsMode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RoutingRouteParamsMode.Auto => "auto",
                RoutingRouteParamsMode.Foot => "foot",
                RoutingRouteParamsMode.Bicycle => "bicycle",
                _ => throw new PlazaInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Level of geometry detail: `full` (all points), `simplified` (Douglas-Peucker),
/// `false` (no geometry). Default: `full`.
/// </summary>
[JsonConverter(typeof(OverviewConverter))]
public enum Overview
{
    Full,
    Simplified,
    False,
}

sealed class OverviewConverter : JsonConverter<Overview>
{
    public override Overview Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "full" => Overview.Full,
            "simplified" => Overview.Simplified,
            "false" => Overview.False,
            _ => (Overview)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Overview value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Overview.Full => "full",
                Overview.Simplified => "simplified",
                Overview.False => "false",
                _ => throw new PlazaInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Traffic prediction model (only used when `depart_at` is set)
/// </summary>
[JsonConverter(typeof(TrafficModelConverter))]
public enum TrafficModel
{
    BestGuess,
    Optimistic,
    Pessimistic,
}

sealed class TrafficModelConverter : JsonConverter<TrafficModel>
{
    public override TrafficModel Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "best_guess" => TrafficModel.BestGuess,
            "optimistic" => TrafficModel.Optimistic,
            "pessimistic" => TrafficModel.Pessimistic,
            _ => (TrafficModel)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TrafficModel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TrafficModel.BestGuess => "best_guess",
                TrafficModel.Optimistic => "optimistic",
                TrafficModel.Pessimistic => "pessimistic",
                _ => throw new PlazaInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

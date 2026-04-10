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
/// Request body for route calculation. Origin and destination are GeoJSON Point geometries.
/// Supports optional waypoints, alternative routes, turn-by-turn steps, and EV routing parameters.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<RouteRequest, RouteRequestFromRaw>))]
public sealed record class RouteRequest : JsonModel
{
    /// <summary>
    /// GeoJSON Point geometry per RFC 7946. Coordinates use [longitude, latitude]
    /// order. Optional third element is altitude in meters.
    /// </summary>
    public required PointGeometry Destination
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<PointGeometry>("destination");
        }
        init { this._rawData.Set("destination", value); }
    }

    /// <summary>
    /// GeoJSON Point geometry per RFC 7946. Coordinates use [longitude, latitude]
    /// order. Optional third element is altitude in meters.
    /// </summary>
    public required PointGeometry Origin
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<PointGeometry>("origin");
        }
        init { this._rawData.Set("origin", value); }
    }

    /// <summary>
    /// Number of alternative routes to return (0-3, default 0). When &gt; 0, response
    /// is a FeatureCollection of route Features.
    /// </summary>
    public long? Alternatives
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("alternatives");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("alternatives", value);
        }
    }

    /// <summary>
    /// Include per-edge annotations (speed, duration) on the route (default: false)
    /// </summary>
    public bool? Annotations
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("annotations");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("annotations", value);
        }
    }

    /// <summary>
    /// Departure time for traffic-aware routing (ISO 8601)
    /// </summary>
    public System::DateTimeOffset? DepartAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("depart_at");
        }
        init { this._rawData.Set("depart_at", value); }
    }

    /// <summary>
    /// Electric vehicle parameters for EV-aware routing
    /// </summary>
    public RouteRequestEv? Ev
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<RouteRequestEv>("ev");
        }
        init { this._rawData.Set("ev", value); }
    }

    /// <summary>
    /// Comma-separated road types to exclude (e.g. `toll,motorway,ferry`)
    /// </summary>
    public string? Exclude
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("exclude");
        }
        init { this._rawData.Set("exclude", value); }
    }

    /// <summary>
    /// Geometry encoding format. Default: `geojson`.
    /// </summary>
    public ApiEnum<string, RouteRequestGeometries>? Geometries
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, RouteRequestGeometries>>(
                "geometries"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("geometries", value);
        }
    }

    /// <summary>
    /// Travel mode (default: `auto`)
    /// </summary>
    public ApiEnum<string, RouteRequestMode>? Mode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, RouteRequestMode>>("mode");
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
    /// Level of geometry detail: `full` (all points), `simplified` (Douglas-Peucker),
    /// `false` (no geometry). Default: `full`.
    /// </summary>
    public ApiEnum<string, RouteRequestOverview>? Overview
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, RouteRequestOverview>>(
                "overview"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("overview", value);
        }
    }

    /// <summary>
    /// Include turn-by-turn navigation steps (default: false)
    /// </summary>
    public bool? Steps
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("steps");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("steps", value);
        }
    }

    /// <summary>
    /// Traffic prediction model (only used when `depart_at` is set)
    /// </summary>
    public ApiEnum<string, RouteRequestTrafficModel>? TrafficModel
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, RouteRequestTrafficModel>>(
                "traffic_model"
            );
        }
        init { this._rawData.Set("traffic_model", value); }
    }

    /// <summary>
    /// Intermediate waypoints to visit in order (maximum 25)
    /// </summary>
    public IReadOnlyList<PointGeometry>? Waypoints
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<PointGeometry>>("waypoints");
        }
        init
        {
            this._rawData.Set<ImmutableArray<PointGeometry>?>(
                "waypoints",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Destination.Validate();
        this.Origin.Validate();
        _ = this.Alternatives;
        _ = this.Annotations;
        _ = this.DepartAt;
        this.Ev?.Validate();
        _ = this.Exclude;
        this.Geometries?.Validate();
        this.Mode?.Validate();
        this.Overview?.Validate();
        _ = this.Steps;
        this.TrafficModel?.Validate();
        foreach (var item in this.Waypoints ?? [])
        {
            item.Validate();
        }
    }

    public RouteRequest() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RouteRequest(RouteRequest routeRequest)
        : base(routeRequest) { }
#pragma warning restore CS8618

    public RouteRequest(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RouteRequest(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RouteRequestFromRaw.FromRawUnchecked"/>
    public static RouteRequest FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RouteRequestFromRaw : IFromRawJson<RouteRequest>
{
    /// <inheritdoc/>
    public RouteRequest FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        RouteRequest.FromRawUnchecked(rawData);
}

/// <summary>
/// Electric vehicle parameters for EV-aware routing
/// </summary>
[JsonConverter(typeof(JsonModelConverter<RouteRequestEv, RouteRequestEvFromRaw>))]
public sealed record class RouteRequestEv : JsonModel
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

    public RouteRequestEv() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RouteRequestEv(RouteRequestEv routeRequestEv)
        : base(routeRequestEv) { }
#pragma warning restore CS8618

    public RouteRequestEv(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RouteRequestEv(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RouteRequestEvFromRaw.FromRawUnchecked"/>
    public static RouteRequestEv FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public RouteRequestEv(double batteryCapacityWh)
        : this()
    {
        this.BatteryCapacityWh = batteryCapacityWh;
    }
}

class RouteRequestEvFromRaw : IFromRawJson<RouteRequestEv>
{
    /// <inheritdoc/>
    public RouteRequestEv FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        RouteRequestEv.FromRawUnchecked(rawData);
}

/// <summary>
/// Geometry encoding format. Default: `geojson`.
/// </summary>
[JsonConverter(typeof(RouteRequestGeometriesConverter))]
public enum RouteRequestGeometries
{
    Geojson,
    Polyline,
    Polyline6,
}

sealed class RouteRequestGeometriesConverter : JsonConverter<RouteRequestGeometries>
{
    public override RouteRequestGeometries Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "geojson" => RouteRequestGeometries.Geojson,
            "polyline" => RouteRequestGeometries.Polyline,
            "polyline6" => RouteRequestGeometries.Polyline6,
            _ => (RouteRequestGeometries)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RouteRequestGeometries value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RouteRequestGeometries.Geojson => "geojson",
                RouteRequestGeometries.Polyline => "polyline",
                RouteRequestGeometries.Polyline6 => "polyline6",
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
[JsonConverter(typeof(RouteRequestModeConverter))]
public enum RouteRequestMode
{
    Auto,
    Foot,
    Bicycle,
}

sealed class RouteRequestModeConverter : JsonConverter<RouteRequestMode>
{
    public override RouteRequestMode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "auto" => RouteRequestMode.Auto,
            "foot" => RouteRequestMode.Foot,
            "bicycle" => RouteRequestMode.Bicycle,
            _ => (RouteRequestMode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RouteRequestMode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RouteRequestMode.Auto => "auto",
                RouteRequestMode.Foot => "foot",
                RouteRequestMode.Bicycle => "bicycle",
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
[JsonConverter(typeof(RouteRequestOverviewConverter))]
public enum RouteRequestOverview
{
    Full,
    Simplified,
    False,
}

sealed class RouteRequestOverviewConverter : JsonConverter<RouteRequestOverview>
{
    public override RouteRequestOverview Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "full" => RouteRequestOverview.Full,
            "simplified" => RouteRequestOverview.Simplified,
            "false" => RouteRequestOverview.False,
            _ => (RouteRequestOverview)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RouteRequestOverview value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RouteRequestOverview.Full => "full",
                RouteRequestOverview.Simplified => "simplified",
                RouteRequestOverview.False => "false",
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
[JsonConverter(typeof(RouteRequestTrafficModelConverter))]
public enum RouteRequestTrafficModel
{
    BestGuess,
    Optimistic,
    Pessimistic,
}

sealed class RouteRequestTrafficModelConverter : JsonConverter<RouteRequestTrafficModel>
{
    public override RouteRequestTrafficModel Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "best_guess" => RouteRequestTrafficModel.BestGuess,
            "optimistic" => RouteRequestTrafficModel.Optimistic,
            "pessimistic" => RouteRequestTrafficModel.Pessimistic,
            _ => (RouteRequestTrafficModel)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RouteRequestTrafficModel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RouteRequestTrafficModel.BestGuess => "best_guess",
                RouteRequestTrafficModel.Optimistic => "optimistic",
                RouteRequestTrafficModel.Pessimistic => "pessimistic",
                _ => throw new PlazaInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

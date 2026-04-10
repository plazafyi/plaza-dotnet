using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Plaza.Core;
using Plaza.Exceptions;
using System = System;

namespace Plaza.Models.Routing;

/// <summary>
/// GeoJSON Feature representing a calculated route. The geometry is a LineString
/// or MultiLineString of the route path. When `alternatives &gt; 0`, the response
/// is a FeatureCollection containing multiple route Features.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<RouteResult, RouteResultFromRaw>))]
public sealed record class RouteResult : JsonModel
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
    /// Route metadata
    /// </summary>
    public required RouteResultProperties Properties
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<RouteResultProperties>("properties");
        }
        init { this._rawData.Set("properties", value); }
    }

    public required ApiEnum<string, RouteResultType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, RouteResultType>>("type");
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

    public RouteResult() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RouteResult(RouteResult routeResult)
        : base(routeResult) { }
#pragma warning restore CS8618

    public RouteResult(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RouteResult(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RouteResultFromRaw.FromRawUnchecked"/>
    public static RouteResult FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RouteResultFromRaw : IFromRawJson<RouteResult>
{
    /// <inheritdoc/>
    public RouteResult FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        RouteResult.FromRawUnchecked(rawData);
}

/// <summary>
/// Route metadata
/// </summary>
[JsonConverter(typeof(JsonModelConverter<RouteResultProperties, RouteResultPropertiesFromRaw>))]
public sealed record class RouteResultProperties : JsonModel
{
    /// <summary>
    /// Total route distance in meters
    /// </summary>
    public required double DistanceM
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("distance_m");
        }
        init { this._rawData.Set("distance_m", value); }
    }

    /// <summary>
    /// Estimated travel duration in seconds
    /// </summary>
    public required double DurationS
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("duration_s");
        }
        init { this._rawData.Set("duration_s", value); }
    }

    /// <summary>
    /// Per-edge annotations (present when `annotations: true` in request)
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? Annotations
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "annotations"
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "annotations",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Battery charge level at route waypoints as [distance_fraction, charge_pct]
    /// pairs (EV routes only)
    /// </summary>
    public IReadOnlyList<IReadOnlyList<double>>? ChargeProfile
    {
        get
        {
            this._rawData.Freeze();
            var value = this._rawData.GetNullableStruct<ImmutableArray<ImmutableArray<double>>>(
                "charge_profile"
            );
            if (value == null)
            {
                return null;
            }

            return ImmutableArray.ToImmutableArray(
                Enumerable.Select(value.Value, (item) => (IReadOnlyList<double>)item)
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<ImmutableArray<double>>?>(
                "charge_profile",
                value == null
                    ? null
                    : ImmutableArray.ToImmutableArray(
                        Enumerable.Select(value, (item) => ImmutableArray.ToImmutableArray(item))
                    )
            );
        }
    }

    /// <summary>
    /// Recommended charging stops along the route (EV routes only)
    /// </summary>
    public IReadOnlyList<IReadOnlyDictionary<string, JsonElement>>? ChargingStops
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<FrozenDictionary<string, JsonElement>>
            >("charging_stops");
        }
        init
        {
            this._rawData.Set<ImmutableArray<FrozenDictionary<string, JsonElement>>?>(
                "charging_stops",
                value == null
                    ? null
                    : ImmutableArray.ToImmutableArray(
                        Enumerable.Select(
                            value,
                            (item) => FrozenDictionary.ToFrozenDictionary(item)
                        )
                    )
            );
        }
    }

    /// <summary>
    /// Edge-level route details (present when `annotations: true`)
    /// </summary>
    public IReadOnlyList<IReadOnlyDictionary<string, JsonElement>>? Edges
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<FrozenDictionary<string, JsonElement>>
            >("edges");
        }
        init
        {
            this._rawData.Set<ImmutableArray<FrozenDictionary<string, JsonElement>>?>(
                "edges",
                value == null
                    ? null
                    : ImmutableArray.ToImmutableArray(
                        Enumerable.Select(
                            value,
                            (item) => FrozenDictionary.ToFrozenDictionary(item)
                        )
                    )
            );
        }
    }

    /// <summary>
    /// Total energy consumed in watt-hours (EV routes only)
    /// </summary>
    public double? EnergyUsedWh
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("energy_used_wh");
        }
        init { this._rawData.Set("energy_used_wh", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DistanceM;
        _ = this.DurationS;
        _ = this.Annotations;
        _ = this.ChargeProfile;
        _ = this.ChargingStops;
        _ = this.Edges;
        _ = this.EnergyUsedWh;
    }

    public RouteResultProperties() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RouteResultProperties(RouteResultProperties routeResultProperties)
        : base(routeResultProperties) { }
#pragma warning restore CS8618

    public RouteResultProperties(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RouteResultProperties(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RouteResultPropertiesFromRaw.FromRawUnchecked"/>
    public static RouteResultProperties FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RouteResultPropertiesFromRaw : IFromRawJson<RouteResultProperties>
{
    /// <inheritdoc/>
    public RouteResultProperties FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RouteResultProperties.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(RouteResultTypeConverter))]
public enum RouteResultType
{
    Feature,
}

sealed class RouteResultTypeConverter : JsonConverter<RouteResultType>
{
    public override RouteResultType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Feature" => RouteResultType.Feature,
            _ => (RouteResultType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RouteResultType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RouteResultType.Feature => "Feature",
                _ => throw new PlazaInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

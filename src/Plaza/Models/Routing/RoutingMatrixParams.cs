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
/// Calculate a distance matrix between points
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class RoutingMatrixParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Array of destination coordinates as GeoJSON Points (max 50)
    /// </summary>
    public required IReadOnlyList<PointGeometry> Destinations
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<ImmutableArray<PointGeometry>>(
                "destinations"
            );
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<PointGeometry>>(
                "destinations",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Array of origin coordinates as GeoJSON Points (max 50)
    /// </summary>
    public required IReadOnlyList<PointGeometry> Origins
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<ImmutableArray<PointGeometry>>("origins");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<PointGeometry>>(
                "origins",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Comma-separated list of annotations to include: `duration` (always included),
    /// `distance`. Example: `duration,distance`.
    /// </summary>
    public string? Annotations
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("annotations");
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
    /// Fallback speed in km/h for pairs where no route exists. When set, unreachable
    /// pairs get estimated values instead of null.
    /// </summary>
    public double? FallbackSpeed
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<double>("fallback_speed");
        }
        init { this._rawBodyData.Set("fallback_speed", value); }
    }

    /// <summary>
    /// Travel mode (default: `auto`)
    /// </summary>
    public ApiEnum<string, RoutingMatrixParamsMode>? Mode
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, RoutingMatrixParamsMode>>(
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

    public RoutingMatrixParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RoutingMatrixParams(RoutingMatrixParams routingMatrixParams)
        : base(routingMatrixParams)
    {
        this._rawBodyData = new(routingMatrixParams._rawBodyData);
    }
#pragma warning restore CS8618

    public RoutingMatrixParams(
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
    RoutingMatrixParams(
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
    public static RoutingMatrixParams FromRawUnchecked(
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

    public virtual bool Equals(RoutingMatrixParams? other)
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
        return new System::UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/api/v1/matrix")
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
/// Travel mode (default: `auto`)
/// </summary>
[JsonConverter(typeof(RoutingMatrixParamsModeConverter))]
public enum RoutingMatrixParamsMode
{
    Auto,
    Foot,
    Bicycle,
}

sealed class RoutingMatrixParamsModeConverter : JsonConverter<RoutingMatrixParamsMode>
{
    public override RoutingMatrixParamsMode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "auto" => RoutingMatrixParamsMode.Auto,
            "foot" => RoutingMatrixParamsMode.Foot,
            "bicycle" => RoutingMatrixParamsMode.Bicycle,
            _ => (RoutingMatrixParamsMode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RoutingMatrixParamsMode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RoutingMatrixParamsMode.Auto => "auto",
                RoutingMatrixParamsMode.Foot => "foot",
                RoutingMatrixParamsMode.Bicycle => "bicycle",
                _ => throw new PlazaInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

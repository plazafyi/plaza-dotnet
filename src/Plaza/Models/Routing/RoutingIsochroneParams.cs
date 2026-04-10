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
/// Calculate an isochrone from a point
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class RoutingIsochroneParams : ParamsBase
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
    public required PointGeometry Geometry
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<PointGeometry>("geometry");
        }
        init { this._rawBodyData.Set("geometry", value); }
    }

    /// <summary>
    /// Travel time budgets in seconds. Each value produces one contour polygon.
    /// </summary>
    public required IReadOnlyList<long> Time
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<ImmutableArray<long>>("time");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<long>>(
                "time",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Response format: json (default), geojson, csv, ndjson
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
    /// Travel mode (default: `auto`)
    /// </summary>
    public ApiEnum<string, Mode>? Mode
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, Mode>>("mode");
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

    public RoutingIsochroneParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RoutingIsochroneParams(RoutingIsochroneParams routingIsochroneParams)
        : base(routingIsochroneParams)
    {
        this._rawBodyData = new(routingIsochroneParams._rawBodyData);
    }
#pragma warning restore CS8618

    public RoutingIsochroneParams(
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
    RoutingIsochroneParams(
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
    public static RoutingIsochroneParams FromRawUnchecked(
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

    public virtual bool Equals(RoutingIsochroneParams? other)
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
        return new System::UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/api/v1/isochrone")
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
[JsonConverter(typeof(ModeConverter))]
public enum Mode
{
    Auto,
    Foot,
    Bicycle,
}

sealed class ModeConverter : JsonConverter<Mode>
{
    public override Mode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "auto" => Mode.Auto,
            "foot" => Mode.Foot,
            "bicycle" => Mode.Bicycle,
            _ => (Mode)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Mode value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Mode.Auto => "auto",
                Mode.Foot => "foot",
                Mode.Bicycle => "bicycle",
                _ => throw new PlazaInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
